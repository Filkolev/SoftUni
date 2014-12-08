<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8"/>
        <title>Car Randomizer</title>
        <style>
            body {
                width: 400px;
                margin: 10px auto;
            }
            table {
                margin: 20px auto;
            }
            table, tr, td, th {
                border: 1px solid black;
            }
        </style>
    </head>

    <body>
        <form action="02.CarRandomizer.php" method="post">
            <label for="input-field">Enter cars</label>
            <input type="text" name="cars" id="input-field">
            <input type="submit" name="submit" id="submit" value="Show result">
        </form>

        <?php
        $colors = ["white", "black", "blue", "yellow", "red", "purple", "gray", "green"];

        if (isset($_POST['submit']) && $_POST['cars'] != '') {
            echo "<table>";
            echo "<thead><tr><th>Car</th><th>Color</th><th>Count</th></tr></thead>";
            echo "<tbody>";
            $cars = explode(", ", $_POST['cars']);

            foreach ($cars as $car) {
                $color = $colors[rand(0, count($colors) - 1)];
                $count = rand(1, 5);
                echo "<tr><td>$car</td><td>$color</td><td>$count</td></tr>";
            }

            echo "</tbody>";
            echo "</table>";
        }
        ?>
    </body>
</html>


