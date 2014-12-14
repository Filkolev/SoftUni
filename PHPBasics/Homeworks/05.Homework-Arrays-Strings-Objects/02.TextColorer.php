<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Text Colorer</title>
    <style>
        .red {
            color: red;
        }
        .blue {
            color: blue;
        }
        body {
            font-size: 1.5em;
        }
    </style>
</head>

<body>
    <form action="02.TextColorer.php" method="post">
        <input type="text" name="input-text" id="input-text" >
        <input type="submit" name="submit" id="submit" value="Color text">
    </form>

    <p>
    <?php if (isset($_POST['submit']) && isset($_POST['input-text'])):
        $sentence = $_POST['input-text'];
        foreach (str_split($sentence) as $letter):
            if (ord($letter) % 2 == 0): ?>
                <span class="red"><?php echo "$letter "; ?></span>
            <?php
            else: ?>
                <span class="blue"><?php echo "$letter "; ?></span>
            <?php
            endif;
        endforeach;
    endif;
    ?>
    </p>
</body>
</html>