var toDoList = toDoList || {};

var list = toDoList._createToDoList('Tuesday TODO List'),
    body = document.body;

body.appendChild(list.getDomElement());