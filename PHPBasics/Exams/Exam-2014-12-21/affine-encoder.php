<?php
$input = json_decode($_GET['jsonTable']);

$words = $input[0];
$k = $input[1][0];
$s = $input[1][1];
$m = 26;

$matrixWidth = 0;

foreach ($words as $word) {
    if (strlen($word) > $matrixWidth) {
        $matrixWidth = strlen($word);
    }
}

if ($matrixWidth == 0) {
    $matrixWidth = 1;
}

$result = "<table border='1' cellpadding='5'>";

for ($row = 0; $row < count($words); $row++) {
    $currentWord = str_pad($words[$row], $matrixWidth);

    $result .= "<tr>";

    for ($col = 0; $col < $matrixWidth; $col++) {
        if (ctype_space($currentWord[$col])) {
            $result .= "<td></td>";
        }
        else if (ctype_alpha($currentWord[$col])) {
            $x = ord(strtolower($currentWord[$col])) - ord("a");
            $char = ($k * $x + $s) % $m + ord("A");
            $letter = chr($char);
            $result .= "<td style='background:#CCC'>". $letter ."</td>";
        }
        else {
            $result .= "<td style='background:#CCC'>".htmlspecialchars($currentWord[$col])."</td>";
        }
    }

    $result .= "</tr>";
}

$result .= "</table>";

echo $result;