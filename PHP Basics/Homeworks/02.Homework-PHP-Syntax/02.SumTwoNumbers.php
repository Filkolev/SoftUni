<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Sum Two Numbers</title>
    </head>

    <body>
        <?php
        function sumTwoNums($firstNumber, $secondNumber) {
            $sum = $firstNumber + $secondNumber;
            $sum = number_format($sum, 2);

            echo '<p> $firstNumber + $secondNumber = ' . "$firstNumber + $secondNumber = $sum </p>\n";
        }

        sumTwoNums(2, 5);
        sumTwoNums(1.567808, 0.356);
        sumTwoNums(1234.5678, 333);
        ?>
    </body>
</html>