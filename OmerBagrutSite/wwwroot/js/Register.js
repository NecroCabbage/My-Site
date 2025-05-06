
//console.log("Register.js loaded"); //for testing
//alert("Register.js LOADED");

function validateRegistgerForm() //main validation function
{
    let formIsOK = true;

    formIsOK = checkEmail() && formIsOK;

    formIsOK = checkFirstName() && formIsOK;

    formIsOK = checkLastName() && formIsOK;

    formIsOK = checkBirthYear() && formIsOK;

    formIsOK = checkPhoneNumber() && formIsOK;

    formIsOK = checkPassword() && formIsOK;

    formIsOK = checkVerifyPassword() && formIsOK;

    /*formIsOK = checkGender() && formIsOK;*/ /*here for now so i can check in with the wrong gender */

    return formIsOK;
}

/*you could use const here in these functions insted of let  which just means that the variable can't be
reassigned.You can still use and read its value — just can’t change it after declaring it. (let = normal variable)*/

//.value is used to get or set the content of form elements like < input > or < textarea >.
//.innerHTML is used to get or set the HTML content inside elements like < div >, <span>, or <p>.
// Use .value for user input fields, and .innerHTML for regular text or error messages.

//.innerText puts plain text into an element. Use .innerText when you just want to show text.
//.innerHTML allows HTML code(like < b >, <br>, etc.). Use .innerHTML if you want to include formatting or tags.

function checkEmail()
{

    let reg_mail = document.getElementById("reg_mail").value;              
    let reg_errormail = document.getElementById("reg_errormail");            
    let regexMail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (reg_mail === "")
    {
        reg_errormail.innerText = "Please enter your email.";
        return false;
    }

    if (!regexMail.test(reg_mail))
    {
        reg_errormail.innerText = "Invalid email format.";
        return false;
    }

    reg_errormail.innerText = "";
    return true;
}

function checkFirstName()
{
    /*you could shorten the first 2 lines here into: let firstName = document.getElementById("reg_firstname").value;
    but its good to have the extra variable here if you wanna acces the original value even if its not usefull in this example*/

    let firstNameElement = document.getElementById("reg_firstname");
    let firstName = firstNameElement.value;
    let regexFirstName = /^[a-zA-Z][a-zA-Z\s-]{0,20}[a-zA-Z]$/; /* In regex, () are grouping symbols. so its not neccicery here*/

    if (firstName.length == 0) {

        document.getElementById("reg_errorfirstname").innerText = "Required";
        return false;
    }


    if (!regexFirstName.test(firstName)) {

        document.getElementById("reg_errorfirstname").innerText = "Invalid first name";

        return false;

    }

    document.getElementById("reg_errorfirstname").innerText = "";
    return true;
}

function checkLastName()
{
    let lastName = document.getElementById("reg_lastname").value;
    let regexLastName = /(^[a-zA-Z][a-zA-Z\s-]{0,20}[a-zA-Z]$)/;

    if (lastName.length == 0)
    {
        document.getElementById("reg_errorlastname").innerText = "Required";
        return false;
    }
    
    if (!regexLastName.test(lastName))
    {
        document.getElementById("reg_errorlastname").innerText = "Invalid last name";
        return false;
    }

    document.getElementById("reg_errorlastname").innerText = "";
    return true;
}

function checkBirthYear()
{
    let currentYear = new Date().getFullYear();
    let BirthYear = document.getElementById("reg_birthyear").value;
    let age = currentYear - BirthYear;

    if (age >= 16)
    {
        document.getElementById("reg_errorbirthyear").innerText = "";
        return true;
    }

    else
    {
        document.getElementById("reg_errorbirthyear").innerText = "You need to be 16+ years old";
        return false;
    }


}

function checkPhoneNumber()
{
    /*in regex ? means mean "or"*/

    /* + is a special character in regex So when you write +? directly it tries to 
    interpret + as a quantifier, not the actual + symbol.so you need to make it \+? */
    let phone = document.getElementById("reg_phone").value
    let regexPhone = /^[0-9]{9,15}$/;

    if (!regexPhone.test(phone))
    {
        document.getElementById("reg_errorphone").innerText = "Invalid phone number";
        return false;
    }

    if (phone.length == 0)
    {
        document.getElementById("reg_errorphone").innerText = "Required";
        return false;
    }

    document.getElementById("reg_errorphone").innerText = "";
    return true;
}

function checkPassword() 
{
    let password = document.getElementById("reg_password").value
    let regexPassword = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,15}$/;

    if (!regexPassword.test(password)) {
        document.getElementById("reg_errorpassword").innerText = "Invalid password. \n Must have: at least six characters, a max of 15 characters, one uppercase letter, one lowercase letter, one number and no special characters.";
        return false;
    }

    if (password.length == 0) {
        document.getElementById("reg_errorpassword").innerText = "Required";
        return false;
    }

    document.getElementById("reg_errorpassword").innerText = "";
    return true;
}

function checkVerifyPassword()
{
    if (document.getElementById("reg_password").value != document.getElementById("reg_verifypassword").value)
    {
        document.getElementById("reg_errorverifypassword").innerText = "Invalid. Passwords do not match";
        return false;
    }

    document.getElementById("reg_errorverifypassword").innerText = "";
    return true;
}

function checkGender()  /*this check is not necessary just a joke*/
{
    /*beacuse document.getElementsByName("gender") returns a sort of array genders[0] = Male, genders[1] = Female, genders[2] = Velociraptor */

    let genders = document.getElementsByName("user.Gender");

    // Check if "Male" or "Female" is selected
    if (genders[0].checked || genders[1].checked) {
        document.getElementById("reg_errorgender").innerText = "Incorrect";
        return false;
    }

    document.getElementById("reg_errorgender").innerText = "";
    return true;
}