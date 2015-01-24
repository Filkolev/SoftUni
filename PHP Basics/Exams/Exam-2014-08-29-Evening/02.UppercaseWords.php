<?php

$text = $_GET['text'];
$pattern = "/(?<![a-zA-Z])(?P<word>[A-Z]+)(?![a-zA-Z])/";
preg_match_all($pattern, $text, $matches);

for ($i = 0; $i < count($matches[0]); $i++) {
    $uppercaseWord = $matches['word'][$i];
    $result = "";

    if ($uppercaseWord == strrev($uppercaseWord)) {
        foreach (str_split($uppercaseWord) as $letter) {
            $result .= $letter . $letter;
        }
    } else {
        $result = strrev($uppercaseWord);
    }

    $text = preg_replace("/(?<![a-zA-Z])".$uppercaseWord."(?![a-zA-Z])/", $result, $text);
}

echo "<p>" . htmlspecialchars($text) . "</p>";