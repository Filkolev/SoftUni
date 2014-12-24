<?php

$keysString = $_GET['keys'];
$text = $_GET['text'];

$keyPatternStart = "/^([a-zA-Z_]+?)\d/";
$keyPatternEnd = "/\d([a-zA-Z_]+)$/";

preg_match($keyPatternStart, $keysString, $startKey);
preg_match($keyPatternEnd, $keysString, $endKey);

if (count($startKey) == 0 || count($endKey) == 0) {
    echo "<p>A key is missing</p>";
}
else {
    $startKey = $startKey[1];
    $endKey = $endKey[1];

    $pattern = "/" . $startKey . "(.*?)" . $endKey . "/";
    preg_match_all($pattern, $text, $values);

    $sum = 0;
    foreach ($values[1] as $value) {
        $sum += floatval($value);
    }

    if ($sum == 0) {
        echo "<p>The total value is: <em>nothing</em></p>";
    }
    else {
        echo "<p>The total value is: <em>$sum</em></p>";
    }
}