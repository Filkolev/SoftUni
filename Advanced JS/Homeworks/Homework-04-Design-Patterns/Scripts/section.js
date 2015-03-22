var toDoList = toDoList || {};

(function (scope) {
    function Section(title) {
        this._title = title;
    }

    Section.prototype.addNewItem = function (event) {
        var parent = event.target.parentNode,
            title = parent.querySelector('input[name=itemName]').value,
            container = parent.querySelector('.listContainer'),
            newListItem = toDoList._createListItem(title).getDomElement();       

        container.appendChild(newListItem);
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
        button.addEventListener('click', Section.prototype.addNewItem);

        div.appendChild(heading);

        section.appendChild(div);
        section.appendChild(input);
        section.appendChild(button);

        return section;
    }

    scope._createSection = function (title) {
        return new Section(title);
    }
})(toDoList);