<?php
$text = $_GET['text'];
$minPrice = floatval($_GET['min-price']);
$maxPrice = floatval($_GET['max-price']);
$sortBy = $_GET['sort'];
$sortOrder = $_GET['order'];

$books = preg_split("/\r?\n/", $text, -1, PREG_SPLIT_NO_EMPTY);
$results = array();

foreach ($books as $book) {
    $bookInfo = preg_split("/\//", $book, -1, PREG_SPLIT_NO_EMPTY);

    $author = trim($bookInfo[0]);
    $name = trim($bookInfo[1]);
    $genre = trim($bookInfo[2]);
    $price = (trim($bookInfo[3]));
    $date = trim($bookInfo[4]);
    $info = trim($bookInfo[5]);

    if ($price >= $minPrice && $price <= $maxPrice) {
        $results[] = [
            'author' => $author,
            'name' => $name,
            'genre' => $genre,
            'price' => $price,
            'publish-date' => $date,
            'info' => $info
        ];
    }
}

uasort($results, function($a, $b) {
    global $sortBy;
    global $sortOrder;

    if ($a[$sortBy] == $b[$sortBy]) {
        return $a['publish-date'] < $b['publish-date'] ? -1 : 1;
    }

    return ($a[$sortBy] < $b[$sortBy]) ^ ($sortOrder == 'ascending') ? 1 : -1;
});

$print = "";

foreach ($results as $bookPrint) {
    $print .= "<div>";
    $print .= "<p>" . htmlspecialchars($bookPrint['name']) . "</p>";
    $print .= "<ul>";
    $print .= "<li>" . htmlspecialchars($bookPrint['author']) . "</li>";
    $print .= "<li>" . htmlspecialchars($bookPrint['genre']) . "</li>";
    $print .= "<li>" . $bookPrint['price'] . "</li>";
    $print .= "<li>" . htmlspecialchars($bookPrint['publish-date']) . "</li>";
    $print .= "<li>" . htmlspecialchars($bookPrint['info']) . "</li>";
    $print .= "</ul>";
    $print .= "</div>";
}

echo $print;