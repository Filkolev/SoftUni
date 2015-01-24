<?php
$recipient = $_GET['recipient'];
$subject = $_GET['subject'];
$body = $_GET['body'];
$key = $_GET['key'];

$formattedMessage = "<p class='recipient'>".htmlspecialchars($recipient)."</p><p class='subject'>".htmlspecialchars($subject)."</p><p class='message'>".htmlspecialchars($body)."</p>";

$encryptedMessage = "|";
$index = 0;
foreach (str_split($formattedMessage) as $char) {
    $keyChar = $key[$index % strlen($key)];
    $product = ord($char) * ord($keyChar);
    $encryptedChar = dechex($product);
    $encryptedMessage .= $encryptedChar . "|";
    $index++;
}

echo $encryptedMessage;
