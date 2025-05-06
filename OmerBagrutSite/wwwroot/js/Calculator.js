//let userData = promt("enter the number")
//alert(userData + 1)
//if (userData > 100)
//    alert(userData);
window.onload = function ()
{
    let questions = document.getElementsByClassName("question-text");
    let correctAnswers = [0];

    for (let i = 0; i < questions.length; i++) {
        let num1 = Math.floor(Math.random() * 20) + 1;
        let num2 = Math.floor(Math.random() * 10) + 1;

        let question = "";
        if (i === 0) { question = num1 + " + " + num2; correctAnswers[i] = num1 + num2; }
        if (i === 1) { question = num1 + " - " + num2; correctAnswers[i] = num1 - num2; }
        if (i === 2) { question = num1 + " * " + num2; correctAnswers[i] = num1 * num2; }
        if (i === 3) { question = num1 + " / " + num2; correctAnswers[i] = Math.floor(num1 / num2); }
        if (i === 4) { question = num1 + " % " + num2; correctAnswers[i] = num1 % num2; }
        if (i === 5) { question = num1 + " + " + (num2 * 2); correctAnswers[i] = num1 + (num2 * 2); }

        questions[i].innerText = question;
        questions[i].setAttribute("data-answer", correctAnswers[i]);
    }
};

function checkAnswers()
{
    let userInputs = document.getElementsByClassName("userAnswer");
    let questions = document.getElementsByClassName("question-text");
    let results = document.getElementsByClassName("result");

    for (let i = 0; i < userInputs.length; i++) {
        let userAnswer = parseInt(userInputs[i].value);
        let correctAnswer = parseInt(questions[i].getAttribute("data-answer"));

        results[i].innerText = userAnswer === correctAnswer ? "V" : "X";
        results[i].style.color = userAnswer === correctAnswer ? "green" : "red";
    }
}