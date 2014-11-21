var btn = document.getElementById('btnHideOddRows');

btn.addEventListener("click", function () {
    var oddRows = document.querySelectorAll('tr:nth-child(2n+1)');
    var btnValue = btn.innerHTML;

    if (btnValue == 'Hide Odd Rows') {
        btn.innerHTML = 'Show Odd Rows';
        for (var i = 0; i < oddRows.length; i += 1) {
            oddRows[i].style.display = 'none';
        }
    } else {
        btn.innerHTML = 'Hide Odd Rows';
        for (var i = 0; i < oddRows.length; i += 1) {
            oddRows[i].style.display = 'table-row';
        }
    }
});