<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8"/>
    <title>Sum of Digits</title>
    <style>
        form, table {
            width: 500px;
            margin: 10px auto;
        }

        table, th, td, tr {
            border: 1px solid black;
        }
    </style>
</head>

<body>
<form action="05.SumOfDigits.php" method="post">
    <label for="input-field">Input string: </label>
    <input type="text" name="numbers" id="input-field">
    <input type="submit" name="submit" id="submit" value="Show result">
</form>

<?php

if (isset($_POST['submit']) && $_POST['numbers'] != ''):
    $numbers = explode(", ", $_POST['numbers']); ?>
    <table>
        <?php
        foreach ($numbers as $num):
        $sumOfDigits = 0; ?>
        <tr>
            <td><?php echo $num ?></td>
            <td>
                <?php if (is_numeric($num)):
                    while ($num > 0) {
                        $sumOfDigits += $num % 10;
                        $num /= 10;
                    }

                    echo $sumOfDigits;

                else:
                    echo "I cannot sum that";
                endif; ?>
            </td>
        </tr>
        <?php endforeach; ?>
    </table>
<?php endif; ?>
</body>
</html>