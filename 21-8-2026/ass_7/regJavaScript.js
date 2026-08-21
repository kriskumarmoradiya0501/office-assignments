document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById('signupForm');
    const name = document.getElementById('name');
    const gender = document.getElementsByName('gender');
    const dob = document.getElementById('dob');
    const country = document.getElementById('country');
    const password = document.getElementById('password');
    const confirmPassword = document.getElementById('confirmPassword');
    const terms = document.getElementById('terms');


    const nameError = document.getElementById("nameError");
    const genderError = document.getElementById("genderError");
    const dobError = document.getElementById("dobError");
    const countryError = document.getElementById("countryError");
    const passwordError = document.getElementById("passwordError");
    const confirmPasswordError = document.getElementById("confirmPasswordError");
    const termsError = document.getElementById("termsError");


    function clearErrors() {
        nameError.textContent = "";
        genderError.textContent = "";
        dobError.textContent = "";
        countryError.textContent = "";
        passwordError.textContent = "";
        confirmPasswordError.textContent = "";
        termsError.textContent = "";
    }

    function validateName() {
        const value = name.value;

        if (value.trim() == "") {
            nameError.textContent = "Enter Name";
            return false;
        }
        if (/[!@#$%^&*()\-_\+={}|\:;'".><?\/]/.test(value)) {
            return false;
        }
        return true;
    }

    function validateGender() {
        let selected = false;

        for (let g of gender) {
            if (g.checked) {
                selected = true;
            }
        }
        if (!selected) {
            genderError.textContent = "Selecte Gender";
            return false;
        }
        return true;
    }

    function validateDob() {
        const value = dob.value;

        if (value == "") {
            dobError.textContent = "Please select Date of Birth";
            return false;
        }
        return true;
    }

    function validateCountry() {
        const value = country.value;
        if (value == "--Select Country--") {
            countryError.textContent = "Select country";
            return false;
        }
        return true;
    }

    function validatePassword() {
        const value = password.value;
        if (value == "") {
            passwordError.textContent = "Enter Password";
            return false;
        }
        if (value.length < 8) {
            passwordError.textContent = "Password atleast have 8 latters";
            return false;
        }

        if (!/[A-Z]/.test(value)) {
            passwordError.textContent = "Passwrod must have atlest one Capital alphabet";
            return false;
        }
        if (!/[0-9]/.test(value)) {
            passwordError.textContent = "Password must have atlest one Number";
            return false;
        }
        if (!/[!@#$%^&*(),.?":{}|<>]/.test(value)) {
            passwordError.textContent = "Password must have atlest one special character";
            return false;
        }
        return true;
    }

    function validateConfrimPassword() {
        if (confirmPassword.value !== password.value) {
            confirmPasswordError.textContent = "password not matching please check the password";
            return false;
        }
        return true;
    }

    function validateTerms() {
        if (!terms.checked) {
            termsError.textContent = "You need to be agree with terms and conditions";
            return false;
        }
        return true;
    }

    form.addEventListener('submit', function (e) {
        e.preventDefault();
        clearErrors();

        let valid = true;
        if (!validateName()) valid = false;
        if (!validateGender()) valid = false;
        if (!validateDob()) valid = false;
        if (!validateCountry()) valid = false;
        if (!validatePassword()) valid = false;
        if (!validateConfrimPassword()) valid = false;
        if (!validateTerms()) valid = false;

        if (valid) {
            window.location.href = "login.html";
        }

    })

})