<?php
$errorLog = $_GET['errorLog'];

$pattern = "/Exception in thread \".*\" java.*\.(.*):.*\n.*?\.(.*?)\((.*?):(\d+)/";
preg_match_all($pattern, $errorLog, $matches);

echo "<ul>";
for ($i = 0; $i < count($matches[0]); $i++) {
    $line = htmlspecialchars($matches[4][$i]);
    $exception = htmlspecialchars($matches[1][$i]);
    $file = htmlspecialchars($matches[3][$i]);
    $method = htmlspecialchars($matches[2][$i]);
    echo "<li>line <strong>$line</strong> - <strong>$exception</strong> in <em>$file:$method</em></li>";
}
echo "</ul>";