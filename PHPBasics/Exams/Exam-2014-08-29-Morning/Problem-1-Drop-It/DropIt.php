<?php
$text = $_GET['text'];
$minFontSize = intval($_GET['minFontSize']);
$maxFontSize = intval($_GET['maxFontSize']);
$step = intval($_GET['step']);

$currentSize = $minFontSize;
$isIncrementing = true;
$decoration = "";
for ($i = 0; $i < strlen($text); $i++) {
    if (ord($text[$i]) % 2 == 0) {
        $decoration = "text-decoration:line-through;";
    } else {
        $decoration = "";
    }
    echo "<span style='font-size:$currentSize;$decoration'>" .
        htmlspecialchars($text[$i]) . "</span>";
    $isLetter = isLetter($text[$i]);
    if ($isLetter) {
        if ($isIncrementing) {
            $currentSize += $step;
        } else {
            $currentSize -= $step;
        }
    }
    if ($isLetter && ($currentSize >= $maxFontSize || $currentSize <= $minFontSize)) {
        $isIncrementing = !$isIncrementing;
    }
}

function isLetter($char) {
    return (ord($char) >= ord('a') && ord($char) <= ord('z')) ||
		((ord($char) >= ord('A') && ord($char) <= ord('Z')));
}