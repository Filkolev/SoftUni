<?php
$input = json_decode($_GET['jsonTable']);
$numberOfCols = $input[0];
$messages = $input[1];

$pattern = "/Reply from \d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}: bytes=\d+ time=(\d+)ms TTL=\d+/";
$string = "";

for ($i = 1; $i < count($messages); $i++) {
    preg_match_all($pattern, $messages[$i], $milliseconds);
    $string .= chr($milliseconds[1][0]);
}

$result = "<table border='1' cellpadding='5'>";
$index = 0;

while ($index < strlen($string)) {
    $result .= "<tr>";
    $lineEnded = false;

    for ($col = 0; $col < $numberOfCols; $col++) {
        if ($index >= strlen($string) || $lineEnded) {
            $result .= "<td></td>";
        }
        else if ($string[$index] == "*") {
            $result .= "<td></td>";
            $index++;
            $lineEnded = true;
        }
        else if (!ctype_space($string[$index])) {
            $result .= "<td style='background:#CAF'>" . htmlspecialchars($string[$index]) ."</td>";
            $index++;
        }
        else {
            $result .= "<td></td>";
            $index++;
        }
    }

    $result .= "</tr>";
}

$result .= "</table>";
echo $result;