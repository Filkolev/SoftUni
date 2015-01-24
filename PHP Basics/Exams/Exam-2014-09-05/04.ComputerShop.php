<?php
$minPrice = floatval($_GET['minPrice']);
$maxPrice = floatval($_GET['maxPrice']);
$filter = $_GET['filter'];
$order = $_GET['order'];

$entries = preg_split("/\r?\n/", $_GET['list'], -1, PREG_SPLIT_NO_EMPTY);
$results = array();
$id = 0;

foreach ($entries as $entry) {
    $id++;
    $data = preg_split("/\s*\|\s*/", $entry, -1, PREG_SPLIT_NO_EMPTY);
    $name = trim($data[0]);
    $type = trim($data[1]);
    $components = preg_split("/\s*,\s+/", $data[2], -1, PREG_SPLIT_NO_EMPTY);
    $price = floatval($data[3]);

    if ($price >= $minPrice && $price <= $maxPrice && ($type == $filter || $filter == 'all')) {
        $results[] = [
            'id' => $id,
            'name' => $name,
            'components' => $components,
            'price' => $price
        ];
    }
}

uasort($results, function($a, $b) {
    global $order;

    if (floatval($a['price']) == floatval($b['price'])) {
        return $a['id'] - $b['id'];
    }

    return ($order == 'ascending') ^ ($a['price'] < $b['price']) ? 1 : -1;
});

$toPrint = "";

foreach ($results as $computer) {
    $toPrint .= "<div class=\"product\" id=\"product" . $computer['id'] . "\">";
    $toPrint .= "<h2>" . htmlspecialchars($computer['name']) . "</h2>";

    $toPrint .= "<ul>";
    foreach ($computer['components'] as $component) {
        $toPrint .= "<li class=\"component\">" . htmlspecialchars(trim($component)) . "</li>";
    }
    $toPrint .= "</ul>";

    $toPrint .= "<span class=\"price\">" . number_format($computer['price'], 2, '.', '') . "</span>";
    $toPrint .= "</div>";
}

echo $toPrint;
