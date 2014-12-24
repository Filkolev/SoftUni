<?php
$symbols = str_split($_GET['text']);
$minFontSize = $_GET['minFontSize'];
$maxFontSize = $_GET['maxFontSize'];
$step = $_GET['step'];

$fontSize = $minFontSize;
$result = "";
$increasing = true;

foreach ($symbols as $character) {
    $isLetter = ctype_alpha($character);
    $isEven = ord($character) % 2 == 0 ? true : false;

    $symbol = htmlspecialchars($character);

    if ($isLetter && $isEven) {
        $result .=  "<span style='font-size:" . $fontSize . ";text-decoration:line-through;'>$symbol</span>";
        $fontSize = changeFontSize($fontSize);
    } else if ($isLetter && !$isEven) {
        $result .= "<span style='font-size:" . $fontSize . ";'>$symbol</span>";
        $fontSize = changeFontSize($fontSize);
    } else if ($isEven) {
        $result .=  "<span style='font-size:" . $fontSize . ";text-decoration:line-through;'>$symbol</span>";
    } else {
        $result .= "<span style='font-size:" . $fontSize . ";'>$symbol</span>";
    }
}

echo $result;

function changeFontSize($size) {
    global $maxFontSize;
    global $minFontSize;
    global $step;
    global $increasing;

    if ($size >= $maxFontSize) {
        $size -= $step;
        $increasing = false;
        return $size;
    }

    if ($size <= $minFontSize) {
        $size += $step;
        $increasing = true;
        return $size;
    }

    if ($increasing) {
        return $size + $step;
    }

    return $size - $step;
}