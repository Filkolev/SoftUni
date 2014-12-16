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
            width: 200px;
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
	$sum = 0;
    for ($i = 0; $i <= 100; $i += 2):
        $square = round(sqrt($i), 2);
        $sum += $square;
        ?>
        <tr><td><?php echo $i ?></td><td><?php echo $square ?></td></tr>        
    <?php endfor ?>
<tr><td class="bold">Total:</td><td><?php echo $sum ?></td></tr>
    </tbody>
</table>
</body>
</html>


