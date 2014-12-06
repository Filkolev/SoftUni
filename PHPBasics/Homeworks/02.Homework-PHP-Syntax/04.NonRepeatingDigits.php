<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Non-Repeating Digits</title>
</head>
<body>
    <p>
        <?php
        function nonRepeatingDigits($N) {
            $max = min(999, $N);
            $result = array();

            for ($i = 102; $i <= $max; $i++) {
                $hundreds = floor($i / 100);
                $tens = floor($i / 10) % 10;
                $ones = $i % 10;

                if ($hundreds != $tens && $hundreds != $ones && $tens != $ones) {
                    array_push($result, $i);
                }
            }

            if (sizeof($result) > 0) {
                echo join(', ', $result);
            } else {
                echo 'No';
            }
            echo "<br /><br />\n";
        }

        nonRepeatingDigits(1234);
        nonRepeatingDigits(145);
        nonRepeatingDigits(15);
        nonRepeatingDigits(247);

        ?>
    </p>
</body>
</html>