<?php

$insertPattern = "/^\s*INSERT\s+INTO\s+(?P<table>.*?)\s+\((?P<fields>.*?)\)\s+VALUES\s+\((?P<values>.*?)\)\s*$/";
$deletePattern = "/^\s*DELETE\s+FROM\s+(?P<table>.*?)\s+WHERE\s+\((?P<field>.*?)\s+=\s+(?P<value>.*?)\)\s*$/";
$updatePattern = "/^\s*UPDATE\s+(?P<table>.*?)\s+SET\s+\((?P<update_field>.*?)\s+=\s+(?P<update_val>.*?)\)\s+WHERE\s+\((?P<field_condition>.*?)\s+=\s+(?P<val_condition>.*?)\)\s*$/";

$commands = $_GET['commands'];

$table = array();
$countErrors = 0;
$lastUserID = 0;

foreach ($commands as $command) {
    if (preg_match($insertPattern, $command, $match) === 1) {
        $fields = preg_split("/,\s+/", $match['fields'], -1, PREG_SPLIT_NO_EMPTY);
        $values = preg_split("/,\s+/", $match['values'], -1, PREG_SPLIT_NO_EMPTY);
        $invalidCommand = false;

        for ($i = 0; $i < count($fields); $i++) {
            if ($fields[$i] != 'user_id' && $fields[$i] != 'login' && $fields[$i] != 'gender' && $fields[$i] != 'age') {
                $invalidCommand = true;
            }
        }

        if (count($fields) != count($values) || $invalidCommand) {
            $countErrors++;
        } else {
            if (($index = array_search("login", $fields)) !== false) {
                $login = $values[$index];
            } else {
                $countErrors++;
                continue;
            }
            if (($index = array_search("user_id", $fields)) !== false) {
                $userID = intval($values[$index]);
            } else {
                $userID = $lastUserID;
            }

            $lastUserID = $userID + 1;

            if (($index = array_search("gender", $fields)) !== false) {
                $gender = $values[$index];
            } else {
                $gender = "undefined";
            }

            if (($index = array_search("age", $fields)) !== false) {
                $age = intval($values[$index]);
            } else {
                $age = "undefined";
            }

            $table[] = [
                'user_id' => $userID,
                'login' => $login,
                'gender' => $gender,
                'age' => $age
            ];
        }
    } else if (preg_match($deletePattern, $command, $match) === 1) {
        if ($match['field'] != 'user_id' && $match['field'] != 'gender' && $match['field'] != 'age') {
            $countErrors++;
            continue;
        }

        for ($i = 0; $i < count($table); $i++) {
            if ($match['value'] == $table[$i][$match['field']]) {
                unset($table[$i]);
            }
        }
    } else if (preg_match($updatePattern, $command, $match) === 1) {
        if ($match['field_condition'] != 'login' && $match['field_condition'] != 'gender' && $match['field_condition'] != 'age' && $match['field_condition'] != 'user_id') {
            $countErrors++;
            continue;
        }
        $found = false;

        for ($i = 0; $i < count($table); $i++) {
            if ($match['val_condition'] == $table[$i][$match['field_condition']]) {
                if ($match['update_field'] != 'user_id') {
                    if ($table[$i][$match['update_field']] == $match['update_val']) {
                        $countErrors++;
                    }
                    $table[$i][$match['update_field']] = $match['update_val'];
                }

                $found = true;
            }
        }

        if (!$found) {
            $countErrors++;
        }
    } else {
        $countErrors++;
    }
}

if (count($table) == 0) {
    echo "You have $countErrors error/s";
} else {
    $result = "<table><thead><tr><th>user_id</th><th>login</th><th>gender</th><th>age</th></tr></thead><tbody>";

    foreach ($table as $row) {
        $result .= "<tr><td>". $row['user_id'] ."</td><td>". htmlspecialchars($row['login']) ."</td><td>".$row['gender']."</td><td>". $row['age'] ."</td></tr>";
    }

    $result .= "</tbody><tfoot><tr><td colspan=\"4\">Errors=$countErrors</td></tr></tfoot>";
    $result .= "</table>";
    echo $result;
}