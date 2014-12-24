<?php
$items = parseInputList();
$maxSize = $_GET['maxSize'];

echo "<ul>";
foreach ($items as $item) {
    if (strlen($item) <= $maxSize) {
        // Small items stay unchanged
        $text = htmlspecialchars($item);
    } else {
        // Long items get truncated
        $text = htmlspecialchars(substr($item, 0, $maxSize)) . "...";
    }
    echo "<li>$text</li>";
}
echo "</ul>";

function parseInputList() {
    $list = $_GET['list'];
    $lines = preg_split('/\n/', $list);
    $result = [];
    foreach ($lines as $line) {
        $line = trim($line);
        if ($line != "") {
            $result[] = $line;
        }
    }
    return $result;
}
