<?php
$rows = preg_split("/\s*\|\s*/", $_GET['board'], -1, PREG_SPLIT_NO_EMPTY);
$board = array_fill(0, 12, 0);

for ($i = 0; $i < 4; $i++) {
    $cells = preg_split("/\s+/", $rows[$i], -1, PREG_SPLIT_NO_EMPTY);

    switch ($i) {
        case 0:
            $board[0]  =  $cells[0];
            $board[1]  =  $cells[1];
            $board[2]  =  $cells[2];
            $board[3]  =  $cells[3];
            break;
        case 1:
            $board[11] = $cells[0];
            $board[4] = $cells[3];
            break;
        case 2:
            $board[10] = $cells[0];
            $board[5] = $cells[3];
            break;
        case 3:
            $board[9]  =  $cells[0];
            $board[8]  =  $cells[1];
            $board[7]  =  $cells[2];
            $board[6]  =  $cells[3];
            break;
    }
}

$coordinates = preg_split("/\s+/", $_GET['beginning'], -1, PREG_SPLIT_NO_EMPTY);
$position = 0;

switch ($coordinates[0]) {
    case 1:
        $position = $coordinates[1] - 1;
        break;
    case 2:
        if ($coordinates[1] == 1) {
            $position = 11;
        } else {
            $position = 4;
        }
        break;
    case 3:
        if ($coordinates[1] == 1) {
            $position = 10;
        } else {
            $position = 5;
        }
        break;
    case 4:
        $position = 10 - $coordinates[1];
}

$money = 50;
$gameOver = false;
$innsBought = 0;
$innsToBuy = 0;

for ($i = 0; $i < 12; $i++) {
    if (strcmp($board[$i], "I") == 0) {
        $innsToBuy++;
        $inns[] = $i;
    }
}

$moves = preg_split("/\s+/", $_GET['moves'], -1, PREG_SPLIT_NO_EMPTY);

for ($i = 0; $i < count($moves); $i++) {

    $money += $innsBought * 20;

    if ($money <= 0) {
        $gameOver = true;
        echo "<p>You lost! You ran out of money!<p>";
        break;
    }

    $currentMove = $moves[$i];
    $position = ($position + $currentMove) % 12;
    $currentAction = $board[$position];

    switch ($currentAction) {
        case "P":
            $money -= 5;
            break;
        case "I":
            if ($money >= 100) {
                $money -= 100;
                $board[$position] = true;
                $innsBought++;
            } else {
                $money -= 10;
            }
        break;
        case "F":
            $money += 20;
            break;
        case "V":
            $money *= 10;
            break;
        case "N":
            $gameOver = true;
            echo "<p>You won! Nakov's force was with you!<p>";
            break;
        case "S":
            $i += 2;
            break;
    }

    if ($innsBought == $innsToBuy) {
        $gameOver = true;
        echo "<p>You won! You own the village now! You have $money coins!<p>";
        break;
    }
}

if (!$gameOver) {
    echo "<p>You lost! No more moves! You have $money coins!<p>";
}