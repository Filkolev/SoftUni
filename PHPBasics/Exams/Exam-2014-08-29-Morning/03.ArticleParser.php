<?php
date_default_timezone_set("UTC");
$text = $_GET['text'];
$pattern = "/\s*(?P<topic>[a-zA-Z -]+)\s*%\s*(?P<author>[a-zA-Z \-.]+)\s*;\s*\d{2}-(?P<month>\d{2})-\d{4}\s*-\s*(?P<summary>[^\n]{1,100})\s*/";
preg_match_all($pattern, $text, $articles, PREG_SET_ORDER);

$result = "";

foreach ($articles as $article) {
    $dateObj   = DateTime::createFromFormat('!m', $article['month']);
    $monthName = $dateObj->format('F');

    $result .= "<div>\n";
    $result .= "<b>Topic:</b> <span>" . htmlspecialchars(trim($article['topic'])) . "</span>\n";
    $result .= "<b>Author:</b> <span>" . htmlspecialchars(trim($article['author'])) . "</span>\n";
    $result .= "<b>When:</b> <span>" . htmlspecialchars(trim($monthName)) . "</span>\n";
    $result .= "<b>Summary:</b> <span>" . htmlspecialchars(trim($article['summary'])) . "...</span>\n";
    $result .= "</div>\n";
}

echo $result;