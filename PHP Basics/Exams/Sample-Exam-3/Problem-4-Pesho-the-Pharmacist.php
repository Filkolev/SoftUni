<?php
date_default_timezone_set('UTC');

$firstDay = DateTime::createFromFormat("d/m/Y", $_GET['today']);
$firstDay->sub(new DateInterval("P5Y"));
$invoices = $_GET['invoices'];
$result = array();

foreach ($invoices as $invoice) {
    if (strlen($invoice) == 0) {
        continue;
    }
    $data = preg_split("/\s*\|\s*/", $invoice, -1, PREG_SPLIT_NO_EMPTY);
    $date = DateTime::createFromFormat("d/m/Y", $data[0]);

    if ($date >= $firstDay) {
        $date = $date->format("d/m/Y");
        $company = trim($data[1]);
        $drug = trim($data[2]);
        $cost = floatval($data[3]);

        if (!array_key_exists($date, $result)) {
            $result[$date] = array();
        }

        if (!array_key_exists($company, $result[$date])) {
            $result[$date][$company] = [
                'drugs' => array(),
                'totalCost' => 0
            ];
        }
        $result[$date][$company]['drugs'][] = $drug;
        $result[$date][$company]['totalCost'] += $cost;
    }
}

uksort($result, function ($a, $b) {
    return DateTime::createFromFormat("d/m/Y", $a) < DateTime::createFromFormat("d/m/Y", $b) ? -1 : 1;
});

$toPrint = "<ul>";

foreach ($result as $key=>$entry) {
    ksort($entry);
    $toPrint .= "<li><p>" . htmlspecialchars($key) . "</p>";

    foreach ($entry as $compKey=>$comp) {
        $toPrint .= "<ul>";

        sort($comp['drugs']);
        $drugs = implode(",",$comp['drugs']);
        $cost = $comp['totalCost'];

        $toPrint .= "<li><p>" . htmlspecialchars($compKey) . "</p><ul><li><p>". htmlspecialchars($drugs) . "-" . $cost . "lv</p></li></ul></li>";

        $toPrint .= "</ul>";
    }
    $toPrint .= "</li>";
}

$toPrint .= "</ul>";
echo ($toPrint);