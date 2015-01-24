<?php
$mainWord = $_GET['mainWord'];
$words = json_decode($_GET['words']);

$pattern = "/{\"row[\D]*(?P<row>\d+)\":\"(?P<word>.*)\"}/";

preg_match($pattern, $mainWord, $match);
$row = $match['row'];
$mainWord = $match['word'];
$matchWord = "";
$colIndex = 0;
$rowIndex = 0;

usort($words, function($word1, $word2) {
    return strlen($word2) - strlen($word1);
});

for ($i = 0; $i < count($words); $i++) {
    $currentWord = $words[$i];
    $matchFound = false;

    for ($j = 0; $j < strlen($currentWord); $j++) {
        $currentChar = $currentWord[$j];

        for ($k = 0; $k < strlen($mainWord); $k++) {
            if (strcmp($mainWord[$k], $currentChar) == 0) {

                $len = $j + 1;
                if ($len <= $row && (strlen(substr($currentWord, $len)) <= (strlen($mainWord) - $row))) {
                    $matchFound = true;
                    $colIndex = $k;
                    $rowIndex = $row - $len;
                    break;
                }
            }
        }
    }

    if ($matchFound) {
        $matchWord = $currentWord;
        array_splice($words, $i, 1);
        break;
    }
}

sort($words);

$table = array();
for ($i = 0; $i < strlen($mainWord); $i++) {
    $table[] = [];

    for ($j = 0; $j < strlen($mainWord); $j++) {
        if ($i + 1  == $row) {
            $table[$i][$j] = $mainWord[$j];
        } else if ($j == $colIndex && $i >= $rowIndex && $i < $rowIndex + strlen($matchWord)) {
            $table[$i][$j] = $matchWord[$i - $rowIndex];
        } else {
            $table[$i][$j] = "";
        }
    }
}

$result = "<table>";

foreach ($table as $rowToPrint) {
    $result .= "<tr>";

    foreach($rowToPrint as $colToPrint) {
        $result .= "<td>" . $colToPrint . "</td>";
    }

    $result .= "</tr>";
}

$result .= "</table>";
echo $result;

if (count($words) == 0) {
    echo "[]";
} else {
    $leftoverWords = array();

    foreach ($words as $word) {
        if (!array_key_exists(htmlspecialchars($word), $leftoverWords)) {
            $leftoverWords[htmlspecialchars($word)] = 0;
        }

        $leftoverWords[htmlspecialchars($word)] += getASCIISum($word);
    }

    echo json_encode((object)$leftoverWords);
}

function getASCIISum ($word) {
    $sum = 0;
    foreach (str_split($word) as $char) {
        $sum += ord($char);
    }

    return $sum;
}