$(document).ready(function () {
    const form = $("#signupForm");

    function clearErrors() {
        $("#nameError, #genderError, #dobError, #countryError, #passwordError, #confirmPasswordError, #termsError").text("");
    }

    function validateName() {
        const value = $("#name").val().trim();
        if (value === "") {
            $("#nameError").text("Enter Name ");
            return false;
        }
        if (/[0-9]/.test(value)) {
            $("#nameError").text("name don't contain numbers ");
            return false;
        }
        if (/[!@#$%^&*(),.?\":{}|<>]/.test(value)) {
            $("#nameError").text("Name can not contain special characters");
            return false;
        }
        return true;
    }

    function validateGender() {
    if ($("input[name='gender']:checked").length === 0) {
        $("#genderError").text("Select Gender");
        return false;
    }

    return true;
}

    function validateDob() {
        if ($("#dob").val() === "") {
            $("#dobError").text("Please select date of birth");
            return false;
        }
        return true;
    }

    function validateCountry() {
        if ($("#country").val() == "--Select Country--") {
            $("#countryError").text("Selecte Your Country");
            return false;
        }
        return true;
    }

    function validatePassword() {
        const value = $("#password").val();
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
        if (!/[!@#$%^&*(),.?\":{}|<>]/.test(value)) {
            $('#passwordError').text("one letter must be simbol");
            return false;
        }
        return true;
    }

    function validateConfirmPassword() {
        if ($("#confirmPassword").val() !== $("#password").val()) {
            $("#confirmPasswordError").text("Password is not matching");
            return false;
        }
        return true;
    }

    function validateTerms() {
        if (!$("#terms").is(":checked")) {
            $("#termsError").text("you must be agree with terms and conditions");
            return false;
        }
        return true;
    }

    form.on("submit", function (e) {
        e.preventDefault(); // prevent default submission
        clearErrors();
        let isValid = true;

        if (!validateName()) isValid = false;
        if (!validateGender()) isValid = false;
        if (!validateDob()) isValid = false;
        if (!validateCountry()) isValid = false;
        if (!validatePassword()) isValid = false;
        if (!validateConfirmPassword()) isValid = false;
        if (!validateTerms()) isValid = false;

        if (isValid) {
            // redirect only if valid
            window.location.href = "login.html";
        }
    });
});