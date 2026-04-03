async function calculate(event) {

    event.preventDefault(); // stops form submission

    const form = document.getElementById("calcForm");

    if (!form.checkValidity()) {
        //resultBox.value = form.reportValidity(); // shows browser messages
        return;
    }

    const fieldA = parseFloat(document.getElementById("FieldA").value);
    const fieldB = parseFloat(document.getElementById("FieldB").value);
    const resultBox = document.getElementById("result");

    if (isNaN(fieldA) || isNaN(fieldB)) {
        resultBox.value = "Please enter valid numbers.";
        return;
    }

    const select = document.getElementById("operations");
    resultBox.value = "";
    const operator = select.options[select.selectedIndex].innerText;
    
    try {
        const response = await fetch('/operations/Calculate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                fieldA: fieldA,
                fieldB: fieldB,
                operator
            })
        });

        const data = await response.json();

        if (!response.ok) {
            resultBox.value = data.result ?? "Calculation failed";
            return;
        }

        resultBox.value = data.result;
        
    } catch (error) {
        resultBox.value = "Unexpected error";
    }
}

async function createOperator() {
    let value = document.getElementById("newOperator").value;
    let description = document.getElementById("operatorDescription").value;

    if (!value) {
        alert("Please enter an operator");
        return;
    }

    const item = {
        Name: value,
        Description: description
    };

    const response = await fetch('/operations/Create', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    });

    console.log(response);
    const data = await response.json();

    if (!response.ok) {
        alert("Failed to create operator. Please try again.");
        return;
    }

    document.getElementById("newOperator").value = "";
    document.getElementById("operatorDescription").value = "";
    refreshOperations();
}

async function refreshOperations() {
    const response = await fetch('/operations/GetOperations', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        },
    });

    const data = await response.json();
    const select = document.getElementById("operations");

    select.innerHTML = "";

    data.operators.forEach(op => {
        const option = document.createElement("option");
        option.value = op.operationId;
        option.text = op.operator;
        select.appendChild(option);
    });
}

function limitLength(input, maxDigits) {
    // Remove any character that isn't a digit, minus sign, or decimal point
    input.value = input.value
        .replace(/[^0-9.\-]/g, '')       // strip invalid chars
        .replace(/(?!^)-/g, '')           // minus only allowed at start
        .replace(/(\.\d*)\./g, '$1');     // only one decimal point allowed

    const digits = input.value.replace(/[^0-9]/g, '');
    if (digits.length > maxDigits) {
        input.value = input.value.slice(0, -1);
    }
}