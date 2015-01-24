<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Print Tags</title>
</head>

<body>
<?php
// Problem says the script should generate the input field, so that's what I do

echo "<form action='02.MostFrequentTag.php' method='post'>\n";
echo "<input type='text' name='input'/>\n";
echo "<input type=\"submit\" name='submit'/>\n";
echo "</form>\n";

if (isset($_POST['submit'])) {
    $tags = explode(", ", $_POST['input']);
    $frequencies = array();

    foreach ($tags as $tag) {
        if (!$frequencies[$tag]) {
            $frequencies[$tag] = 1;
        } else {
            $frequencies[$tag] += 1;
        }
    }

    arsort($frequencies);
    $maxFrequency = $frequencies[array_keys($frequencies)[0]];
    $mostFrequentTags = array();

    foreach ($frequencies as $key=>$value) {
        echo "$key : $value times<br />\n";
        if ($maxFrequency == $frequencies[$key]) {
            $mostFrequentTags[] = $key;
        }
    }

    echo "<p>Most Frequent Tag(s) is(are) : " . implode($mostFrequentTags, ", ") . "</p>";
}

?>
</body>
</html>