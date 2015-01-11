<?php

$pattern = "/Exception\s+in\s+thread\s+\".*?\"\s+(?:.*?\.)+(?P<exception>.*?):\s+\d+\s+at\s+.*?\.(?P<method>.*?)\((?P<file_name>.*?):(?P<line>\d+)\)/";
preg_match_all($pattern, $_GET['errorLog'], $matches, PREG_SET_ORDER);

$result = "<ul>";

foreach ($matches as $match) {
    $result .= "<li>line <strong>" . htmlspecialchars($match['line']);
    $result .= "</strong> - <strong>" . htmlspecialchars($match['exception']);
    $result .= "</strong> in <em>" . htmlspecialchars($match['file_name']) . ":";
    $result .= htmlspecialchars($match['method']) . "</em></li>";
}

$result .= "</ul>";
echo $result;
