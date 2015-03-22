var toDoList = toDoList || {};

(function (scope) {
    var count = 0;

    function ListItem(content) {
        count++;
        this._content = content;
        this._completed = false;
    }

    ListItem.prototype.getDomElement = function () {
        var div = document.createElement('div'),
            checkbox = document.createElement('input'),
            label = document.createElement('label');

        checkbox.type = 'checkbox';
        checkbox.id = 'list-item-' + count;
        //checkbox.addEventListener('change', function () {
        //    this._completed = true;
        //});

        label.innerHTML = this._content;
        label.htmlFor = checkbox.id;

        div.appendChild(checkbox);
        div.appendChild(label);

        return div;
    }

    scope._createListItem = function (content) {
        return new ListItem(content);
    }
})(toDoList);