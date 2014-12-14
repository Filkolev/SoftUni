<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Text Filter</title>
    <style>
        textarea {
            width: 500px;
            height: 50px;
            display: block;
            margin: 5px 0 10px 0;
        }
        input {
            display: block;
            margin: 10px 0;
        }
    </style>
</head>
<body>
    <form action="04.TextFilter.php" method="post">
        <label for="text">Enter text:</label>
        <textarea name="text" id="text"></textarea>
        <label for="ban-list">Enter banned words:</label>
        <input type="text" name="ban-list" id="ban-list">
        <input type="submit" name="submit" id="submit" value="Filter text">
    </form>

    <div>
        <?php
        if (isset($_POST['submit']) && isset($_POST['text']) && isset($_POST['ban-list'])): ?>
            <h2>Filtered text:</h2>
        <?php
            $banned = explode(", ", $_POST['ban-list']);
            $output = $_POST['text'];
            foreach ($banned as $word) {
                $replaceString = str_repeat('*', strlen($word));
                $output = str_replace($word, $replaceString, $output);
            }
            echo htmlentities($output);
        endif;
        ?>
    </div>
</body>
</html>