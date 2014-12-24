<?php

$minPrice = $_GET['minPrice'];
$maxPrice = $_GET['maxPrice'];
$filter = $_GET['filter'];
$order = $_GET['order'];
$list = $_GET['list'];

$items = preg_split("/\n/", $list, -1, PREG_SPLIT_NO_EMPTY);
$results = array();

$id = 0;
foreach ($items as $entry) {
    $id++;
    $data = preg_split("/\s*[|]\s*/", $entry, -1, PREG_SPLIT_NO_EMPTY);

    $name = trim($data[0]);
    $type = trim($data[1]);
    $components = preg_split("/,\s+/", $data[2], -1, PREG_SPLIT_NO_EMPTY);
    $price = trim($data[3]);

    if ($price >= $minPrice && $price <= $maxPrice && ($type == $filter || $filter == 'all'))  {
        $currentProduct = [
            'id' => $id,
            'name' => $name,
            'components' => $components,
            'price' => $price,
            'type' => $type
        ];
        $results[] = $currentProduct;
    }
}

uasort($results, function($a, $b)  {
    global $order;
    if ($a['price'] == $b['price']) {
        return $a['id'] - $b['id'];
    }

    if ($order == 'ascending') {
        return $a['price'] - $b['price'];
    }

    return $b['price'] - $a['price'];

});

foreach ($results as $product) {
    $name = htmlspecialchars($product['name']);
    $price = number_format($product['price'], 2, '.', '');
    $id = $product['id'];

    echo "<div class=\"product\" id=\"product$id\">";
    echo "<h2>$name</h2><ul>";

    foreach ($product['components'] as $component) {
        $component = trim($component);
        $component = htmlspecialchars($component);
        echo "<li class=\"component\">$component</li>";
    }

    echo "</ul><span class=\"price\">$price</span></div>";
}
?>
