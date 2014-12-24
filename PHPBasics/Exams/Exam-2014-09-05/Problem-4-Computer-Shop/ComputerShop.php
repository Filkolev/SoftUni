<?php
$text = $_GET['list'];
$minPrice = $_GET['minPrice'];
$maxPrice = $_GET['maxPrice'];
$filter = $_GET['filter'];
$order = $_GET['order'];

$list = preg_split("/\r?\n/", $text, -1, PREG_SPLIT_NO_EMPTY);
$products = [];
$id = 1;
foreach ($list as $pr) {
    $data = preg_split("/\s*[|]\s*/", $pr, -1, PREG_SPLIT_NO_EMPTY);
    $price = floatval($data[3]);
    if ($price >= $minPrice && $price <= $maxPrice) {
        $name = $data[0];
        $type = $data[1];
        $components = explode(", ", $data[2]);
        $products[] = [$name, $type, $components, $price, $id];
    }
    $id++;
}

$resultProducts = array_filter($products, function($pr) use ($filter) {
    return $filter == $pr[1] ? true : ($filter == "all" ? true : false);
});

usort($resultProducts, function($p1, $p2) use ($order) {
    if ($p1[3] == $p2[3]) {
        return $p1[4] - $p2[4];
    }
    return ($order == "ascending" ^ $p1[3] > $p2[3]) ? -1 : 1;
});

foreach ($resultProducts as $pr) {
    $result = "";
    $result .= "<div class=\"product\" id=\"product" . $pr[4] . "\">";
    $result .= "<h2>" . htmlspecialchars($pr[0]) . "</h2>";
    $result .= "<ul>";
    foreach ($pr[2] as $cmp) {
        $result .= "<li class=\"component\">" . htmlspecialchars($cmp). "</li>";
    }
    $result .= "</ul>";
    $result .= "<span class=\"price\">" . number_format($pr[3], 2, '.', '') . "</span>";
    $result .= "</div>";
    echo $result;
}