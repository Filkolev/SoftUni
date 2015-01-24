<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>URL Replacer</title>
    <style>
        input, textarea {
            display: block;
            margin: 5px 0 10px 5px;
        }
        textarea {
            height: 100px;
        }
        div#result, textarea {
            width: 400px;
        }
    </style>
</head>
<body>
    <form method="post" action="06.URLReplacer.php">
        <label for="text">Enter the text:</label>
        <textarea name="text" id="text"></textarea>
        <input type="submit" name="submit" id="submit" value="Replace URLs">
    </form>

    <div id="result">
        <?php
        if (isset($_POST['submit']) && isset($_POST['text'])):
            $text = $_POST['text'];
            $openingTag = "/<\\s*a\\s*href\\s*=\\s*\"([^\"]+)\"\\s*>/";
            preg_match_all($openingTag, $text, $matchingOpeningTags);

            for ($i = 0; $i < count($matchingOpeningTags[0]); $i++) {
                $text = preg_replace("<" . $matchingOpeningTags[0][$i] . ">", "[URL=" . $matchingOpeningTags[1][$i] . "]" , $text);
            }

            $text = preg_replace("/<\\s*\\/\\s*a\\s*>/", "[/URL]", $text);
            echo $text;
        endif;
        ?>
    </div>
</body>
</html>
