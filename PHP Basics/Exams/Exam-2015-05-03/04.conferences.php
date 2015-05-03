<?php

date_default_timezone_set('UTC');

function getRemainingDays($date)
{
    $currentDate = DateTime::createFromFormat('Y-m-d', '2015-05-03');
    $date = DateTime::createFromFormat('Y-m-d', $date);

    $remainingDays = $currentDate->diff($date)->days;
    if ($currentDate->diff($date)->invert) {
        $remainingDays *= -1;
    }

    return $remainingDays;
}

$page = intval($_GET['page']);
$pageSize = intval($_GET['pageSize']);

$pattern = "/\[\s*(?P<eventDate>(?:\d{4}-\d{2}-\d{2})|(?:\d{4}\/\d{2}\/\d{2})),\s+(?P<hashtag>#[a-zA-Z.\-]+),\s+'(?P<eventName>.*?)',\s+(?P<location>[a-zA-Z\-,]+),\s+(?P<totalTickets>\d+),\s+(?P<soldTickets>\d+)\s*\]/";

preg_match_all($pattern, $_GET['conferences'], $conferences, PREG_SET_ORDER);

foreach ($conferences as $index => $conference) {
    $conference['availableTickets'] = intval($conference['totalTickets']) - intval($conference['soldTickets']);
    $conference['eventDate'] = preg_replace('/\//', '-', $conference['eventDate']);
    $conference['daysLeft'] = getRemainingDays($conference['eventDate']);
    $conferences[$index] = $conference;
}

uasort($conferences, function ($a, $b) {
    if ($a['eventDate'] === $b['eventDate']) {
        if ($a['location'] === $b['location']) {
            if ($a['availableTickets'] === $b['availableTickets']) {
                return strcmp($a['eventName'], $b['eventName']);
            }

            return $b['availableTickets'] - $a['availableTickets'];
        }

        return strcmp($a['location'], $b['location']);
    }

    return strcmp($b['eventDate'], $a['eventDate']);
});

$conferences = array_slice($conferences, ($page - 1) * $pageSize, $pageSize);

$outputConferences = [];

foreach ($conferences as $conference) {
    $date = $conference['eventDate'];

    if (!isset($outputConferences[$date])) {
        $outputConferences[$date] = [];
    }

    $outputConferences[$date][] = [
        'name' => $conference['eventName'],
        'hash' => $conference['hashtag'],
        'daysLeft' => $conference['daysLeft'] < 0 ? $conference['daysLeft'] : '+' . $conference['daysLeft'],
        'seatsLeft' => $conference['availableTickets']
    ];
}

if (count($outputConferences) === 0) {
    echo '<table border="1" cellpadding="5"><tr><th>Date</th><th>Event name</th><th>Event hash</th><th>Days left</th><th>Seats left</th></tr><tr><td>-</td><td>-</td><td>-</td><td>-</td><td>-</td></tr></table>';
} else {
    $output = '<table border="1" cellpadding="5"><tr><th>Date</th><th>Event name</th><th>Event hash</th><th>Days left</th><th>Seats left</th></tr>';

    foreach ($outputConferences as $date => $conference) {
        $output .= "<tr>";
        $rowTagOpened = true;
        $rowSpan = count($conference);

        if ($rowSpan > 1) {
            $output .= "<td rowspan=\"" . count($conference) . "\">" . $date . "</td>";
        } else {
            $output .= "<td>" . $date . "</td>";
        }

        foreach ($conference as $event) {
            if (!$rowTagOpened) {
                $output .= "<tr>";
            } else {
                $rowTagOpened = false;
            }

            $output .= "<td>" . htmlspecialchars($event['name']) . "</td>";
            $output .= "<td>" . htmlspecialchars($event['hash']) . "</td>";
            $output .= "<td>" . $event['daysLeft'] . " days</td>";
            $output .= "<td>" . $event['seatsLeft'] . " seats left</td>";
            $output .= "</tr>";
        }
    }

    $output .= "</table>";
}

echo $output;