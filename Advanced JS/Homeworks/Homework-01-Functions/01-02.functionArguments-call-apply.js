function printArgsInfo() {
    if (arguments.length === 0) {
        console.log("No arguments.");
    }

    for (var i in arguments) {
        if (arguments.hasOwnProperty(i)) {
            var type = typeof (arguments[i]);

            if (Array.isArray(arguments[i])) {
                type = "array";
            }

            console.log(arguments[i] + " (" + type + ")");
        }
    }
}

console.log("Problem 1. Function arguments:");
printArgsInfo(2, 3, 2.5, -110.5564, false);
printArgsInfo(null, undefined, "", 0, [], {});
printArgsInfo([1, 2], ["string", "array"], ["single value"]);
printArgsInfo("some string", [1, 2], ["string", "array"], ["mixed", 2, false, "array"], { name: "Peter", age: 20 });
printArgsInfo([[1, [2, [3, [4, 5]]]], ["string", "array"]]);
console.log("\n\n");


console.log("Problem 2. call() and apply()");
printArgsInfo.call(null);
printArgsInfo.call(null, 2, NaN, undefined);

printArgsInfo.apply(null);
printArgsInfo.apply(null, [[1, 2]]);
console.log("\n\n");