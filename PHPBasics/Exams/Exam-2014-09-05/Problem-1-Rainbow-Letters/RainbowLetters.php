<?php
$text = $_GET['text'];
$red = addLeadingZeroes(dechex($_GET['red']));
$green = addLeadingZeroes(dechex($_GET['green']));
$blue = addLeadingZeroes(dechex($_GET['blue']));
$nthLetter = $_GET['nth'];

$color = "#" . $red . $green . $blue;
$result = "<p>";
for ($i = 0; $i < strlen($text); $i++) {
	$letter = htmlspecialchars($text[$i]);
    if (($i + 1) % $nthLetter == 0) {
       $result .= "<span style=\"color: $color\">$letter</span>";
    } else {
		$result .= $letter;
	}
}
echo $result . "</p>";

function addLeadingZeroes($color) {
    if (strlen($color) == 1) {
        $color = '0' . $color;
    }
    return $color;
}
