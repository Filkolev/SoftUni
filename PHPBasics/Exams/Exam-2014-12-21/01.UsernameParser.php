<?php
    
$list = $_GET['list'];
$length = $_GET['length'];

$show = false;
if (isset($_GET['show'])) {
    $show = true;
}

$names = preg_split("/\r?\n/", $list, -1, PREG_SPLIT_NO_EMPTY);

//var_dump($names);

$result = "<ul>";

foreach ($names as $name) {
    $name = trim($name);
    if (strlen($name) == 0) {
        continue;
    }

    if (strlen($name) >= $length) {
    $result .= "<li>" . htmlspecialchars($name) . "</li>";
    } else if ($show) {
        $result .= '<li style="color: red;">' . htmlspecialchars($name) . "</li>";
    }
}

$result .= "</ul>";

echo $result;
