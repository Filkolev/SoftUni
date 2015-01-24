<?php
date_default_timezone_set('UTC');

$list = preg_split("/\r?\n/", trim($_GET['list']), -1, PREG_SPLIT_NO_EMPTY);
$currentDate = new DateTime($_GET['currDate']);
$dates = array();

foreach ($list as $entry) {
    try {
        $dates[] = new DateTime(trim($entry));
    } catch (Exception $e) {
        continue;
    }
}

sort($dates);

$result = "<ul>";

foreach ($dates as $date) {
    if ($date < $currentDate) {
        $result .= "<li><em>" . $date->format("d/m/Y") . "</em></li>";
    } else {
        $result .= "<li>" . $date->format("d/m/Y") . "</li>";
    }
}

$result .= "</ul>";
echo $result;