<?php
date_default_timezone_set('Europe/Sofia');
$currentTime = strtotime($_GET['currentDate']);
$chatString = $_GET['messages'];
$messages = preg_split("/\r?\n/", $chatString);

$chatLog = [];
$latestTime = 0;
foreach ($messages as $message) {
    $messageInfo = preg_split("/\s+\/\s+/", $message, -1, PREG_SPLIT_NO_EMPTY);
    $messageText = $messageInfo[0];
    $messageTime = strtotime($messageInfo[1]);
    $chatLog[$messageTime] = $messageText;
    if ($messageTime > $latestTime) {
        $latestTime = $messageTime;
    }
}

ksort($chatLog);
foreach ($chatLog as $key => $value) {
    echo "<div>" . htmlspecialchars($value) . "</div>\n";
}
$timestamp = getTimeMark($latestTime, $currentTime);
echo "<p>Last active: <time>$timestamp</time></p>";

function getTimeMark($lastTime, $currentTime) {
    $timeDiff = $currentTime - $lastTime;
    $timeStamp = '';

    $lastDay = date('z', $lastTime);
    $currentDay = date('z', $currentTime);
    if ($lastDay == $currentDay) {
        if ($timeDiff < 60) {
            $timeStamp = "a few moments ago";
        } else if ($timeDiff < 60 * 60) {
            $minutes = floor($timeDiff / 60);
            $timeStamp = "$minutes minute(s) ago";
        } else if ($timeDiff < 24 * 60 * 60) {
            $hours = floor($timeDiff / (60 * 60));
            $timeStamp = "$hours hour(s) ago";
        }
    }
    else if ($lastDay + 1 == $currentDay) {
        $timeStamp = "yesterday";
    } else {
        $timeStamp = date("d-m-Y", $lastTime);
    }

    return $timeStamp;
}
