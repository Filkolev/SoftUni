var obj = {
    info: 'the value of "this" is set to the object the function was called from.'
};

function testContext() {
    'use strict';

    console.log(this);
}

function outer() {
    'use strict';

    function inner() {
        testContext();
    }

    inner();
}

console.log('Global context:');
testContext();

console.log('From within another function:');
outer();

console.log('From within an object:');
testContext.call(obj);