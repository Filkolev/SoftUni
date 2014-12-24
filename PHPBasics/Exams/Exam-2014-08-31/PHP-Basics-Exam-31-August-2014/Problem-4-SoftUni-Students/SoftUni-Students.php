<?php
$students = $_GET['students'];
$sortColumn = $_GET['column'];
$order = $_GET['order'];

preg_match_all('/^.*$/m', $students, $matches);

$studentsArray = array();
for ($i = 0; $i < count( $matches[0]); $i++) {
    $props = explode(", ", $matches[0][$i]);
    $studentsArray[] = [
        'id' => $i + 1,
        'username' => $props[0],
        'email' => $props[1],
        'type' => $props[2],
        'result' => (int)$props[3]
    ];
}

switch ($sortColumn) {
    case 'id': usort($studentsArray, 'sortById'); break;
    case 'username': usort($studentsArray, 'sortByUsername'); break;
    case 'result': usort($studentsArray, 'sortByResult'); break;
}
if ($order === 'descending') {
    $studentsArray = array_reverse($studentsArray);
}

$output = "<table><thead><tr><th>Id</th><th>Username</th><th>Email</th><th>Type</th><th>Result</th></tr></thead>";

for ($i = 0; $i < count($studentsArray); $i++) {
    $id = $studentsArray[$i]['id'];
    $username = htmlspecialchars($studentsArray[$i]['username']);
    $email = htmlspecialchars($studentsArray[$i]['email']);
    $type = htmlspecialchars($studentsArray[$i]['type']);
    $result = htmlspecialchars($studentsArray[$i]['result']);
    $output .= "<tr><td>$id</td><td>$username</td><td>$email</td><td>$type</td><td>$result</td></tr>";
}
$output .= "</table>";
echo $output;

function sortById($a1, $a2)
{
    return $a1['id'] < $a2['id']? -1 : 1;
}

function sortByUsername($a1, $a2)
{
    $result = strcmp($a1['username'], $a2['username']);
    if ($result == 0) {
        $result = sortById($a1, $a2);
    }
    return $result;
}

function sortByResult($a1, $a2)
{
    if ($a1['result'] == $a2['result']) {
        $result = sortById($a1, $a2);
    } else {
        $result = $a1['result'] < $a2['result']? -1 : 1;
    }
    return $result;
}
