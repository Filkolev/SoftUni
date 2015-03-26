var shapesModule,
    circle,
    rect,
    triangle,
    line,
    segment;

Object.prototype.extend = function (properties) {
    'use strict';

    var prop;

    function f() { };
    f.prototype = Object.create(this);

    for (prop in properties) {
        f.prototype[prop] = properties[prop];
    }

    f.prototype._super = this;

    return new f();
}

shapesModule = (function () {
    'use strict';

    var shape,
        circle,
        rectangle,
        triangle,
        line,
        segment;

    shape = {
        init: function init(color) {
            this._color = color;
        },
        toString: function () {
            return 'Color: ' + this._color;
        }
    }

    circle = shape.extend({
        init: function init(centerX, centerY, radius, color) {
            this._super.init(color);
            this._centerX = centerX;
            this._centerY = centerY;
            this._radius = radius;
        },
        toString: function () {
            var result = 'Circle: ';

            result += 'O(' + this._centerX + ', ' + this._centerY + '), ';
            result += 'Radius: ' + this._radius + ', ';
            result += this._super.toString();

            return result;
        }
    });

    rectangle = shape.extend({
        init: function init(topLeftX, topLeftY, width, height, color) {
            this._super.init(color);
            this._topLeftX = topLeftX;
            this._topleftY = topLeftY;
            this._width = width;
            this._height = height;
        },
        toString: function () {
            var result = 'Rectangle: ';

            result += 'Top-Left(' + this._topLeftX + ', ' + this._topleftY + '), ';
            result += 'Width: ' + this._width + ', ';
            result += 'Height: ' + this._height + ', ';
            result += this._super.toString();

            return result;
        }
    });

    triangle = shape.extend({
        init: function init(aX, aY, bX, bY, cX, cY, color) {
            this._super.init(color);
            this._aX = aX;
            this._aY = aY;
            this._bX = bX;
            this._bY = bY;
            this._cX = cX;
            this._cY = cY;
        },
        toString: function () {
            var result = 'Triangle: ';

            result += 'A(' + this._aX + ', ' + this._aY + '), ';
            result += 'B(' + this._bX + ', ' + this._bY + '), ';
            result += 'C(' + this._cX + ', ' + this._cY + '), ';
            result += this._super.toString();

            return result;
        }
    });

    line = shape.extend({
        init: function (aX, aY, bX, bY, color) {
            this._super.init(color);
            this._aX = aX;
            this._aY = aY;
            this._bX = bX;
            this._bY = bY;
        },
        toString: function () {
            var result = 'Line: ';

            result += 'A(' + this._aX + ', ' + this._aY + '), ';
            result += 'B(' + this._bX + ', ' + this._bY + '), ';
            result += this._super.toString();

            return result;
        }
    });

    segment = line.extend({
        init: function (aX, aY, bX, bY, color) {
            this._super.init(aX, aY, bX, bY, color);
        },
        toString: function () {
            var result = 'Segment: ';

            result += 'A(' + this._aX + ', ' + this._aY + '), ';
            result += 'B(' + this._bX + ', ' + this._bY + '), ';
            result += this._super._super.toString();

            return result;
        }
    });

    return {
        circle: circle,
        rectangle: rectangle,
        triangle: triangle,
        line: line,
        segment: segment
    }
})();

circle = Object.create(shapesModule.circle);
circle.init(0, 0, 15, 'AAA');
console.log(circle.toString());

rect = Object.create(shapesModule.rectangle);
rect.init(0, 0, 15, 10, 'BBB');
console.log(rect.toString());

triangle = Object.create(shapesModule.triangle);
triangle.init(0, 0, 1, 1, 5, 10, 'CCC');
console.log(triangle.toString());

line = Object.create(shapesModule.line);
line.init(0, 0, 3, 5, 'DDD');
console.log(line.toString());

segment = Object.create(shapesModule.segment);
segment.init(1, 1, 10, 20, 'EEE');
console.log(segment.toString());