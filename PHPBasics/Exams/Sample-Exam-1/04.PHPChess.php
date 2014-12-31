<?php

$input = $_GET['board'];
$valid = true;

$rows = preg_split("/\//", $input, -1, PREG_SPLIT_NO_EMPTY);
if (count($rows) != 8) {
    $valid = false;
}

for ($row = 0; $row < count($rows); $row++) {
    $rows[$row] = preg_split("/-/", $rows[$row]);

    if (count($rows[$row]) != 8) {
        $valid = false;
    }

    foreach ($rows[$row] as $data) {
        if (strcmp($data, "K") !== 0
            && strcmp($data, "B") !== 0
            && strcmp($data, "R") !== 0
            && strcmp($data, "H") !== 0
            && strcmp($data, "Q") !== 0
            && strcmp($data, "P") !== 0
            && !ctype_space($data)) {
            $valid = false;
        }
    }
}

if (!$valid) {
    echo "<h1>Invalid chess board</h1>";
}
else {
    $countPieces = array();

    $result = "<table>";

    for ($row = 0; $row < 8; $row++) {
        $result .= "<tr>";

        for ($col = 0; $col < 8; $col++) {
            $currentPiece = $rows[$row][$col];

            $result .= "<td>" .$currentPiece. "</td>";

            switch ($currentPiece) {
                case "B": $currentPiece = "Bishop"; break;
                case "R": $currentPiece = "Rook"; break;
                case "H": $currentPiece = "Horseman"; break;
                case "K": $currentPiece = "King"; break;
                case "Q": $currentPiece = "Queen"; break;
                case "P": $currentPiece = "Pawn"; break;
            }

            if (!ctype_space($currentPiece)) {
                if (!array_key_exists($currentPiece,$countPieces)) {
                    $countPieces[$currentPiece] = 0;
                }
                $countPieces[$currentPiece]++;
            }
        }

        $result .= "</tr>";
    }

    ksort($countPieces);

    $result .= "</table>";

    echo $result;
    echo json_encode((object)$countPieces);
}

