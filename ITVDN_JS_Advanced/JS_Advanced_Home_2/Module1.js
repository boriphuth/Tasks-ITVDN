var Module1 = {};

Module1.name = "Module 1";

Module1.startModule = function () {   
        var items = document.getElementsByTagName("p");
        for (var i = 0; i < items.length; i++) {
            items[i].innerHTML = "Module changed PARAGRAPH";
        }        
}