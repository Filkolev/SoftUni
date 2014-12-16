<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8"/>
    <title>Annual Expenses</title>
    <style>
        body {
            width: 90%;
            margin: 10px auto;
        }
        table, form {
            margin: 20px auto;
        }
        form {
            text-align: center;
        }
        table, tr, td, th {
            border: 1px solid black;
            padding: 5px;
        }
    </style>
</head>

<body>
<form action="03.AnnualExpenses.php" method="post">
    <label for="input-field">Enter number of years</label>
    <input type="text" name="years" id="input-field">
    <input type="submit" name="submit" id="submit" value="Show expenses">
</form>

<?php
if (isset($_POST['submit']) && $_POST['years'] != ''):
    $count = $_POST['years'];
    date_default_timezone_set("Europe/Sofia");
    $year = date('Y'); ?>

    <table>
        <thead>
        <tr>
            <th>Year</th>
            <th>January</th>
            <th>February</th>
            <th>March</th>
            <th>April</th>
            <th>May</th>
            <th>June</th>
            <th>July</th>
            <th>August</th>
            <th>September</th>
            <th>October</th>
            <th>November</th>
            <th>December</th>
            <th>Total:</th>
        </tr>
        </thead>

        <tbody>

        <?php for ($i = $year; $i >= $year - $count + 1; $i--): ?>
            <tr>
            <td><?php echo $i ?></td>

            <?php $total = 0;
            for ($m = 0; $m <= 11; $m++):
                $expenses = rand(0, 999);
                $total += $expenses; ?>
                <td><?php echo $expenses ?></td>                
            <?php endfor; ?>
			<td><?php echo $total ?></td>
                </tr>
        <?php endfor; ?>
        </tbody>
    </table>
<?php  endif; ?>
</body>
</html>