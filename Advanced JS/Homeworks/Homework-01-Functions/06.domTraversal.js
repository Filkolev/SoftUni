var selector = ".birds";

function traverse(selector) {
    var element = document.querySelector(selector);

    var result = "";

    function traverseNode(node, spacing) {
        spacing = spacing || "\t";
        result += spacing + node.nodeName.toLocaleLowerCase() + ": ";

        var i;
        for (i = 0; i < node.attributes.length; i += 1) {
            result += node.attributes[i].name + "=\"" + node.attributes[i].value + "\" ";
        }

        result += "\n";

        for (i = 0; i < node.childNodes.length; i += 1) {
            var child = node.childNodes[i];
            if (child.nodeType === document.ELEMENT_NODE) {
                traverseNode(child, spacing + "\t");
            }
        }
    }

    traverseNode(element, "");

    console.log(result);

}

console.log("Problem 6. DOM Traversal");
traverse(selector);
console.log("\n\n");
