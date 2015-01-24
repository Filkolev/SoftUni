<?php
$text = $_GET['list'];
$limit = $_GET['maxSize'];
$sentences = preg_split("/\r?\n/", $text, -1, PREG_SPLIT_NO_EMPTY);

$result = "<ul>";

foreach  ($sentences as $sentence) {
    $sentence = trim($sentence);
    $toAppend = strlen($sentence) > $limit;
    $sentence = substr($sentence, 0, $limit);

    if ($toAppend) {
        $sentence .= "...";
    }

    $result .= "<li>" . htmlspecialchars($sentence) . "</li>";
}

$result .= "</ul>";
echo $result;