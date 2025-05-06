function validateLoginForm() //main validation function
{
    let formIsOK = true;

    formIsOK = checkEmail() && formIsOK;

    return formIsOK;
}



function checkEmail() {

    let reg_mail = document.getElementById("reg_mail").value;
    let reg_errormail = document.getElementById("reg_errormail");
    let regexMail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (reg_mail === "") {
        reg_errormail.innerText = "Please enter your email.";
        return false;
    }

    if (!regexMail.test(reg_mail)) {
        reg_errormail.innerText = "Invalid email format.";
        return false;
    }

    reg_errormail.innerText = "";
    return true;
}
