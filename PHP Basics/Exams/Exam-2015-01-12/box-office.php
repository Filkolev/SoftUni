<?php

$order = $_GET['order'];
$filter = $_GET['filter'];
$maxSeats = intval($_GET['maxSeats']);
$minSeats = intval($_GET['minSeats']);
$pattern = "/\s*(.*?)\s*\((.*?)\)-\s*(.*?)\s*\/\s*(\d+)/";

preg_match_all($pattern, $_GET['list'], $matches, PREG_SET_ORDER);


$result = array();

foreach ($matches as $match) {
    $name =  trim($match[1]);
    $genre = trim($match[2]);
    $stars = preg_split("/\s*,\s*/", $match[3], -1, PREG_SPLIT_NO_EMPTY);
    $seatsFilled = intval(trim($match[4]));

    if ($seatsFilled >= $minSeats && $seatsFilled <= $maxSeats && ($filter == $genre || $filter == 'all')) {
        $result[] = [
            'name' => $name,
            'stars' => $stars,
            'filled seats' => $seatsFilled
        ];
    }
}

uasort($result, function ($a, $b) {
    global $order;

    if (strcmp($a['name'], $b['name']) == 0) {
        return $a['filled seats'] - $b['filled seats'];
    }

    return $order == 'ascending' ^ $a['name'] < $b['name'] ? 1 : -1;
});

$toPrint = "";

foreach ($result as $screening) {
    $toPrint .= "<div class=\"screening\"><h2>". htmlspecialchars($screening['name']) ."</h2>";
    $toPrint .= "<ul>";

    foreach ($screening['stars'] as $star) {
        $toPrint .= "<li class=\"star\">" . htmlspecialchars($star) . "</li>";
    }

    $toPrint .= "</ul>";
    $toPrint .= "<span class=\"seatsFilled\">" . $screening['filled seats'] . " seats filled</span>";
    $toPrint .= "</div>";
}

echo $toPrint;