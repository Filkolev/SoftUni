<?php

$text = $_GET['text'];
$red = str_pad(dechex($_GET['red']), 2, '0', STR_PAD_LEFT);
$green = str_pad(dechex($_GET['green']), 2, '0', STR_PAD_LEFT);
$blue = str_pad(dechex($_GET['blue']), 2, '0', STR_PAD_LEFT);
$n = $_GET['nth'];

$color = "#" . $red . $green . $blue;
$result = "<p>";

for ($i = 0; $i < strlen($text); $i++) {
    if (($i + 1) % $n == 0) {
        $result .= "<span style=\"color: $color\">". htmlspecialchars($text[$i]) ."</span>";
    } else {
        $result .= htmlspecialchars($text[$i]);
    }
}

$result .= "</p>";
echo $result;
