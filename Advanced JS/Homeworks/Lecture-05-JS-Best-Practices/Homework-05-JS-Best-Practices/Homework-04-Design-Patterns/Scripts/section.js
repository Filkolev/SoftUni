var toDoList = toDoList || {};

(function (scope) {
    'use strict';

    function checkTitle(title) {
        if (!title) {
            throw new Error('The title of a section cannot be empty.');
        }
    }

    function Section(title) {
        checkTitle(title);
        this._title = title;
        this._internalListItem = scope._createListItem('internal');
    }

    Section.prototype.getDomElement = function () {
        var section = document.createElement('section'),
            div = document.createElement('div'),
            heading = document.createElement('h2'),
            input = document.createElement('input'),
            button = document.createElement('button');

        div.className = 'listContainer';

        heading.innerHTML = this._title;

        input.type = 'text';
        input.placeholder = 'Add Item...';
        input.title = 'Enter the name of the new item.';
        input.required = 'required';
        input.name = 'itemName';

        button.innerHTML = '+';
        button.name = 'addItemButton';
        button.addEventListener('click', this._internalListItem.addToDOM);

        div.appendChild(heading);

        section.appendChild(div);
        section.appendChild(input);
        section.appendChild(button);

        this._domElement = section;
    }

    Section.prototype.addToDOM = function () {
        var parent = event.target.parentNode,
            title = parent.querySelector('input[name=sectionName]').value,
            wrapper = document.querySelector('#sectionWrapper'),
            section = new Section(title);

        Section.prototype.getDomElement.call(section);

        wrapper.appendChild(section._domElement);
    }

    scope._createSection = function (title) {
        return new Section(title);
    }
})(toDoList);