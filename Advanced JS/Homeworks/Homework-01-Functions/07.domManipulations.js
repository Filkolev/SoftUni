var domModule = (function () {

    var getElement = function (selector) {
        return document.querySelector(selector);
    }

    function appendChild(parent, child) {
        if (!(parent instanceof Element)) {
            parent = getElement(parent);
        }

        if (!parent) {
            throw new ReferenceError("Parent element is invalid or could not be found.");
        }

        if (!(child instanceof Element)) {
            child = getElement(parent);
        }

        if (!child) {
            throw new ReferenceError("Child element is invalid or could not be found.");
        }

        parent.appendChild(child);
    }

    function removeChild(parent, child) {
        if (!(parent instanceof Element)) {
            parent = getElement(parent);
        }

        if (!parent) {
            throw new ReferenceError("Parent element is invalid or could not be found.");
        }

        if (!(child instanceof Element)) {
            child = getElement(child);
        }

        if (!child) {
            throw new ReferenceError("Child element is invalid or could not be found.");
        }

        parent.removeChild(child);
    }

    function retrieveElements(selector) {
        return document.querySelectorAll(selector);
    }

    function addHandler(elements, eventType, eventHandler) {
        if (!(elements instanceof Element) && !Array.isArray(elements)) {
            elements = retrieveElements(elements);
        }

        if (!elements) {
            throw new ReferenceError("The element(s) requested could not be found.");
        }

        for (var i in elements) {
            if (elements[i] instanceof HTMLElement) {
                elements[i].addEventListener(eventType, eventHandler, false);
            }
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    }

})();

var liElement = document.createElement("li");

domModule.appendChild(".birds-list", liElement);

domModule.removeChild("ul.birds-list", "li:first-child");

domModule.addHandler("li.bird", "click", function () { alert("I'm a bird!") });

var elements = domModule.retrieveElements(".bird");
