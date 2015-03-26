var toDoList = toDoList || {};

(function (scope) {
    'use strict';

    function Container(title) {
        this._title = title;
        this._internalSection = scope._createSection('internal');
    }

    Container.prototype.getDomElement = function () {
        var container = document.createElement('section'),
            heading = document.createElement('h1'),
            sectionWrapper = document.createElement('section'),
            input = document.createElement('input'),
            button = document.createElement('button');

        container.id = 'listWrapper';

        sectionWrapper.id = 'sectionWrapper';

        heading.innerHTML = this._title;

        input.type = 'text';
        input.placeholder = 'Title';
        input.required = 'required';
        input.name = 'sectionName';

        button.innerHTML = 'New Section';
        button.name = 'addSectionButton';
        button.addEventListener('click', this._internalSection.addToDOM);

        container.appendChild(heading);
        container.appendChild(sectionWrapper)
        container.appendChild(input)
        container.appendChild(button);

        this._domElement = container;
    }

    Container.prototype.addToDOM = function () {
        var body = document.body;
        this.getDomElement();

        body.appendChild(this._domElement);
    }

    scope._createToDoList = function (title) {
        return new Container(title);
    }

})(toDoList);