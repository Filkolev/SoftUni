<?php
$recipient = htmlspecialchars($_GET['recipient']);
$subject = htmlspecialchars($_GET['subject']);
$body = htmlspecialchars($_GET['body']);
$email =
    "<p class='recipient'>$recipient</p>" .
    "<p class='subject'>$subject</p>" .
    "<p class='message'>$body</p>";
$key = $_GET['key'];
//echo $email;
$encryptedEmail = encrypt($email, $key);
echo $encryptedEmail;

function encrypt($msg, $key) {
    $msgLen = strlen($msg);
    $keyLen = strlen($key);
    $result = '|';
    for ($i = 0; $i < $msgLen; $i++) {
        $encryptedChar = ord($msg[$i]) * ord($key[$i % $keyLen]);
        $result .= dechex($encryptedChar) . '|';
    }
    return $result;
}