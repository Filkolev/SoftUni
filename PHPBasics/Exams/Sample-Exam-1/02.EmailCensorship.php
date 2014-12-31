<?php

$text = $_GET['text'];
$blacklist = preg_split("/\r?\n/", $_GET['blacklist'], -1, PREG_SPLIT_NO_EMPTY);

foreach ($blacklist as $email) {
    $matches = array();
    if ($email[0] == "*") {
        $domain = substr($email, 2);
        $pattern = "/(?<=\b)[\w+\-]+@[0-9a-zA-Z\-]+\.$domain(?=\b)/";
        preg_match_all($pattern, $text, $matches, PREG_SET_ORDER);
    }
    else {
        $pattern = "/(?<=\b)$email(?=\b)/";
        preg_match_all($pattern, $text, $matches, PREG_SET_ORDER);
    }

    foreach($matches as $toCensor) {
        $text = preg_replace("/" . $toCensor[0] . "/", str_repeat("*", strlen($toCensor[0])), $text, 1);
    }
}

$pattern = "/(?<=\b)[\w+\-]+@[0-9a-zA-Z\-]+\.[0-9a-zA-Z\-.]+(?=\b)/";
preg_match_all($pattern, $text, $leftovers, PREG_SET_ORDER);

foreach ($leftovers as $left) {
    $replacement = "<a href=\"mailto:$left[0]\">$left[0]</a>";
    $text = preg_replace("/" . $left[0] . "/", $replacement, $text);
}

echo "<p>$text</p>";
