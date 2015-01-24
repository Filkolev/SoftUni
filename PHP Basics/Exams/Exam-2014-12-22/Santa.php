<?php

$childName = $_GET['childName'];
$childName = preg_replace("/\s/", "-", $childName);
$wantedPresent = $_GET['wantedPresent'];
$riddles = preg_split("/\s*;\s*/", $_GET['riddles'], -1, PREG_SPLIT_NO_EMPTY);
$riddleIndex = (strlen($childName) % count($riddles)) - 1;
if ($riddleIndex == -1) {
    $riddleIndex = count($riddles) - 1;
}

$riddle = $riddles[$riddleIndex];

echo "\$giftOf" . htmlspecialchars($childName) . " = \$[wasChildGood] ? '" . htmlspecialchars($wantedPresent) . "' : '" . htmlspecialchars($riddle) . "';";