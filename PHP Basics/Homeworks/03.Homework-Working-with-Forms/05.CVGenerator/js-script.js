var computerList = document.getElementById('computer-skills-list');
var languageList = document.getElementById('languages-list');

function addLanguage(list) {

    if (list == 'computer') {
        var liItems = document.querySelectorAll('#computer-skills-list > li');
        var newID = 0;
        if (liItems.length > 0) {
            var oldID = liItems[liItems.length - 1].id.substr(8);
            newID = parseInt(oldID) + 1;
        }

        var li = document.createElement('li');
        li.setAttribute('id', 'computer' + newID);

        var input = document.createElement('input');
        input.setAttribute('type', 'text');
        input.setAttribute('name', 'prog-lang[]');
        input.setAttribute('id', 'prog-lang' + newID);

        var select = document.createElement('select');
        select.setAttribute('name', 'prog-lang-level[]');
        var opt0 = document.createElement('option');
        opt0.setAttribute('value', 'Beginner');
        opt0.innerHTML = 'Beginner';
        var opt1 = document.createElement('option');
        opt1.setAttribute('value', 'Intermediate');
        opt1.innerHTML = 'Intermediate';
        var opt2 = document.createElement('option');
        opt2.setAttribute('value', 'Expert');
        opt2.innerHTML = 'Expert';
        var opt3 = document.createElement('option');
        opt3.setAttribute('value', 'Guru');
        opt3.innerHTML = 'Guru';
        select.appendChild(opt0);
        select.appendChild(opt1);
        select.appendChild(opt2);
        select.appendChild(opt3);

        var button = document.createElement('button');
        button.setAttribute('class', 'remove');
        button.setAttribute('type', 'button');
        button.setAttribute('onclick', 'removeLanguage("computer", '+ newID + ')');
        button.innerHTML = '[X]';

        li.appendChild(input);
        li.appendChild(select);
        li.appendChild(button);
        computerList.appendChild(li);
    } else {
        var newID = 0;
        var liItems = document.querySelectorAll('#languages-list > li');

        if (liItems.length > 0) {
            var oldID = liItems[liItems.length - 1].id.substr(8);
            newID = parseInt(oldID) + 1;
        }


        var li = document.createElement('li');
        li.setAttribute('id', 'language' + newID);

        var input = document.createElement('input');
        input.setAttribute('type', 'text');
        input.setAttribute('name', 'langs[]');
        input.setAttribute('id', 'langs' + newID);
        li.appendChild(input);

        var select = document.createElement('select');
        select.setAttribute('name', 'langs-comprehension[]');
        var optDef = document.createElement('option');
        optDef.setAttribute('value', 'Beginner');
        optDef.innerHTML = '-Comprehension-';
        var opt0 = document.createElement('option');
        opt0.setAttribute('value', 'Beginner');
        opt0.innerHTML = 'Beginner';
        var opt1 = document.createElement('option');
        opt1.setAttribute('value', 'Intermediate');
        opt1.innerHTML = 'Intermediate';
        var opt2 = document.createElement('option');
        opt2.setAttribute('value', 'Expert');
        opt2.innerHTML = 'Expert';
        select.appendChild(optDef);
        select.appendChild(opt0);
        select.appendChild(opt1);
        select.appendChild(opt2);
        li.appendChild(select);

        var select = document.createElement('select');
        select.setAttribute('name', 'langs-reading[]');
        var optDef = document.createElement('option');
        optDef.setAttribute('value', 'Beginner');
        optDef.innerHTML = '-Reading-';
        var opt0 = document.createElement('option');
        opt0.setAttribute('value', 'Beginner');
        opt0.innerHTML = 'Beginner';
        var opt1 = document.createElement('option');
        opt1.setAttribute('value', 'Intermediate');
        opt1.innerHTML = 'Intermediate';
        var opt2 = document.createElement('option');
        opt2.setAttribute('value', 'Expert');
        opt2.innerHTML = 'Expert';
        select.appendChild(optDef);
        select.appendChild(opt0);
        select.appendChild(opt1);
        select.appendChild(opt2);
        li.appendChild(select);

        var select = document.createElement('select');
        select.setAttribute('name', 'langs-writing[]');
        var optDef = document.createElement('option');
        optDef.setAttribute('value', 'Beginner');
        optDef.innerHTML = '-Writing-';
        var opt0 = document.createElement('option');
        opt0.setAttribute('value', 'Beginner');
        opt0.innerHTML = 'Beginner';
        var opt1 = document.createElement('option');
        opt1.setAttribute('value', 'Intermediate');
        opt1.innerHTML = 'Intermediate';
        var opt2 = document.createElement('option');
        opt2.setAttribute('value', 'Expert');
        opt2.innerHTML = 'Expert';
        select.appendChild(optDef);
        select.appendChild(opt0);
        select.appendChild(opt1);
        select.appendChild(opt2);
        li.appendChild(select);

        var button = document.createElement('button');
        button.setAttribute('class', 'remove');
        button.setAttribute('type', 'button');
        button.setAttribute('onclick', 'removeLanguage("language", '+ newID + ')');
        button.innerHTML = '[X]';
        li.appendChild(button);

        languageList.appendChild(li);
    }

}

function removeLanguage(list, id) {
    if (list == 'computer') {
        var child = document.getElementById('computer' + id);
        computerList.removeChild(child);
    } else {
        var child = document.getElementById('language' + id);
        languageList.removeChild(child);
    }
}