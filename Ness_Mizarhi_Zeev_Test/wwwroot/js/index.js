async function calculate(event) {

    event.preventDefault(); // stops form submission

    const form = document.getElementById("calcForm");

    if (!form.checkValidity()) {
        //resultBox.value = form.reportValidity(); // shows browser messages
        return;
    }

    const fieldA = document.getElementById("FieldA").value;
    const fieldB = document.getElementById("FieldB").value;
    const select = document.getElementById("operations");
    
    const resultBox = document.getElementById("result");
    resultBox.value = "";

    const operator = select.options[select.selectedIndex].innerText;

    
    try {
        const response = await fetch('/operations/Calculate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ fieldA, fieldB, operator })
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
        throw new Error("Failed to create item");
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