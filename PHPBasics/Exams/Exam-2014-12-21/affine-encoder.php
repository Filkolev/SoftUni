<?php

$table = json_decode($_GET['jsonTable']);

$strings = $table[0];
$k = $table[1][0];
$s = $table[1][1];

$width = 0;

foreach ($strings as $word) {
    if (strlen($word) > $width) {
        $width = strlen($word);
    }
}

if ($width == 0) {
    echo "<table border='1' cellpadding='5'><tr><td></td></tr></table>";
} else {
    $result = "<table border='1' cellpadding='5'>";
    
    foreach ($strings as $word) {
        $result .= "<tr>";
        $word = strtolower($word);
        
        for ($i = 0; $i < $width; $i++) {
            if ($i >= strlen($word) || ctype_space($word[$i])) {
                $result .= "<td></td>";
            } else if (ctype_alpha($word[$i])) {
                $x = ord($word[$i]) - ord('a');
                $newCharPos = ($k * $x + $s) % 26;
                $newChar = chr($newCharPos + ord('A'));
                $result .= "<td style='background:#CCC'>$newChar</td>";
            } else {
                $result .= "<td style='background:#CCC'>" . htmlspecialchars($word[$i]) . "</td>";
            }
        }

        $result .= "</tr>";
    }
    $result .= "</table>";
}

echo $result;
