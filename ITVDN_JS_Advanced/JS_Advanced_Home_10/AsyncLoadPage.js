var btn1;
var output1;
var output2;

window.onload = function () {
    btn1 = document.getElementById("btn1");
    output1 = document.getElementById("output1");
    output2 = document.getElementById("output2");

    btn1.addEventListener("click", function () {
        var xhr = new XMLHttpRequest();
        xhr.open("GET", "PageA.html");

        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                output1.innerHTML += xhr.responseText;
            }
        }
        xhr.send();
    });

    btn1.addEventListener("click", function () {
        var xhr = new XMLHttpRequest();
        xhr.open("GET", "PageB.html");

        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                output1.innerHTML += xhr.responseText;
            }
        }
        xhr.send();
    });
}