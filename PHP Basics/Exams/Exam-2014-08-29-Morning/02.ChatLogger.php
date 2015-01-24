<?php
date_default_timezone_set("UTC");
$currentTime = preg_split("/[\s:\-]+/", $_GET['currentDate'], -1, PREG_SPLIT_NO_EMPTY);

$input = $_GET['messages'];

$pattern = "/\s*(?P<message>.*?)\s*\/\s*(?P<day>\d{2})-(?P<month>\d{2})-(?P<year>\d{4})\s*(?P<hours>\d{2}):(?P<minutes>\d{2}):(?P<seconds>\d{2})(?:\s+|$)/";

preg_match_all($pattern, $input, $messages, PREG_SET_ORDER);

for ($i = 0; $i < count($messages); $i++) {
    $time = mktime($messages[$i]['hours'], $messages[$i]['minutes'], $messages[$i]['seconds'], $messages[$i]['month'], $messages[$i]['day'], $messages[$i]['year']);
    $messages[$i]['time'] = $time;
}

uasort($messages, function($msg1, $msg2) {
    return $msg1['time'] - $msg2['time'];
});

$lastMessage = end($messages);

$timestamp = "";

if ($lastMessage['day'] == $currentTime[0] && $lastMessage['year'] == $currentTime[2] && $lastMessage['month'] == $currentTime[1]) {
    $currentTime = mktime($currentTime[3], $currentTime[4], $currentTime[5], $currentTime[1], $currentTime[0], $currentTime[2]);
    $difference = $currentTime - $lastMessage['time'];

    if ($difference < 60) {
        $timestamp = "a few moments ago";
    } else if ($difference < 60*60) {
        $timestamp = intval($difference / 60) . " minute(s) ago";
    } else {
        $timestamp = intval($difference / 3600) . " hour(s) ago";
    }
} else if ($lastMessage['year'] == $currentTime[2] && $lastMessage['month'] == $currentTime[1] && $lastMessage['day'] == $currentTime[0] - 1) {
    $timestamp = "yesterday";
} else {
    $timestamp = $lastMessage['day'] . "-" . $lastMessage['month'] . "-" . $lastMessage['year'];
}

$result = "";

foreach ($messages as $message) {
    $result .= "<div>" . htmlspecialchars($message['message']) . "</div>\n";
}

$result .= "<p>Last active: <time>$timestamp</time></p>";

echo $result;

