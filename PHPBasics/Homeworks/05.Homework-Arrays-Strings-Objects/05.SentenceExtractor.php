<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Sentence Extractor</title>
</head>
<style>
    textarea, input {
        display: block;
        margin: 5px 0 10px 10px;
    }
</style>
<body>
    <form action="05.SentenceExtractor.php" method="post">
        <label for="text">Enter the text: </label>
        <textarea name="text" id="text"></textarea>
        <label for="search-word">Enter the search word: </label>
        <input type="text" name="search-word" id="search-word">
        <input type="submit" name="submit" id="submit" value="Find">
    </form>

    <?php
    if (isset($_POST['submit']) && isset($_POST['text']) && isset($_POST['search-word'])):
        $word = $_POST['search-word'];
        $pattern = "/\\b[^.!?]*\\b" . $word . "\\b[^.!?]*[?!.]/";
        preg_match_all($pattern, $_POST['text'], $matches);

        if (count($matches) > 0): ?>
            <h2>Results:</h2>
            <ul>
                <?php foreach ($matches[0] as $sentence): ?>
                    <li><?php echo htmlentities($sentence); ?></li>
                <?php endforeach; ?>
            </ul>

        <?php else: ?>
            <h2>No results found!</h2>
        <?php
        endif;
    endif; ?>

</body>
</html>