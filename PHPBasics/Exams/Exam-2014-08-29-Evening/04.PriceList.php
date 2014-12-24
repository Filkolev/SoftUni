<?php

$list = $_GET['priceList'];

$pattern = "/\s*<\s*tr\s*>\s*<\s*td\s*>\s*(?P<product>.*?)\s*<\s*\/\s*td\s*>\s*<\s*td\s*>\s*(?P<category>.*?)\s*<\s*\/\s*td\s*>\s*<\s*td\s*>\s*(?P<price>.*?)\s*<\s*\/\s*td\s*>\s*<\s*td\s*>\s*(?P<currency>.*?)\s*<\s*\/\s*td\s*>\s*<\s*\/\s*tr\s*>\s*/";

preg_match_all($pattern, $list, $matches);
$countMatches = count($matches[0]);

$unsortedResult = array();

for ($i = 0; $i <$countMatches; $i++) {
    $product = html_entity_decode($matches['product'][$i]);
    $category = html_entity_decode($matches['category'][$i]);
    $price = html_entity_decode($matches['price'][$i]);
    $currency = html_entity_decode($matches['currency'][$i]);

    if (!array_key_exists($category, $unsortedResult)) {
        $unsortedResult[$category] = array();
    }

    $unsortedResult[$category][] = [
        'product' => $product,
        'price' => $price,
        'currency' => $currency
    ];
}

$sortedResult = array();

foreach ($unsortedResult as $category=>$catEntry) {

    uasort($catEntry, function ($a, $b) {
        return strcmp($a['product'], $b['product']);
    });
    $newEntry = array();
    foreach ($catEntry as $prod) {
        $newEntry[] = (object)$prod;
    }
    $sortedResult[$category] = $newEntry;

}

ksort($sortedResult);
$sortedResult = (object)$sortedResult;
echo json_encode($sortedResult);
