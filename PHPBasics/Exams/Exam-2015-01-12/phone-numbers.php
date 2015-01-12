<?php

$numbersString = $_GET['numbersString'];
$numbersString = preg_replace("/\s+/", "", $numbersString);
$pattern = "/([A-Z][A-Za-z]*)(?:[^+a-zA-Z]*?)(\+?(?=\d)[\d()\/.\- ]{2,})/";

preg_match_all($pattern, $numbersString, $matches, PREG_SET_ORDER);
$result = array();

foreach ($matches as $match) {
    $name = $match[1];

    if (strlen(preg_replace("/[^\d+]+/", "", $match[2])) < 2) {
        continue;
    }

    $result[] = [$name, $match[2]];
}

if (count($result) == 0) {
    echo "<p>No matches!</p>";
} else {
    $toPrint = "<ol>";
    foreach ($result as $entry) {
        $entry[1] = preg_replace("/[^\d+]+/", "", $entry[1]);
        $toPrint .= "<li><b>". ($entry[0]) .":</b> ". ($entry[1]) ."</li>";
    }

    $toPrint .= "</ol>";
}

echo $toPrint;