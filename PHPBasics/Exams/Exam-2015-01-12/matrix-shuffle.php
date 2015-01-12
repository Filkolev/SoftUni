<?php
$text = $_GET['text'];
$size = intval($_GET['size']);

$matrix = array();
$index = 0;

for ($i = 0; $i < $size; $i++) {
    $matrix[$i] = array();

    for ($j = 0; $j < $size; $j++) {
        $matrix[$i][$j] = false;
    }
}

$row = 0;
$col = 0;

while ($index < $size * $size){
    while ($col < $size && $matrix[$row][$col] === false) {
        $matrix[$row][$col] = $text[$index];
        $index++;
        $col++;
    }

    $row++;
    $col--;

    while ($row < $size && $matrix[$row][$col] === false) {
        $matrix[$row][$col] = $text[$index];
        $index++;
        $row++;
    }

    $row--;
    $col--;

    while ($col >= 0 && $matrix[$row][$col] === false) {
        $matrix[$row][$col] = $text[$index];
        $index++;
        $col--;
    }

    $col++;
    $row--;

    while ($row >= 0 && $matrix[$row][$col] === false) {
        $matrix[$row][$col] = $text[$index];
        $index++;
        $row--;
    }

    $row++;
    $col++;
};

$string = "";

for ($row = 0; $row < $size; $row++) {
    for ($col = 0; $col < $size; $col++) {
        if ($row % 2 == 0 && $col % 2 == 0) {
            $string .= $matrix[$row][$col];
        }

        if ($row % 2 == 1 & $col % 2 == 1) {
            $string .= $matrix[$row][$col];
        }
    }
}

for ($row = 0; $row < $size; $row++) {
    for ($col = 0; $col < $size; $col++) {
        if ($row % 2 == 0 && $col % 2 == 1) {
            $string .= $matrix[$row][$col];
        }

        if ($row % 2 == 1 & $col % 2 == 0) {
            $string .= $matrix[$row][$col];
        }
    }
}

$checkString = preg_replace("/[^a-zA-Z]+/", "", $string);
$checkString = strtolower($checkString);

if ($checkString == strrev($checkString)) {
    echo "<div style='background-color:#4FE000'>" . htmlspecialchars($string) . "</div>";
} else {
    echo "<div style='background-color:#E0000F'>" . htmlspecialchars($string) . "</div>";
}