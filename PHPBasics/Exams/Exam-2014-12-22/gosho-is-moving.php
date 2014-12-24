<?php

if (!isset($_GET['typeLuggage'])) {
    echo "<ul></ul>";
} else if (empty($_GET['luggage'])) {
    echo "<ul></ul>";
} else if (empty($_GET['room'])) {
    echo "<ul></ul>";
} else if (empty($_GET['minWeight'])) {
    echo "<ul></ul>";
} else if (empty($_GET['maxWeight'])) {
    echo "<ul></ul>";
} else {
    $results = array();
    $typeLuggage = $_GET['typeLuggage'];
    $luggage = $_GET['luggage'];
    $room = $_GET['room'];
    $minWeight = intval($_GET['minWeight']); // floatval ?
    $maxWeight = intval($_GET['maxWeight']);// floatval ?

    $luggagePieces = preg_split("/C\|_\|/", $luggage, -1, PREG_SPLIT_NO_EMPTY);

    foreach ($luggagePieces as $currentEntry) {
        $data = preg_split("/\s*;\s*/", $currentEntry, -1, PREG_SPLIT_NO_EMPTY);

        if (count($data) < 4) {
            continue;
        }

        $entryType = trim($data[0]);
        $entryRoom = trim($data[1]);
        $entryName = trim($data[2]);
        $entryWeight = intval(trim($data[3]));

        if ($entryRoom == $room && array_search($entryType, $typeLuggage) !== false) { // strict?
            if (!array_key_exists($entryType, $results)) {
                $results[$entryType] = [
                    'name' => array(),
                    'weight' => 0
                ];
            }

            $results[$entryType]['name'][] = $entryName;
            $results[$entryType]['weight'] += $entryWeight;
        }
    }

    ksort($results);
    $toPrint = "<ul>";

    foreach ($results as $category=>$catData) {
        if ($catData['weight'] < $minWeight || $catData['weight'] > $maxWeight) {
            continue;
        }

        $types = $catData['name'];
        sort($types);

        $toPrint .= "<li><p>". htmlspecialchars($category)."</p>";
        $toPrint .= "<ul><li><p>". htmlspecialchars($room). "</p>";
        $toPrint .= "<ul><li><p>" . htmlspecialchars(implode(", ", $types)) . " - ". htmlspecialchars($catData['weight']) ."kg</p></li></ul></li></ul></li>";
    }

    $toPrint .= "</ul>";
    echo $toPrint;
}