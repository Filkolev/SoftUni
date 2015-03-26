var liElement,
    elements;

var domModule = (function () {
    'use strict';

    function getParent(parent) {
        if (!(parent instanceof Element) && !Array.isArray(parent)) {
            parent = document.querySelectorAll(parent);
        }

        if (!parent) {
            throw new ReferenceError('Parent element is invalid or could not be found.');
        }

        return parent;
    }

    function getChild(parent, child) {
        var children = [],
            currentChildren = [],
            i,
            j;

        if (child instanceof Element) {
            return child;
        }

        for (i = 0; i < parent.length; i += 1) {
            currentChildren = parent[i].querySelectorAll(child);

            for (j = 0; j < currentChildren.length; j += 1) {
                children.push(currentChildren[j]);
            }
        }

        if (!currentChildren) {
            throw new ReferenceError('Child element is invalid or could not be found.');
        }

        return currentChildren;
    }

    function appendChild(parent, child) {
        var i,
            j;

        parent = getParent(parent);
        child = getChild(parent, child);

        if (parent.nodeType === 1 & child.nodeType === 1) {
            parent.appendChild(child);
        } else if (parent.nodeType === 1) {
            for (i = 0; i < child.length; i += 1) {
                parent.appendChild(child[i]);
            }
        } else if (child.nodeType === 1) {
            for (i = 0; i < parent.length; i += 1) {
                parent[i].appendChild(child.cloneNode());
            }
        } else {
            for (i = 0; i < parent.length; i += 1) {
                for (j = 0; j < child.length; j += 1) {
                    parent[i].appendChild(child[j].cloneNode());
                }
            }
        }
    }

    function removeChild(parent, child) {
        var i,
            j,
            k,
            l;

        parent = getParent(parent);
        child = getChild(parent, child);

        if (parent.nodeType === 1 & child.nodeType === 1) {
            parent.removeChild(child);
        } else if (parent.nodeType === 1) {
            for (i = 0; i < child.length; i += 1) {
                parent.removeChild(child[i]);
            }
        } else if (child.nodeType === 1) {
            for (j = 0; j < parent.length; j += 1) {
                parent[j].removeChild(child);
            }
        } else {
            for (k = 0; k < parent.length; k += 1) {
                for (l = 0; l < child.length; l += 1) {
                    parent[k].removeChild(child[l]);
                }
            }
        }
    }

    function retrieveElements(selector) {
        return document.querySelectorAll(selector);
    }

    function addHandler(elements, eventType, eventHandler) {
        var i;

        if (!(elements instanceof Element) && !Array.isArray(elements)) {
            elements = retrieveElements(elements);
        }

        if (!elements) {
            throw new ReferenceError('The element(s) requested could not be found.');
        }

        for (i in elements) {
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

liElement = document.createElement('li');
domModule.appendChild('.birds-list', liElement);
domModule.removeChild('ul.birds-list', 'li:first-child'); // Throws error, don't really care to fix it
domModule.addHandler('li.bird', 'click', function () { alert('I\'m a bird!') });
elements = domModule.retrieveElements('.bird');