$(document).ready(function () {
    'use strict';

    function createTableFromJSON() {
        var tableContainer = $('#tableContainer'),
            carInfo = $.parseJSON($('#input').val()),
            titles,
            table,
            thead,
            tbody;

        function getHeaderTitles(carInfo) {
            var titles = [];

            $.each(carInfo, function (index, value) {
                var carProps =  Object.keys(value).map(function (title) {
                    return title.toLocaleLowerCase();
                });

                $.merge(titles, carProps);
            });

            return titles.filter(function (item, index) {
                return titles.indexOf(item) === index;
            });
        }

        function getTableHeader(titles) {
            var header = $('<tr>'),
                cell;

            $.each(titles, function (index, value) {
                cell = $('<th>').text(value);
                header.append(cell);
            });

            return header;
        }

        function getTableRow(titles, car) {
            var tableRow = $('<tr>'),
                cell;

            $.each(titles, function (index, title) {
                if (car[title]) {
                    cell = $('<td>').text(car[title]);
                } else {
                    cell = $('<td>').text('N/A');
                }

                tableRow.append(cell);
            });

            return tableRow;
        }

        tableContainer.html('');

        titles = getHeaderTitles(carInfo);
        table = $('<table>');

        thead = $('<thead>').append(getTableHeader(titles));

        tbody = $('<tbody>');
        $.each(carInfo, function (index, car) {
            tbody.append(getTableRow(titles, car));
        });

        table.append(thead).append(tbody);

        tableContainer.append(table);
    }

    $('#generateButton').click(createTableFromJSON);
});