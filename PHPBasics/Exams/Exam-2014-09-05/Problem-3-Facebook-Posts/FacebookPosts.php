<?php
date_default_timezone_set("Europe/Sofia");
$text = $_GET['text'];
$matches = preg_split("/\r?\n/", $text, -1, PREG_SPLIT_NO_EMPTY);

$allLines = trimAllLines($matches);
$posts = [];
foreach ($allLines as $line) {
    $data = trimAllLines(explode(";", $line));
    $dateAsTime = strtotime($data[1]);
    $posts[$dateAsTime] = buildPost($data);
}

krsort($posts);
echo implode("", $posts);

function buildPost($parts) {
    $result = "";
    $date = date("j F Y",  strtotime($parts[1]));
    $author = htmlspecialchars($parts[0]);
    $post = htmlspecialchars($parts[2]);
    $likes = htmlspecialchars($parts[3]);
    $result .= "<article>";
    $result .= "<header><span>$author</span><time>$date</time></header>";
    $result .= "<main><p>$post</p></main>";
    $result .= "<footer><div class=\"likes\">$likes people like this</div>";
    if (isset($parts[4])) {
        $comments = explode("/", $parts[4]);
        $result .= "<div class=\"comments\">";
        foreach($comments as $value) {
            $comment = htmlspecialchars(trim($value));
            $result .= "<p>$comment</p>";
        }
        $result .= "</div>";
    }
    $result .= "</footer>";
    $result .= "</article>";
    return $result;
}

function trimAllLines($matches) {
    $allLines = [];
    foreach($matches as $string) {
        if (trim($string)) {
            $allLines[] = trim($string);
        }
    }
    return $allLines;
}