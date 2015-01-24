<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Non-Repeating Digits</title>
</head>
<body>
    <div>
        <?php
        date_default_timezone_set("Europe/Sofia");
        $month =  date('m');
        $year = date('Y');

        $sundays = getSundays($month, $year);

        function getSundays($month, $year) {
            $sun = strtotime('first Sunday of ' . $month . $year);
            $sundays = array();

            do {
                $sundays[] = new DateTime(date('r', $sun));
                $sun = strtotime('+7 days', $sun);
            } while (date('m', $sun) == $month);

            return $sundays;
        }

        foreach ($sundays as $sunday) {
            echo $sunday->format('jS F, Y') . "<br />\n";
        }
        ?>
    </div>
</body>
</html>