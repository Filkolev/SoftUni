var shapeModule,
    circle,
    rectangle,
    triangle,
    line,
    segment;

function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

shapeModule = (function () {
    'use strict';

    var Circle,
        Rectangle,
        Triangle,
        Line,
        Segment;

    function Shape(color) {
        this._color = color;
    }

    Shape.prototype.toString = function () {
        return 'Color: ' + this._color;
    }

    Circle = (function () {
        function Circle(centerX, centerY, radius, color) {
            this._centerX = centerX;
            this._centerY = centerY;
            setRadius(this, radius);
            Shape.call(this, color);
        }

        function setRadius(circle, radiusValue) {
            if (!isNumber(radiusValue) || radiusValue <= 0) {
                throw new Error('The radius of a circle should be a positive number');
            }

            circle._radius = radiusValue;
        }

        return Circle;
    })();

    Circle.prototype = Object.create(Shape.prototype);
    Circle.prototype.constructor = Circle;
    Circle.prototype.toString = function () {
        var result = 'Circle: ';

        result += 'Center: O(' + this._centerX + ', ' + this._centerY + '), ';
        result += "Radius: " + this._radius + ", ";
        result += Shape.prototype.toString.call(this);

        return result;
    }

    Rectangle = (function () {
        function Rectangle(topLeftX, topLeftY, width, height, color) {
            this._topLeftX = topLeftX;
            this._topleftY = topLeftY;
            setWidth(this, width);
            setHeight(this, height);
            Shape.call(this, color);
        }

        function setWidth(rect, widthValue) {
            if (!isNumber(widthValue) || widthValue <= 0) {
                throw new Error('The width of a rectangle should be a positive number');
            }

            rect._width = widthValue;
        }

        function setHeight(rect, heightValue) {
            if (!isNumber(heightValue) || heightValue <= 0) {
                throw new Error('The height of a rectangle should be a positive number');
            }

            rect._height = heightValue;
        }

        return Rectangle;
    })();

    Rectangle.prototype = Object.create(Shape.prototype);
    Rectangle.prototype.constructor = Rectangle;
    Rectangle.prototype.toString = function () {
        var result = 'Rectangle: ';

        result += 'Top-left corner: A(' + this._topLeftX + ', ' + this._topleftY + '), ';
        result += 'Width: ' + this._width + ', ';
        result += 'Height: ' + this._height + ', ';
        result += Shape.prototype.toString.call(this);

        return result;
    }

    Triangle = (function () {
        function setTriangleVertices(triangle, aX, aY, bX, bY, cX, cY) {
            if (!triangle.isValidTriangle(aX, aY, bX, bY, cX, cY)) {
                throw new Error('The points provided do not form a valid triangle.');
            }

            triangle._aX = aX;
            triangle._aY = aY;
            triangle._bX = bX;
            triangle._bY = bY;
            triangle._cX = cX;
            triangle._cY = cY;
        }

        function Triangle(pointAx, pointAy, pointBx, pointBy, pointCx, pointCy, color) {
            setTriangleVertices(this, pointAx, pointAy, pointBx, pointBy, pointCx, pointCy);
            Shape.call(this, color);
        }

        return Triangle;
    })();

    Triangle.prototype = Object.create(Shape.prototype);
    Triangle.prototype.constructor = Triangle;
    Triangle.prototype.toString = function () {
        var result = 'Triangle: ';

        result += 'A(' + this._aX + ', ' + this._aY + '), ';
        result += 'B(' + this._bX + ', ' + this._bY + '), ';
        result += 'C(' + this._cX + ', ' + this._cY + '), ';
        result += Shape.prototype.toString.call(this);

        return result;
    }

    Triangle.prototype.isValidTriangle = function (aX, aY, bX, bY, cX, cY) {
        var sideA = Shape.prototype.getDistanceBetweenPoints(aX, aY, bX, bY),
            sideB = Shape.prototype.getDistanceBetweenPoints(bX, bY, cX, cY),
            sideC = Shape.prototype.getDistanceBetweenPoints(aX, aY, cX, cY);

        if (sideA <= 0 || sideB <= 0 || sideC <= 0) {
            return false;
        }

        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA) {
            return false;
        }

        return true;
    }

    Line = (function () {
        function Line(aX, aY, bX, bY, color) {
            this._aX = aX;
            this._aY = aY;
            this._bX = bX;
            this._bY = bY;
            Shape.call(this, color);
        }

        return Line;
    })();

    Line.prototype = Object.create(Shape.prototype);
    Line.prototype.constructor = Line;
    Line.prototype.toString = function () {
        var result = 'Line: ';

        result += 'A(' + this._aX + ', ' + this._aY + '), B(' + this._bX + ', ' + this._bY + '), ';
        result += Shape.prototype.toString.call(this);

        return result;
    }

    Segment = (function () {
        function Segment(aX, aY, bX, bY, color) {
            Line.call(this, aX, aY, bX, bY, color);
        }

        return Segment;
    })();

    Segment.prototype = Object.create(Line.prototype);
    Segment.prototype.constructor = Segment;
    Segment.prototype.toString = function () {
        var result = 'Segment: ';
        result += 'A(' + this._aX + ', ' + this._aY + '), B(' + this._bX + ', ' + this._bY + '), ';
        result += Shape.prototype.toString.call(this);

        return result;
    }

    Shape.prototype.getDistanceBetweenPoints = function (aX, aY, bX, bY) {
        var deltaX = aX - bX,
            deltaY = aY - bY,
            distance = Math.sqrt(deltaX * deltaX + deltaY * deltaY);

        return distance;
    }

    return {
        Circle: Circle,
        Rectangle: Rectangle,
        Triangle: Triangle,
        Line: Line,
        Segment: Segment
    }
})();

circle = new shapeModule.Circle(0, 0, 12, "#00FF00");
console.log(circle.toString());

rectangle = new shapeModule.Rectangle(0, 0, 2, 4, "AAA");
console.log(rectangle.toString());

triangle = new shapeModule.Triangle(0, 0, 1, 1, 5, 8, "ABC");
console.log(triangle.toString());

line = new shapeModule.Line(0, 0, 1, 1, "A");
console.log(line.toString());

segment = new shapeModule.Segment(0, 1, 2, 3, "S");
console.log(segment.toString());