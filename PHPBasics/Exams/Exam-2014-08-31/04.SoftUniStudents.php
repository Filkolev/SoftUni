<?php
$sortBy = $_GET['column'];
$sortOrder = $_GET['order'];
$list = $_GET['students'];

$studentInfo = preg_split("/\s*\r?\n\s*/", $list, -1, PREG_SPLIT_NO_EMPTY);

$students = array();
$id = 1;

foreach ($studentInfo as $student) {
    $data = preg_split("/\s*,\s*/", $student, -1, PREG_SPLIT_NO_EMPTY);

    $students[] = [
        'id' => $id,
        'name' => $data[0],
        'email' => $data[1],
        'type' => $data[2],
        'score' => $data[3]
    ];

    $id++;
}

uasort($students, function($a, $b) use ($sortOrder, $sortBy){

    if ($sortBy == 'result') {
        if ($sortOrder == 'ascending') {
            if ($a['score'] == $b['score']) {
                return $a['id'] - $b['id'];
            }
            return $a['score'] - $b['score'];

        } else {
            if ($a['score'] == $b['score']) {
                return $b['id'] - $a['id'];
            }
            return $b['score'] - $a['score'];
        }
    }
    else if ($sortBy == 'username') {
        if ($sortOrder == 'ascending') {
            if ($a['name'] == $b['name']) {
                return $a['id'] - $b['id'];
            }

            return strcmp($a['name'], $b['name']);
        } else {
            if ($a['name'] == $b['name']) {
                return $b['id'] - $a['id'];
            }

            return strcmp($b['name'], $a['name']);
        }
    }
    else {
        if ($sortOrder == 'ascending') {
            return $a['id'] - $b['id'];
        }

        return $b['id'] - $a['id'];
    }
});

$result = "<table><thead><tr><th>Id</th><th>Username</th><th>Email</th><th>Type</th><th>Result</th></tr></thead>";

foreach ($students as $currentStudent) {
    $result .= "<tr>";
    $result .= "<td>" . htmlspecialchars($currentStudent['id']) . "</td>";
    $result .= "<td>" . htmlspecialchars($currentStudent['name']) . "</td>";
    $result .= "<td>" . htmlspecialchars($currentStudent['email']) . "</td>";
    $result .= "<td>" . htmlspecialchars($currentStudent['type']) . "</td>";
    $result .= "<td>" . htmlspecialchars($currentStudent['score']) . "</td>";
    $result .= "</tr>";
}

$result .= "</table>";

echo $result;


