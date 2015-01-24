<?php

$names = preg_split("/\r?\n/", trim($_GET['list']), -1, PREG_SPLIT_NO_EMPTY);
$minLength = intval($_GET['length']);

$result = "<ul>";

foreach ($names as $name) {
    $name = trim($name);

    if (strlen($name) >= $minLength) {
        $result .= "<li>" . htmlspecialchars($name) . "</li>";
    } else if (isset($_GET['show'])) {
        $result .= "<li style=\"color: red;\">" . htmlspecialchars($name) . "</li>";
    }
}

$result .= "</ul>";

echo $result;
