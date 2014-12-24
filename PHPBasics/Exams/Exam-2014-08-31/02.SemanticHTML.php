<?php
$text = $_GET['html'];
$pattern = "/<\s*div\s*(?<first>.*?)\s*(?:id|class)\s*=\s*\"(?P<type>main|header|nav|article|section|aside|footer)\"\s*(?P<second>.*?)\>/";
preg_match_all($pattern, $text, $matches);

for ($i = 0; $i < count($matches[0]); $i++) {
    $first =  strlen($matches['first'][$i]) > 0 ? " " . trim($matches['first'][$i]) : "";
    $second = strlen($matches['second'][$i]) > 0 ? " " . trim($matches['second'][$i]) : "";
    $first = preg_replace("/\s+/", " ", $first);
    $second = preg_replace("/\s+/", " ", $second);
    $type = $matches['type'][$i];
    $replacement = "$type$first$second";
    $text = preg_replace($matches[0][$i], $replacement, $text);
}

$pattern = "/<\/\s*div\s*>\s+<\s*!--\s*(main|header|nav|article|section|aside|footer)\s*-->/";
preg_match_all($pattern, $text, $matches);

for ($i = 0; $i < count($matches[0]); $i++) {
    $tag = $matches[1][$i];
    $replacement = "</" . $tag . ">";
    $text = preg_replace("<" . $matches[0][$i] . ">", $replacement, $text);
}

echo $text;