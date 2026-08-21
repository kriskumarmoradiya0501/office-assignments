// ======================================================
// CUSTOM PASSWORD VALIDATION METHODS
// ======================================================


// 1. Capital Letter
$.validator.addMethod(
    "capital",
    function (value, element) {

        return /[A-Z]/.test(value);

    },
    "Password must contain at least one capital letter."
);


// 2. Number
$.validator.addMethod(
    "number",
    function (value, element) {

        return /[0-9]/.test(value);

    },
    "Password must contain at least one number."
);


// 3. Special Character
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

    $("#form").validate({

        
        // ==================================================
        // LIVE VALIDATION
        // ==================================================

        onkeyup: function (element) {

            // Validate field while typing
            this.element(element);

        },


        // ==================================================
        // VALIDATE WHEN USER LEAVES FIELD
        // ==================================================

        onfocusout: function (element) {

            this.element(element);

        },


        // ==================================================
        // RULES
        // ==================================================

        rules: {


            // ------------------------------------------------
            // EMAIL
            // ------------------------------------------------

            email: {

                required: true,

                email: true

            },


            // ------------------------------------------------
            // PASSWORD
            // ------------------------------------------------

            password: {

                required: true,

                minlength: 8,

                capital: true,

                number: true,

                special: true

            }

        },


        // ==================================================
        // ERROR MESSAGES
        // ==================================================

        messages: {


            // ------------------------------------------------
            // EMAIL MESSAGES
            // ------------------------------------------------

            email: {

                required:
                    "Email is required.",

                email:
                    "Enter a valid email address."

            },


            // ------------------------------------------------
            // PASSWORD MESSAGES
            // ------------------------------------------------

            password: {

                required:
                    "Please enter your password.",

                minlength:
                    "Password must be at least 8 characters.",

                capital:
                    "Password must contain at least one capital letter.",

                number:
                    "Password must contain at least one number.",

                special:
                    "Password must contain at least one special character."

            }

        },


        // ==================================================
        // PUT ERROR INTO YOUR EXISTING SPANS
        // ==================================================

        errorPlacement: function (error, element) {


            // Email error
            if (element.attr("name") === "email") {

                $("#emailError").html(error);

            }


            // Password error
            else if (element.attr("name") === "password") {

                $("#passwordError").html(error);

            }


            // Other errors
            else {

                error.insertAfter(element);

            }

        },


        // ==================================================
        // WHEN FIELD BECOMES VALID
        // ==================================================

        success: function (label, element) {

            if ($(element).attr("name") === "email") {

                $("#emailError").html("");

            }


            if ($(element).attr("name") === "password") {

                $("#passwordError").html("");

            }

        },


        // ==================================================
        // WHEN FORM IS COMPLETELY VALID
        // ==================================================

        submitHandler: function (form) {

            window.location.href = "welcome.html";

        }

    });

});