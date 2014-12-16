<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8" />
        <title>String Modifier</title>
    </head>

    <body>
        <form action="06.StringModifier.php" method="post">
            <input type="text" id="text" name="text" required="required">
            <input type="radio" name="operation" value="palindrome" id="palindrome">
            <label for="palindrome">Check Palindrome</label>
            <input type="radio" name="operation" value="reverse" id="reverse" required="required">
            <label for="reverse">Reverse String</label>
            <input type="radio" name="operation" id="split" value="split">
            <label for="split">Split</label>
            <input type="radio" name="operation" id="hash" value="hash">
            <label for="hash">Hash String</label>
            <input type="radio" name="operation" id="shuffle" value="shuffle">
            <label for="shuffle">Shuffle String</label>

            <input type="submit" name="submit">
        </form>

        <p>
            <?php
            if (isset($_POST['submit']) && $_POST['text'] != '') {
                $operation = $_POST['operation'];
                $text = $_POST['text'];

                if ($operation == 'palindrome') {
                    $reversed = array_reverse(str_split($text));
                    $reversed = implode("", $reversed);
                    if ($reversed == $text) {
                        echo htmlentities($text) . " is a palindrome!";
                    } else {
                        echo htmlentities($text) . " is not a palindrome!";
                    }
                } else if ($operation == 'reverse') {
                    $reversed = array_reverse(str_split($text));
                    $reversed = implode("", $reversed);
                    echo htmlentities($reversed);
                } else if ($operation == 'split') {
                    $splitStr = implode(" ", str_split($text));
                    echo htmlentities($splitStr);
                } else if ($operation == 'hash') {
                    echo crypt($text);
                } else {
                    $arr = str_split($text);
                    shuffle($arr);
                    $newStr = implode("", $arr);
                    while ($newStr == $text) {
                        shuffle($arr);
                    }

                    $newStr = implode("", $arr);
                    echo htmlentities($newStr);
                }
            }
            ?>
        </p>
    </body>
</html>



