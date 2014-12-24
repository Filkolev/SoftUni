<?php
$text = $_GET['text'];
$pattern = "/^\s*([\w\s\-]+)\s*\%\s*([\w\s\.\-]+)\s*;\s*[\d]{2}\-([\d]{2})\-[\d]{4}\s*-\s*(.{0,100})/m";
preg_match_all($pattern, $text, $matches);
$articles = [];
for ($i = 0; $i < count($matches[0]); $i++) {
    $topic = htmlspecialchars(trim($matches[1][$i]));
    $author = htmlspecialchars(trim($matches[2][$i]));
    $date = date('F', mktime(0, 0, 0, trim($matches[3][$i]), 10));
    $details = htmlspecialchars(trim($matches[4][$i]));
    $articles[] = "<div>\n" .
    "<b>Topic:</b> <span>$topic</span>\n" .
    "<b>Author:</b> <span>$author</span>\n" .
    "<b>When:</b> <span>$date</span>\n" .
    "<b>Summary:</b> <span>$details" . "...</span>\n" .
    "</div>";
}
echo implode("\n", $articles);
?>
