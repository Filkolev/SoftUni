<?php
$parts = preg_split("/,\s+/", $_GET['list'], -1, PREG_SPLIT_NO_EMPTY);

$available = [
    'CPU' => 0,
    'ROM' => 0,
    'RAM' => 0,
    'VIA' => 0
];

foreach ($parts as $part) {
    $available[$part]++;
}

$totalCost = 0;
if ($available['CPU'] >= 5) {
   $totalCost += 85 * $available['CPU'] / 2;
} else {
    $totalCost += 85 * $available['CPU'];
}

if ($available['ROM'] >= 5) {
    $totalCost += 45 * $available['ROM'] / 2;
} else {
    $totalCost += 45 * $available['ROM'];
}

if ($available['RAM'] >= 5) {
    $totalCost += 35 * $available['RAM'] / 2;
} else {
    $totalCost += 35 * $available['RAM'];
}

if ($available['VIA'] >= 5) {
    $totalCost += 45 * $available['VIA'] / 2;
} else {
    $totalCost += 45 * $available['VIA'];
}

$computersAssembled = min(array_values($available));
$partsLeft = 0;

$available['CPU'] -= $computersAssembled;
$available['ROM'] -= $computersAssembled;
$available['RAM'] -= $computersAssembled;
$available['VIA'] -= $computersAssembled;

$partsLeft += $available['CPU'];
$partsLeft += $available['ROM'];
$partsLeft += $available['RAM'];
$partsLeft += $available['VIA'];

$income = $computersAssembled * 420;

$income += 85 * ($available['CPU']) / 2;
$income += 45 * ($available['ROM']) / 2;
$income += 35 * ($available['RAM']) / 2;
$income += 45 * ($available['VIA']) / 2;

$balance = $income - $totalCost;

$result = "<ul>";
$result .= "<li>$computersAssembled computers assembled</li>";
$result .= "<li>$partsLeft parts left</li>";
$result .= "</ul>";

if ($balance > 0) {
    $result .= "<p>Nakov gained $balance leva</p>";
}
else {
    $result .= "<p>Nakov lost $balance leva</p>";
}

echo $result;