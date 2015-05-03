<?php

$input = $_GET['arrows'] . "|" . $_GET['arrows1'] . "|" . $_GET['arrows2'] . "|" . $_GET['arrows3'];

$largePattern = "/>>>----->>/";
$middlePattern = "/>>----->/";
$smallPattern = "/>----->/";

preg_match_all($largePattern, $input, $matches, PREG_SET_ORDER);

$result = count($matches);

$input = preg_replace($largePattern, "|", $input);

preg_match_all($middlePattern, $input, $matches, PREG_SET_ORDER);
$result = count($matches) . $result;

$input = preg_replace($middlePattern, "|", $input);

preg_match_all($smallPattern, $input, $matches, PREG_SET_ORDER);
$result = count($matches) . $result;

$binaryResult = decbin(intval($result));

$output = $binaryResult . strrev($binaryResult);

echo bindec($output);