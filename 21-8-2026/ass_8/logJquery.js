$(document).ready(function () {
    const form = $("#form");
    const email = $("#email");
    const password = $("#password");

    function clearError() {
        $('#emailError').text("");
        $('#passwordError').text("");
    }

    function emailValidation() {
        const value = email.val().trim();
        if (value == "") {
            $('#emailError').text("Email is required");
            return false;
        }
        if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value)) {
            $('#emailError').text("Enter a valid email address");
            return false;
        }

        return true;
    }

    function passwordValidation() {
        const value = password.val().trim();
        if (value === "") {
            $('#passwordError').text("enter Password");
            return false;
        }
        if (value.length < 8) {
            $('#passwordError').text("password length must be atlas 8 letters");
            return false;
        }
        if (!/[A-Z]/.test(value)) {
            $('#passwordError').text("one character must be capital ");
            return false;

        }
        if (!/[0-9]/.test(value)) {
            $('#passwordError').text("one character must be number ");
            return false;

        }
        if (!/[!@#$%^&*(),.?":{}|<>]/.test(value)) {
            $('#passwordError').text("one letter must be simbol");
            return false;

        }
        return true;
    }

    form.on("submit", function (e) {
        e.preventDefault();
        clearError();
        let isValid = true;

        if(emailValidation() == false){ isValid = false;}
        if(passwordValidation() == false){isValid = false;}

        if (isValid) {
            window.location.href = "welcome.html";
        }
    })

})