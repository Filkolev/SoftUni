var toDoList = toDoList || {};

(function (scope) {
    'use strict';

    var count = -2; // counter offset

    function checkContent(content) {
        if (!content) {
            throw new Error('The content of a list item cannot be empty.');
        }
    }

    function ListItem(content) {
        checkContent(content);
        count++;
        this._content = content;
    }

    ListItem.prototype.getDomElement = function () {
        var div = document.createElement('div'),
            checkbox = document.createElement('input'),
            label = document.createElement('label');

        checkbox.type = 'checkbox';
        checkbox.id = 'list-item-' + count;

        label.innerHTML = this._content;
        label.htmlFor = checkbox.id;

        div.appendChild(checkbox);
        div.appendChild(label);

        this._domElement = div;
    }

    ListItem.prototype.addToDOM = function (event) {
        var parent = event.target.parentNode,
            title = parent.querySelector('input[name=itemName]').value,
            container = parent.querySelector('.listContainer'),
            listItem = new ListItem(title),
            newListItem;

        listItem.getDomElement();
        newListItem = listItem._domElement;

        container.appendChild(newListItem);
    }

    scope._createListItem = function (content) {
        return new ListItem(content);
    }
})(toDoList);