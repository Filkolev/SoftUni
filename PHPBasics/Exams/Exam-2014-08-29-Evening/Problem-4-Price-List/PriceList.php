<?php
$inputHtml = $_GET['priceList'];
$pattern = "|<td>\s*(.*?)\s*</td>\s*<td>\s*(.*?)\s*</td>\s*<td>\s*(.*?)\s*</td>\s*<td>\s*(.*?)\s*</td>|";
preg_match_all($pattern, $inputHtml, $matches, PREG_SET_ORDER);
$categories = [];
foreach ($matches as $match) {
    $category = html_entity_decode($match[2]);
    $item = [
        'product' => html_entity_decode($match[1]),
        'price' => html_entity_decode($match[3]),
        'currency' => html_entity_decode($match[4])
    ];
    if (!isset($categories[$category])) {
        $categories[$category] = [];
    }
    array_push($categories[$category], $item);
}

ksort($categories);
foreach ($categories as $category => $items) {
    usort($items, function($a, $b) {
        return strcmp($a['product'], $b['product']);
    });
    $categories[$category] = $items;
}

echo json_encode($categories);
