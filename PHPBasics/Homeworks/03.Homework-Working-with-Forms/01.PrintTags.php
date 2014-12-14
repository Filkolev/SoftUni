<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8" />
        <title>Print Tags</title>
    </head>

    <body>
        <?php
        // Problem says the script should generate the input field, so that's what I do

        echo "<form action='01.printTags.php' method='post'>\n";
        echo "<input type='text' name='input'/>\n";
        echo "<input type=\"submit\" name='submit'/>\n";
        echo "</form>\n";
        ?>
        <div>
        <?php
        if (isset($_POST['submit'])) {
            $tags = explode(", ", $_POST['input']);
            for ($i = 0; $i < count($tags); $i++) {
                echo "$i : $tags[$i] <br />\n";
            }
        }

        ?>
        </div>
    </body>
</html>

 