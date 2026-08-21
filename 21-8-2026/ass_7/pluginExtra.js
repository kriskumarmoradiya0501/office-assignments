<script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.19.5/dist/additional-methods.min.js"></script>


$(document).ready(function () {
  const fnamePattern = /^[A-Za-z ]+$/;
  const passwordPattern =
    /^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^A-Za-z0-9]).{8,}$/;


  $("#signupform").validate({
    rules: {
      fname: {
        required: true,
        pattern: fnamePattern,
      },


      gender: {
        required: true,
      },


      dob: {
        required: true,
      },


      country: {
        required: true,
      },


      password: {
        required: true,
        minlength: 8,
        pattern: passwordPattern,
      },


      cpassword: {
        required: true,
        equalTo: "#password",
      },


      terms: {
        required: true,
      },
    },


    messages: {
      fname: {
        required: "Name is required",
        pattern: "Please enter only alphabet",
      },


      gender: {
        required: "Please select gender",
      },


      dob: {
        required: "Date of birth is required",
      },


      country: {
        required: "Please select a country",
      },


      password: {
        required: "Password is required",
        minlength: "Password must be at least 8 characters",
        pattern:
          "Password must contain one capital letter, one small letter, one digit, and one special character",
      },


      cpassword: {
        required: "Confirm password is required",
        equalTo: "Passwords do not match",
      },


      terms: {
        required: "Please check remember",
      },
    },


    // errorPlacement: function (error, element) {
    //   if (element.attr("name") === "gender") {
    //     error.appendTo("#genderError");
    //   } else {
    //     error.insertAfter(element);
    //   }
    // },
  });
});



