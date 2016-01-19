function Point(x, y) {
    this.x = x;
    this.y = y;

    this.PrintCurrent = function () {
        document.write("Exemp " + x + ", " + y + "<br />");
    }
}

Point.Name = "Point ctor func";

Point.PrintName = function () {
    document.write(Point.Name);
}



var point1 = new Point(10, 20);
var point2 = new Point(30, 26);

point1.PrintCurrent();
point2.PrintCurrent();

Point.PrintName();
