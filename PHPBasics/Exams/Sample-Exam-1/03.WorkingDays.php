<?php

date_default_timezone_set("UTC");

$firstDate = DateTime::createFromFormat ("d-m-Y" , $_GET['dateOne']);
$secondDate = DateTime::createFromFormat ("d-m-Y" , $_GET['dateTwo']);

$holidays = array();
$holidayInfo = preg_split("/\r?\n/", $_GET['holidays'], -1, PREG_SPLIT_NO_EMPTY);

foreach ($holidayInfo as $holiday) {
    $holidays[] = DateTime::createFromFormat ("d-m-Y" , $holiday);
}

$results = array();

for ($i = $firstDate; $i <= $secondDate; $i->add(new DateInterval("P1D"))) {
    $dayOfWeek = $i->format("D");

    if (strcmp($dayOfWeek, "Sun") != 0 && strcmp($dayOfWeek, "Sat") != 0 && array_search($i, $holidays) === false) {
        $results[] = $i->format("d-m-Y");
    }
}

if (count($results) == 0) {
    echo "<h2>No workdays</h2>";
}
else {
    $toPrint = "<ol>";

    foreach ($results as $result) {
        $toPrint .= "<li>$result</li>";
    }

    $toPrint .= "</ol>";
    echo $toPrint;
}