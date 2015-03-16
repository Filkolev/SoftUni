var Shape = (function () {

    function Shape(x, y, color) {
        this._x = x;
        this._y = y;
        this._color = color;
    }
    Shape.prototype.toString = function () {
        return "x= " + this._x + ", y= " + this._y + ", color: " + this._color;
    }
    return Shape;
})();

var Circle = (function () {

    function Circle(x, y, color, r) {
        Shape.call(this, x, y, color);
        this._r = r;
    }
    Circle.prototype = Object.create(Shape.prototype);
    Circle.prototype.constructor = Circle;
    //  Circle.prototype = new Shape();


    Circle.prototype.toString = function () {
        return Shape.prototype.toString.call(this) + ", r = " + this._r;
    }
    return Circle;
})();

var c = new Circle(1, 2, 5, 7);
console.log(c.toString());