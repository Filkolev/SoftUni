<?php
    
$text = $_GET['text'];
$hashValue = $_GET['hashValue'];
$fontSize = $_GET['fontSize'];
$fontStyle = $_GET['fontStyle'];

if ($fontStyle == 'bold') {
    $result = "<p style=\"font-size:$fontSize;font-weight:bold;\">";
}
else {
    $result = "<p style=\"font-size:$fontSize;font-style:$fontStyle;\">";
}

for ($i = 0; $i < strlen($text); $i++) {
    if ($i % 2 == 0) {
        $result .= chr(ord($text[$i]) + $hashValue);
    }
    else {
        $result .= chr(ord($text[$i]) - $hashValue);
    }
}

$result .= "</p>";

echo $result;