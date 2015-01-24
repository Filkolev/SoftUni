<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8"/>
    <title>Primes In Range</title>
    <style>
        body {
            padding: 20px;
        }

        div {
            margin: 20px auto;
            width: 700px;
            display: block;
        }
        form {
            margin: 0 auto;
            text-align: center;
        }
    </style>
</head>

<body>
    <form action="04.PrimesInRange.php" method="post">
        <label for="start">Start Number: </label>
        <input type="text" name="start" id="start" required="required">
        <label for="end">End number: </label>
        <input type="text" name="end" id="end" required="required">
        <input type="submit" name="submit" id="submit">
    </form>

    <div>
        <?php
        function isPrime($num)
        {
            if ($num < 2) {
                return false;
            } else if ($num == 2) {
                return true;
            } else {
                for ($divisor = 2; $divisor <= (int)sqrt($num); $divisor++) {
                    if ($num % $divisor == 0) {
                        return false;
                    }
                }
            }
            return true;
        }

        if (isset($_POST['submit'])
            && $_POST['start'] != ''
            && $_POST['end'] != ''
            && is_numeric($_POST['start'])
            && is_numeric($_POST['end'])):

            $start = $_POST['start'];
            $end = $_POST['end'];

            for ($i = $start; $i <= $end; $i++):
                if (isPrime($i)): ?>
                    <strong><?php echo $i ?></strong>
                <?php else:
                    echo $i;
                endif;
                if ($i != $end):
                    echo ", ";
                endif;
            endfor;
        endif;
        ?>
    </div>
</body>
</html>