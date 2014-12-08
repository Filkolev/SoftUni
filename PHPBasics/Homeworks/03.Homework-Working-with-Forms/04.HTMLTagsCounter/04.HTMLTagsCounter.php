<!DOCTYPE html>

<html>
    <head>
        <meta charset="utf-8" />
        <title>HTML Tags Counter</title>
        <style>
            h2, label {
                display: block;
                height: 40px;
            }
        </style>
    </head>

    <body>
    <?php require "04.externalScript.php" ?>
        <form action="04.HTMLTagsCounter.php" method="post">
            <label for="input">Enter HTML tags:</label>
            <input type="text" name="input" id="input" autofocus/>
            <input type="submit" name="submit">
        </form>
        <h2><?php echo $result ?></h2>
        <h2>Score: <?php echo $_SESSION['score'] ?></h2>
    </body>
</html>