<?php
date_default_timezone_set('UTC');
$name = trim($_GET['name']);
$gender = trim($_GET['gender']);
$pin = trim($_GET['pin']);
$validPIN = true;

/*----- CHECK NAMES -----*/
$names = explode(" ", $name);
if (count($names) != 2) {
    $validPIN = false;
}

if (!ctype_upper($names[0][0]) || !ctype_upper($names[1][0])) {
    $validPIN = false;
}

/*----- CHECK 10-DIGIT PIN -----*/
$pattern = "/^(?P<year>\d{2})(?P<month>\d{2})(?P<day>\d{2})\d{2}(?P<gender>\d)(?P<checksum>\d)$/";
preg_match($pattern, $pin, $data);

if (count($data) == 0) {
    $validPIN = false;
}

$month = intval($data['month']);
$year = "";

/*----- CHECK VALID MONTH ----- */
if ($month >= 1 && $month <= 12) {
    $year .= "19" . $data['year'];
} else if ($month >= 21 && $month <= 32 ) {
    $year .= "18" . $data['year'];
    $month -= 20;
} else if ($month >= 41 && $month <= 52) {
    $year .= "20" . $data['year'];
    $month -= 40;
} else {
    $validPIN = false;
}

/*----- CHECK VALID DATE ------*/
if ($month < 10) {
    $month = "0" . intval($month);
}

$date = $year . $month . $data['day'];
$validPIN = $validPIN && validateDate($date);

function validateDate($date, $format = 'Ymd')
{
    $d = DateTime::createFromFormat($format, $date);

    if ($d === false) {
        return false;
    }
    return strcmp($d->format($format), $date) == 0;
}

/*------ CHECK VALID GENDER -----*/
$validPIN = $validPIN && (strcmp($gender, "male") == 0) ^ ($data['gender'] % 2 != 0);

/*------ CHECK VALID CHECKSUM ------*/
$checkSumArr = [2,4,8,5,10,9,7,3,6];
$sum = 0;

for ($i = 0; $i < strlen($pin) - 1; $i++) {
    $sum += intval($pin[$i]) * $checkSumArr[$i];
}

$sum %= 11;
if ($sum == 10) {
    $sum = 0;
}

if ($sum != $data['checksum']) {
    $validPIN = false;
}


/*----- OUTPUT ----- */
if (!$validPIN) {
    echo "<h2>Incorrect data</h2>";
}
else {
    $result = [
        'name' => $name,
        'gender' => $gender,
        'pin' => $pin
    ];

    echo json_encode((object)$result);
}