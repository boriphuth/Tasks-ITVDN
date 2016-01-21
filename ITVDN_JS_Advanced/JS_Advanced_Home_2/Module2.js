(setTimeout(function() {
    var items = document.getElementsByTagName("p");
    for (var i = 0; i < items.length; i++) {
        items[i].innerHTML = "Anonim function changed PARAGRAPH";
    }
},5000));