<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8"/>
    <title>Square Root Sum</title>
    <style>
        body {
            font-size: 2em;
        }
        table, tr, td, th {
            border: 1px solid black;
            padding: 5px;
        }
        table {
            width: 200 px;
            margin: 10px auto;
        }
        .bold {
            font-weight: bold;
        }
    </style>
</head>

<body>
    <table>
        <thead>
        <tr>
            <th>Number</th>
            <th>Root</th>
        </tr>
        </thead>

        <tbody>
        <?php

        for ($i = 0; $i <= 100; $i += 2) {
            $square = round(sqrt($i), 2);
            $sum += $square;
            echo "<tr><td>$i</td><td>$square</td></tr>";
        }

        echo "<tr><td class=\"bold\">Total:</td><td>$sum</td></tr>";
        ?>
        </tbody>
    </table>
</body>
</html>


