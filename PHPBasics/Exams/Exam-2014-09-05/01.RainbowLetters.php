<?php
$text = $_GET['text'];
$red = $_GET['red'];
$green = $_GET['green'];
$blue = $_GET['blue'];
$nth = $_GET['nth'];

$red = str_pad(dechex($red), 2, "0", STR_PAD_LEFT);
$green = str_pad(dechex($green), 2, "0", STR_PAD_LEFT);
$blue = str_pad(dechex($blue), 2, "0", STR_PAD_LEFT);

$color = "#" . $red . $green . $blue;
$chars = str_split($text);
$count = 0; ?>

<p><?php
    foreach ($chars as $letter) {
        $count++;
        if ($count % $nth == 0) { ?><span style="color: <?php echo $color?>"><?php
        }
        echo htmlspecialchars($letter);

        if ($count % $nth == 0) { ?></span><?php
        }
    }
    ?></p>
