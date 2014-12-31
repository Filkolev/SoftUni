<?php

$text = $_GET['text'];
$key = $_GET['key'];

$keyGroup = "";
if (!ctype_digit($key[0]) && !ctype_alpha($key[0])) {
    $keyGroup .= "\\";
}

$keyGroup .= $key[0] . "";

for ($i = 1; $i < strlen($key) - 1; $i++) {
    if (ctype_lower($key[$i])) {
        $keyGroup .= "[a-z]*";
    } else if (ctype_upper($key[$i])) {
        $keyGroup .= "[A-Z]*";
    } else if (ctype_digit($key[$i])) {
        $keyGroup .= "[0-9]*";
    } else {
        $keyGroup .= "\\";
        $keyGroup .= $key[$i];
    }
}

if (!ctype_digit($key[strlen($key) - 1]) && !ctype_alpha($key[strlen($key) - 1])) {
    $keyGroup .= "\\";
}

$keyGroup .= $key[strlen($key) - 1];

$pattern = "/" . $keyGroup . "(.{2,6})" . $keyGroup . "/";

preg_match_all($pattern, $text, $matches);

$result = "";

foreach ($matches[1] as $shard) {
    $result .= $shard;
}

echo $result;