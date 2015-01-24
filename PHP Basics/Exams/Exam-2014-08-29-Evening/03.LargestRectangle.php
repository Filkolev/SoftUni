<?php
$matrix = json_decode($_GET['jsonTable']);

$maxArea = 0;
$indexStartRow = 0;
$indexEndRow = 0;
$indexStartCol = 0;
$indexEndCol = 0;
$totalRows = count($matrix);
$totalCols = count($matrix[0]);

for ($row = 0; $row < $totalRows; $row++) {
    for ($col = 0; $col < $totalCols; $col++) {

        for ($endRow = $row; $endRow < $totalRows; $endRow++) {
            for ($endCol = $col; $endCol < $totalCols; $endCol++) {
                if (checkRectangle($row, $endRow, $col, $endCol)) {
                    $height = $endRow - $row + 1;
                    $width = $endCol - $col + 1;
                    $area = $height * $width;

                    if ($area > $maxArea) {
                        $maxArea = $area;
                        $indexStartRow = $row;
                        $indexEndRow = $endRow;
                        $indexStartCol = $col;
                        $indexEndCol = $endCol;
                    }
                }
            }
        }
    }
}

$result = "<table border='1' cellpadding='5'>";

for ($row = 0; $row < $totalRows; $row++) {
    $result .= "<tr>";
    for ($col = 0; $col < $totalCols; $col++) {
        if ($row == $indexStartRow && $col >= $indexStartCol && $col <= $indexEndCol) {
            $result .=  "<td style='background:#CCC'>".htmlspecialchars($matrix[$row][$col])."</td>";
        } else if ($row == $indexEndRow && $col >= $indexStartCol && $col <= $indexEndCol) {
            $result .=  "<td style='background:#CCC'>".htmlspecialchars($matrix[$row][$col])."</td>";
        } else if ($col == $indexStartCol && $row >= $indexStartRow && $row <= $indexEndRow) {
            $result .=  "<td style='background:#CCC'>".htmlspecialchars($matrix[$row][$col])."</td>";
        } else if ($col == $indexEndCol && $row >= $indexStartRow && $row <= $indexEndRow) {
            $result .=  "<td style='background:#CCC'>".htmlspecialchars($matrix[$row][$col])."</td>";
        } else {
            $result .= "<td>" . htmlspecialchars($matrix[$row][$col]) . "</td>";
        }
    }

    $result .= "</tr>";
}

$result .= "</table>";

echo $result;

function checkRectangle($startRow, $endRow, $startCol, $endCol) {
    global $matrix;
    $checkString = $matrix[$startRow][$startCol];

    for ($i = $startRow; $i <= $endRow; $i++) {
        if ($matrix[$i][$startCol] != $checkString || $matrix[$i][$endCol] != $checkString) {
            return false;
        }
    }

    for ($i = $startCol; $i <= $endCol; $i++) {
        if ($matrix[$startRow][$i] != $checkString || $matrix[$endRow][$i] != $checkString) {
            return false;
        }
    }

    return true;
}
