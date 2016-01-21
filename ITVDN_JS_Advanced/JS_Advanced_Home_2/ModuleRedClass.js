var MyQuery = {};

MyQuery.FindClass = function (id) {
    var list = document.getElementsByTagName("p");
    var arr = [];
    for (var i = 0; i < list.length; i++) {
        var Class = list[i].getAttributeNode("class");

        if (Class != null && Class.value == id) {            
            arr.push(list[i]);
        }
    }
    return arr;
}