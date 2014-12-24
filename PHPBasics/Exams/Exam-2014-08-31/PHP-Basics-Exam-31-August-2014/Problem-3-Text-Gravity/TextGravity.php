<?php
$text = $_GET['text'];
$lineLength = $_GET['lineLength'];

// Fill the characters in the matrix
$textLength = strlen($text);
$rows = intval($textLength / $lineLength) + ($textLength % $lineLength == 0 ? 0 : 1);
$matrix = [];
$currentChar = 0;
for ($row = 0; $row < $rows; $row++) {
    $matrix[] = [];
    for ($col = 0; $col < $lineLength; $col++, $currentChar++) {
        if ($currentChar < strlen($text)) {
            $matrix[$row][$col] = $text[$currentChar];
        } else {
            $matrix[$row][$col] = " ";
        }
    }
}

// Fall down
$lastRow = count($matrix) - 1;
for ($p = $lastRow; $p > 0; $p--) {
    for ($col = 0; $col < $lineLength; $col++) {
        for ($row = $lastRow; $row > 0; $row--) {
            if ($matrix[$row][$col] == " ") {
                $matrix[$row][$col] = $matrix[$row - 1][$col];
                $matrix[$row - 1][$col] = " ";
            }
        }
    }
}

// Print the result as HTML table
echo "<table>";
for ($row = 0; $row < count($matrix); $row++) {
    echo "<tr>";
    for ($col = 0; $col < count($matrix[$row]); $col++) {
        echo "<td>" . htmlspecialchars($matrix[$row][$col]) . "</td>";
    }
    echo "</tr>";
}
echo "<table>";
