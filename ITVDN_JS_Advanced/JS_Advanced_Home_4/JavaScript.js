var login;
var password;
var helper;
var btn;
var formLogin;
var formPassword;
var checkBox;

window.onload = function () {
    login = document.getElementById("login");
    password = document.getElementById("password");
    helper = document.getElementById("helper");
    btn = document.getElementById("btn");
    formLogin = document.getElementById("formLogin");
    formPassword = document.getElementById("formPassword");
    checkBox = document.getElementById("checkBox");
    btn.onclick = submit;
}

function submit() {
    if (login.value == "" || password.value == "") {
        helper.innerText = "Вы не заполнили поля логин и пароль";
        helper.style.color = "red";
        formLogin.className = "has-error";
        formPassword.className = "has-error";
        return false;
    }
    if (login.value == "admin" && password.value == "12345") {
        helper.innerText = "Вы авторизированы";
        formLogin.className = "has-success";
        formPassword.className = "has-success";
        helper.style.color = "green";
        return false;// change on true and redirect 
    }
    else {
        helper.innerText = "Не верный логин или пароль";
        helper.style.color = "orange";
        formLogin.className = "has-warning";
        formPassword.className = "has-warning";
        return false;
    }
    
}