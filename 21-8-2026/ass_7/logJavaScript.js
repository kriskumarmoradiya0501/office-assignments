document.addEventListener("DOMContentLoaded",function(){

const form = document.getElementById('form');
const email = document.getElementById('email');
const password = document.getElementById('password');

function emailValidation(){
  const value = email.value.trim();
  if(value == ""){
    alert("Email is required");
    return false;
  }
  if(!value.includes("@") || !value.includes(".")){
    alert("Email Must contain @ and . ");
    return false;
  }
  return true;
}

function passwordValidation(){
  const value = password.value;
  if(value == ""){
    alert("Enter Password");
    return false;
  }
  if(value.length < 8 ){
    alert("Password atleast have 8 latters");
    return false;
  }

  if(!/[A-Z]/.test(value)){
    alert("Passwrod must have atlest one Capital alphabet");
    return false;
  }
  if(!/[0-9]/.test(value)){
    alert("Password must have atlest one Number");
    return false;
  }
  if(!/[!@#$%^&*(),.?":{}|<>]/.test(value)){
    alert("Password must have atlest one special character");
  }
  return true;
}

form.addEventListener("submit",function(e){
      e.preventDefault();

  if(emailValidation() && passwordValidation()){
        window.location.href = "welcome.html";

  }
})

})