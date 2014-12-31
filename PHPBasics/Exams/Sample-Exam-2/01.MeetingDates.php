<?php
date_default_timezone_set('UTC');

$firstDate = DateTime::createFromFormat("d-m-Y", $_GET['dateOne']);
$secondDate = DateTime::createFromFormat("d-m-Y", $_GET['dateTwo']);

if ($firstDate > $secondDate) {
    $temp = $firstDate;
    $firstDate = $secondDate;
    $secondDate = $temp;
}

$results = array();

for ($i = $firstDate; $i <= $secondDate; $i->add(new DateInterval('P1D'))) {
    if (strcmp($i->format("D"), "Thu") == 0) {
        $results[] = $i->format("d-m-Y");
    }
}

if (count($results) == 0) {
    echo "<h2>No Thursdays</h2>";
}
else {
    $toPrint = "<ol>";

    foreach ($results as $thursday) {
        $toPrint .= "<li>$thursday</li>";
    }

    $toPrint .= "</ol>";

    echo $toPrint;
}
