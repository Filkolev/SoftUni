<?php
    date_default_timezone_set("Europe/Sofia");
    $today = getdate();
    $year = $today['year'];
    $new_year = strtotime('31st December' . $year);
    $difference = $new_year - $today[0];

    $days = (int)($difference / (24 * 60 * 60));
    $hours = (int)(((int)($difference - $days * 24 * 60 * 60))/3600);
    $minutes = (int)(($difference - ($days * 24 * 60 * 60) - ($hours * 60 * 60))/60);
    $seconds = (int)($difference - $days * 24 * 60 * 60 - $hours * 60 * 60 - $minutes * 60);

    echo "Hours until new year : " . number_format ((int)($difference / 3600), 0, ".", " ") . "<br />\n";
    echo "Minutes until new year : " . number_format ((int)($difference / 60), 0, ".", " ") . "<br />\n";
    echo "Seconds until new year : " .number_format ((int)($difference), 0, ".", " ") . "<br />\n";
    echo "Days:Hours:Minutes:Seconds $days:$hours:$minutes:$seconds<br />\n";
?>