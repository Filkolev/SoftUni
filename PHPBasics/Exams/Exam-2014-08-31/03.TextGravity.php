<?php
$text = $_GET['text'];
$lineLength = $_GET['lineLength'];

$matrix = array();
$index = 0;
$height = (int)ceil(strlen($text) / $lineLength);

for ($i = 0; $i < $height; $i++) {
    $matrix[$i] = array();

    for ($j = 0; $j < $lineLength; $j++) {
        if ($index >= strlen($text)) {
            $matrix[$i][] = " ";
        } else {
            $matrix[$i][] = $text[$index];
        }

        $index++;
    }
}

for ($row = $height - 2; $row >= 0; $row--) {
    for ($col = 0; $col < $lineLength; $col++) {
        $hitBottom = false;
        $currentRow = $row;

        while (!$hitBottom && $currentRow < $height - 1) {
            if ($matrix[$currentRow][$col] != " " && $matrix[$currentRow + 1][$col] == " ") {
                $matrix[$currentRow + 1][$col] = $matrix[$currentRow][$col];
                $matrix[$currentRow][$col] = " ";
            } else {
                $hitBottom = true;
            }

            $currentRow++;
        }
    }
}

$result = "<table>";

for ($row = 0; $row < $height; $row++) {
    $result .= "<tr>";

    for ($col = 0; $col < $lineLength; $col++) {
        $result .= "<td>" . htmlspecialchars($matrix[$row][$col]) . "</td>";
    }

    $result .= "</tr>";
}

$result .= "<table>";

echo $result;