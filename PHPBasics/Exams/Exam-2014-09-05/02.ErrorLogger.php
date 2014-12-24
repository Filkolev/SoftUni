<?php
$text = $_GET['errorLog'];
$pattern = "/Exception\s+in\s+thread\s+\".*?\"\s+java(?:\..*)*(\..+):\s+.*\s+at\s+[^.]+\.([^\(]+)\(([^:]+):(\d+)/";
//$pattern = "/Exception in thread \".*\" java.*\.(.*):.*\n.*?\.(.*?)\((.*?):(\d+)/";

preg_match_all($pattern, $text, $results);
$result = "<ul>";

for ($entry = 0; $entry < count($results[0]); $entry++) {
    $result .= "<li>line <strong>" . htmlspecialchars($results[4][$entry]) . "</strong> - <strong>";
    $result .= htmlspecialchars(trim($results[1][$entry], ".")) . "</strong> in <em>";
    $result .= htmlspecialchars($results[3][$entry]) . ":";
    $result .= htmlspecialchars($results[2][$entry]) . "</em></li>";
}

$result .= "</ul>";
echo $result;