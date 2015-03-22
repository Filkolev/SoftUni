var toDoList = toDoList || {};

(function (scope) {
    function Container(title) {
        this._title = title;
    }

    Container.prototype.addNewSection = function (event) {
        var parent = event.target.parentNode,
            title = parent.querySelector('input[name=sectionName]').value,
            wrapper = document.querySelector('#sectionWrapper'),
            newSection = toDoList._createSection(title).getDomElement();

        wrapper.appendChild(newSection);
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
        button.addEventListener('click', Container.prototype.addNewSection);

        container.appendChild(heading);
        container.appendChild(sectionWrapper)
        container.appendChild(input)
        container.appendChild(button);

        return container;
    }

    scope._createToDoList = function (title) {
        return new Container(title);
    }

})(toDoList);