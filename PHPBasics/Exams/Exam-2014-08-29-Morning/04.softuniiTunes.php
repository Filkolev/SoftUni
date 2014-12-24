<?php

$text = $_GET['text'];
$filter = $_GET['artist'];
$orderBy = $_GET['property'];
$orderType = $_GET['order'];

$pattern = "/\s*(?P<name>.+?)\s*\|\s*(?P<genre>.+?)\s*\|\s*(?P<artists>.+?)\s*\|\s*(?P<downloads>\d+?)\s*\|\s*(?P<rating>.+)\s*/";
preg_match_all($pattern, $text, $songs, PREG_SET_ORDER);

$results = array();

foreach ($songs as $song) {
    $artists = preg_split("/,\s+/", $song['artists'], -1, PREG_SPLIT_NO_EMPTY);

    if (array_search($filter, $artists) !== false) { // true (strict)
        sort($artists);
        $artists = implode(", ", $artists);
        $rating = floatval(trim($song['rating']));

        $results[] = [
            'name' => $song['name'],
            'genre' => $song['genre'],
            'artists' => $artists,
            'downloads' => $song['downloads'],
            'rating' => $rating
        ];
    }
}

uasort($results, function ($song1, $song2) {
    global $orderBy;
    global $orderType;

    if ($orderType == "ascending") {

        if ($orderBy == "genre") {
            if (strcmp($song1['genre'], $song2['genre']) == 0) {
                return strcmp($song1['name'], $song2['name']);
            }
            return strcmp($song1['genre'], $song2['genre']);
        } else if ($orderBy == "downloads") {
            if (intval($song1['downloads']) == intval($song2['downloads'])) {
                return strcmp($song1['name'], $song2['name']);
            }
            return intval($song1['downloads']) < intval($song2['downloads']) ? -1 : 1;
        } else if ($orderBy == "rating") {
            if (floatval($song1['rating']) == floatval($song2['rating'])) {
                return strcmp($song1['name'], $song2['name']);
            }
            return floatval($song1['rating']) < floatval($song2['rating']) ? -1 : 1;
        }

        return strcmp($song1['name'], $song2['name']);
    } else {

        if ($orderBy == "genre") {
            if (strcmp($song1['genre'], $song2['genre']) == 0) {
                return strcmp($song1['name'], $song2['name']);
            }
            return strcmp($song2['genre'], $song1['genre']);
        } else if ($orderBy == "downloads") {
            if (intval($song1['downloads']) == intval($song2['downloads'])) {
                return strcmp($song1['name'], $song2['name']);
            }
            return intval($song2['downloads']) < intval($song1['downloads']) ? -1 : 1;
        } else if ($orderBy == "rating") {
            if (floatval($song1['rating']) == floatval($song2['rating'])) {
                return strcmp($song1['name'], $song2['name']);
            }
            return floatval($song2['rating']) < floatval($song1['rating']) ? -1 : 1;
        }

        return strcmp($song2['name'], $song1['name']);
    }


});

$result = "<table>\n<tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>\n";

foreach ($results as $entry) {
    $result .= "<tr><td>".htmlspecialchars(trim($entry['name']))."</td><td>".htmlspecialchars(trim($entry['genre']))."</td><td>".htmlspecialchars(trim($entry['artists']))."</td><td>".htmlspecialchars(trim($entry['downloads']))."</td><td>".htmlspecialchars(trim($entry['rating']))."</td></tr>\n";
}

$result .= "</table>";

echo $result;

