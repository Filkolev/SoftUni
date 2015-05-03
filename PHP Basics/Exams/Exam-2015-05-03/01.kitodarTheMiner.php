<?php

$entries = preg_split("/,/", $_GET['data'], -1, PREG_SPLIT_NO_EMPTY);

$result = [
    'gold' => 0,
    'silver' => 0,
    'diamonds' => 0
];

foreach ($entries as $entry) {
    $entryData = preg_split("/\s+/",$entry, -1, PREG_SPLIT_NO_EMPTY);

    if (count($entryData) !== 4 || $entryData[0] !== 'mine' || !is_numeric($entryData[3])) {
        continue;
    }

    if (intval($entryData[3] != floatval($entryData[3]))) {
        continue;
    }

    $quantity = intval($entryData[3]);
    $oreType = strtolower($entryData[2]);

    if (isset($result[$oreType])) {
        $result[$oreType] += $quantity;
    }
}

$output = "<p>*Gold: " . $result['gold'] . "</p>";
$output .= "<p>*Silver: " . $result['silver'] . "</p>";

$output .= "<p>*Diamonds: " . $result['diamonds'] . "</p>";

echo $output;