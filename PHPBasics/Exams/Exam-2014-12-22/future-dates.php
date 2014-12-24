<?php
date_default_timezone_set("UTC");
$numbersString = $_GET['numbersString'];
$dateString = $_GET['dateString'];

$numberPattern = "/(?<=[^a-zA-Z\r\n\d])\d+(?=[^a-zA-Z\n])/";

preg_match_all($numberPattern, $numbersString, $numbers);

$sum = 0;

foreach ($numbers[0] as $num) {
    $sum += intval($num);
}

$sum = intval(strrev($sum));

$datesPattern = "/\d{4}-\d{2}-\d{2}/";

preg_match_all($datesPattern, $dateString, $dates);

$result = "";

for ($i = 0; $i < count($dates[0]); $i++) {
    $data = explode("-", $dates[0][$i]);
    $year = intval($data[0]);
    $month = intval($data[1]);
    $day = intval($data[2]);
    if (!checkdate ($month ,$day , $year )) {
        unset($dates[0][$i]);
    }
}

if (count($dates[0]) <= 0) {
    echo "<p>No dates</p>";
} else {
    $result .= "<ul>";

    foreach ($dates[0] as $date) {
        $date = new DateTime($date);
        $date->add(new DateInterval("P". $sum . "D"));
        $result .= "<li>" . $date->format('Y-m-d') . "</li>";
    }

    $result .= "</ul>";

    echo $result;
}