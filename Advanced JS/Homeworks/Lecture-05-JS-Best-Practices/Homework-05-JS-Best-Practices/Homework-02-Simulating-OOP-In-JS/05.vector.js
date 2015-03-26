var a,
    b,
    c,
    result;

var Vector = (function () {
    'use strict';

    function Vector(dimensions) {
        if (!dimensions || !Array.isArray(dimensions) || dimensions.length === 0) {
            throw new Error("A vector must have dimensions.");
        }

        this.dimensions = dimensions;
    }

    Vector.prototype.toString = function () {
        var result = '(' + this.dimensions.join(', ') + ')';

        return result;
    }

    Vector.prototype.add = function (other) {
        var resultDimensions = [],
            currentVectorDimensionsCount,
            i;

        if (!(other instanceof Vector)) {
            throw new Error('A vector can only be added with another vector.');
        }

        currentVectorDimensionsCount = this.dimensions.length;

        if (currentVectorDimensionsCount !== other.dimensions.length) {
            throw new Error('The two vectors should have the same number of dimensions.');
        }

        for (i = 0; i < currentVectorDimensionsCount; i += 1) {
            resultDimensions.push(this.dimensions[i] + other.dimensions[i]);
        }

        return new Vector(resultDimensions);
    }

    Vector.prototype.subtract = function (other) {
        var resultDimensions = [],
            currentVectorDimensionsCount,
            i;

        if (!(other instanceof Vector)) {
            throw new Error('A vector can only be added with another vector.');
        }

        currentVectorDimensionsCount = this.dimensions.length;

        if (currentVectorDimensionsCount !== other.dimensions.length) {
            throw new Error('The two vectors should have the same number of dimensions.');
        }

        for (i = 0; i < currentVectorDimensionsCount; i += 1) {
            resultDimensions.push(this.dimensions[i] - other.dimensions[i]);
        }

        return new Vector(resultDimensions);
    }

    Vector.prototype.dot = function (other) {
        var result = 0,
            currentVectorDimensionsCount = this.dimensions.length,
            i;

        if (currentVectorDimensionsCount !== other.dimensions.length) {
            throw new Error('The two vectors should have the same number of dimensions.');
        }

        for (i = 0; i < currentVectorDimensionsCount; i += 1) {
            result += this.dimensions[i] * other.dimensions[i];
        }

        return result;
    }

    Vector.prototype.norm = function () {
        var result = Math.sqrt(this.dot(this));

        return result;
    }

    return Vector;
})();

a = new Vector([1, 2, 3]);
b = new Vector([4, 5, 6]);
c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
console.log(a.toString());
console.log(c.toString());

// The following throw errors
//var wrong = new Vector();
//var anotherWrong = new Vector([]);

a = new Vector([1, 2, 3]);
b = new Vector([4, 5, 6]);
c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
result = a.add(b);
console.log(result.toString());
//a.add(c); // Error

a = new Vector([1, 2, 3]);
b = new Vector([4, 5, 6]);
c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
result = a.subtract(b);
console.log(result.toString());
//a.subtract(c); // Error

a = new Vector([1, 2, 3]);
b = new Vector([4, 5, 6]);
c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
result = a.dot(b);
console.log(result.toString());
//a.dot(c); // Error

a = new Vector([1, 2, 3]);
b = new Vector([4, 5, 6]);
c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
console.log(a.norm());
console.log(b.norm());
console.log(c.norm());
console.log(a.add(b).norm());