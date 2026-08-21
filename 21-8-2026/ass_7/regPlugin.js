// ======================================================
// CUSTOM VALIDATION METHODS
// ======================================================


// ======================================================
// 1. NAME VALIDATION
// ======================================================

$.validator.addMethod(
    "validName",
    function (value, element) {

        return /^[A-Za-z ]+$/.test(value);

    },
    "Name can contain only letters."
);



// ======================================================
// 2. CAPITAL LETTER VALIDATION
// ======================================================

$.validator.addMethod(
    "capital",
    function (value, element) {

        return /[A-Z]/.test(value);

    },
    "Password must contain at least one capital letter."
);



// ======================================================
// 3. NUMBER VALIDATION
// ======================================================

$.validator.addMethod(
    "number",
    function (value, element) {

        return /[0-9]/.test(value);

    },
    "Password must contain at least one number."
);



// ======================================================
// 4. SPECIAL CHARACTER VALIDATION
// ======================================================

$.validator.addMethod(
    "special",
    function (value, element) {

        return /[!@#$%^&*(),.?":{}|<>]/.test(value);

    },
    "Password must contain at least one special character."
);



// ======================================================
// DOCUMENT READY
// ======================================================

$(document).ready(function () {


    // ==================================================
    // FORM VALIDATION
    // ==================================================

    $("#signupForm").validate({

        
        // ==============================================
        // LIVE VALIDATION WHILE TYPING
        // ==============================================

        onkeyup: function (element) {

            // Validate current field
            this.element(element);


            // ------------------------------------------
            // IMPORTANT:
            // Password change thay to Confirm Password
            // pan immediately validate thavu joie
            // ------------------------------------------

            if (element.name === "password") {

                if ($("#confirmPassword").val() !== "") {

                    this.element("#confirmPassword");

                }

            }

        },


        // ==============================================
        // VALIDATE WHEN USER LEAVES FIELD
        // ==============================================

        onfocusout: function (element) {

            this.element(element);

        },


        // ==============================================
        // RULES
        // ==============================================

        rules: {


            // ------------------------------------------
            // NAME
            // ------------------------------------------

            name: {

                required: true,

                minlength: 2,

                validName: true

            },


            // ------------------------------------------
            // GENDER
            // ------------------------------------------

            gender: {

                required: true

            },


            // ------------------------------------------
            // DATE OF BIRTH
            // ------------------------------------------

            dob: {

                required: true

            },


            // ------------------------------------------
            // COUNTRY
            // ------------------------------------------

            country: {

                required: true

            },


            // ------------------------------------------
            // PASSWORD
            // ------------------------------------------

            password: {

                required: true,

                minlength: 8,

                capital: true,

                number: true,

                special: true

            },


            // ------------------------------------------
            // CONFIRM PASSWORD
            // ------------------------------------------

            confirmPassword: {

                required: true,

                equalTo: "#password"

            },


            // ------------------------------------------
            // TERMS
            // ------------------------------------------

            terms: {

                required: true

            }

        },


        // ==================================================
        // ERROR MESSAGES
        // ==================================================

        messages: {


            // ------------------------------------------
            // NAME
            // ------------------------------------------

            name: {

                required:
                    "Enter Name.",

                minlength:
                    "Name must be at least 2 characters.",

                validName:
                    "Name can contain only letters."

            },


            // ------------------------------------------
            // GENDER
            // ------------------------------------------

            gender: {

                required:
                    "Select Gender."

            },


            // ------------------------------------------
            // DOB
            // ------------------------------------------

            dob: {

                required:
                    "Please select Date of Birth."

            },


            // ------------------------------------------
            // COUNTRY
            // ------------------------------------------

            country: {

                required:
                    "Select country."

            },


            // ------------------------------------------
            // PASSWORD
            // ------------------------------------------

            password: {

                required:
                    "Enter Password.",

                minlength:
                    "Password must be at least 8 characters.",

                capital:
                    "Password must have at least one capital letter.",

                number:
                    "Password must have at least one number.",

                special:
                    "Password must have at least one special character."

            },


            // ------------------------------------------
            // CONFIRM PASSWORD
            // ------------------------------------------

            confirmPassword: {

                required:
                    "Confirm Password is required.",

                equalTo:
                    "Passwords do not match."

            },


            // ------------------------------------------
            // TERMS
            // ------------------------------------------

            terms: {

                required:
                    "You need to agree with terms and conditions."

            }

        },


        // ==================================================
        // ERROR PLACEMENT
        // ==================================================
        // Aapda existing spans use karishu
        // ==================================================

        errorPlacement: function (error, element) {


            // NAME
            if (element.attr("name") === "name") {

                $("#nameError").html(error);

            }


            // GENDER
            else if (element.attr("name") === "gender") {

                $("#genderError").html(error);

            }


            // DOB
            else if (element.attr("name") === "dob") {

                $("#dobError").html(error);

            }


            // COUNTRY
            else if (element.attr("name") === "country") {

                $("#countryError").html(error);

            }


            // PASSWORD
            else if (element.attr("name") === "password") {

                $("#passwordError").html(error);

            }


            // CONFIRM PASSWORD
            else if (element.attr("name") === "confirmPassword") {

                $("#confirmPasswordError").html(error);

            }


            // TERMS
            else if (element.attr("name") === "terms") {

                $("#termsError").html(error);

            }


            // Other elements
            else {

                error.insertAfter(element);

            }

        },


        // ==================================================
        // SUCCESS
        // ==================================================
        // Error remove when field becomes valid
        // ==================================================

        success: function (label, element) {

            const fieldName =
                $(element).attr("name");


            if (fieldName === "name") {

                $("#nameError").html("");

            }


            if (fieldName === "gender") {

                $("#genderError").html("");

            }


            if (fieldName === "dob") {

                $("#dobError").html("");

            }


            if (fieldName === "country") {

                $("#countryError").html("");

            }


            if (fieldName === "password") {

                $("#passwordError").html("");

            }


            if (fieldName === "confirmPassword") {

                $("#confirmPasswordError").html("");

            }


            if (fieldName === "terms") {

                $("#termsError").html("");

            }

        },


        // ==================================================
        // LIVE EVENTS FOR SELECT / DATE / RADIO / CHECKBOX
        // ==================================================

        onfocusout: function (element) {

            this.element(element);

        },


        // ==================================================
        // FORM SUBMIT
        // ==================================================

        submitHandler: function (form) {

            // Everything is valid

            window.location.href = "welcome.html";

        }

    });



    // ==================================================
    // EXTRA LIVE VALIDATION
    // For fields which don't use keyup
    // ==================================================


    // ------------------------------------------
    // GENDER
    // ------------------------------------------

    $('input[name="gender"]').on("change", function () {

        $("#signupForm").validate().element(
            'input[name="gender"]'
        );

    });



    // ------------------------------------------
    // DATE OF BIRTH
    // ------------------------------------------

    $("#dob").on("change", function () {

        $("#signupForm").validate().element("#dob");

    });



    // ------------------------------------------
    // COUNTRY
    // ------------------------------------------

    $("#country").on("change", function () {

        $("#signupForm").validate().element("#country");

    });



    // ------------------------------------------
    // TERMS
    // ------------------------------------------

    $("#terms").on("change", function () {

        $("#signupForm").validate().element("#terms");

    });



    // ------------------------------------------
    // CONFIRM PASSWORD
    // ------------------------------------------

    $("#confirmPassword").on("input", function () {

        $("#signupForm").validate().element(
            "#confirmPassword"
        );

    });



    // ------------------------------------------
    // PASSWORD
    // ------------------------------------------

    $("#password").on("input", function () {

        const validator =
            $("#signupForm").validate();


        // Validate password
        validator.element("#password");


        // Validate confirm password
        // if already entered

        if ($("#confirmPassword").val() !== "") {

            validator.element("#confirmPassword");

        }

    });

});