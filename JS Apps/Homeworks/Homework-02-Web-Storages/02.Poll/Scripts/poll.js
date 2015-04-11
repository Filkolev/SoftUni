$(document).ready(function () {
    var timerDiv = $('#timer'),
        timeAllowed = 5 * 60,
        counter;

    function saveData() {
        if (!localStorage.saved && localStorage.length) {
            localStorage.saved = true;
            localStorage.js = $("input[name=js]:checked").val();
            localStorage.csharp = $("input[name=csharp]:checked").val();
            localStorage.jsCorrect = '0.3';
            localStorage.csharpCorrect = '4';
        }
    }

    function loadSavedData() {
        switch (localStorage.js) {
            case '0':
                $('#js-0').attr('checked', true);
                break;
            case 'NaN':
                $('#js-nan').attr('checked', true);
                break;
            case '2.3':
                $('#js-2-3').attr('checked', true);
                break;
            case 'undefined':
                $('#js-undefined').attr('checked', true);
                break;
        }

        switch (localStorage.csharp) {
            case '4':
                $('#csharp-4').attr('checked', true);
                break;
            case '5':
                $('#csharp-5').attr('checked', true);
                break;
            case 'It depends':
                $('#csharp-depends').attr('checked', true);
                break;
            case 'There is no such method':
                $('#csharp-no-method').attr('checked', true);
                break;
        }
    }

    function countdown() {
        var minutes,
            seconds;

        localStorage.count--;

        if (localStorage.count < 0) {
            clearInterval(counter);
            return;
        }

        minutes = Math.floor(localStorage.count / 60);
        if (minutes < 10) {
            minutes = '0' + minutes;
        }

        seconds = Math.floor(localStorage.count % 60);
        if (seconds < 10) {
            seconds = '0' + seconds;
        }

        timerDiv.text(minutes + ':' + seconds);
    }

    function timeExpired() {
        timerDiv.css('color', 'red');
        $('button').attr('disabled', true);
    }

    function showResults() {
        var timeElapsed = timeAllowed - localStorage.count,
            cSharpSubmitted = $('#csharp-answer-submitted'),
            jsSubmitted = $('#js-answer-submitted'),
            minutes,
            seconds;

        clearInterval(counter);
        $('form').hide();
        timerDiv.hide();

        if (!localStorage.submitted) {
            saveData();
        }

        cSharpSubmitted.prepend('Your answer: ' + localStorage.csharp);
        $('#csharp-answer-correct').text('Correct answer: ' + localStorage.csharpCorrect);

        if (localStorage.csharp === localStorage.csharpCorrect) {
            cSharpSubmitted.find('.correct-msg').show();
            cSharpSubmitted.css('color', 'green');
        } else {
            cSharpSubmitted.find('.incorrect-msg').show();
            cSharpSubmitted.css('color', 'red');
        }

        jsSubmitted.prepend('Your answer: ' + localStorage.js);
        $('#js-answer-correct').text('Correct answer: ' + localStorage.jsCorrect);

        if (localStorage.js === localStorage.jsCorrect) {
            jsSubmitted.find('.correct-msg').show();
            jsSubmitted.css('color', 'green');
        } else {
            jsSubmitted.find('.incorrect-msg').show();
            jsSubmitted.css('color', 'red');
        }

        $('#answers').show();

        minutes = Math.floor(timeElapsed / 60);
        if (minutes < 10) {
            minutes = '0' + minutes;
        }

        seconds = Math.floor(timeElapsed % 60);
        if (seconds < 10) {
            seconds = '0' + seconds;
        }

        $('#time-elapsed').append(minutes + ':' + seconds);

        localStorage.submitted = true;
    }

    if (!localStorage.submitted) {
        if (!localStorage.count) {
            localStorage.count = timeAllowed;
        } else if (localStorage.count < 0) {
            timeExpired();
        }

        counter = setInterval(countdown, 1000);

        if (localStorage.saved) {
            loadSavedData();
        }
    } else {
        showResults();
    }

    $('button').click(saveData, showResults);

    window.onbeforeunload = saveData;
});