<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>Word Mapper</title>
    <style>
        textarea {
            height: 30px;
            width: 400px;
            display: block;
            margin: 10px auto;
        }
        input, table, form {
            margin: 10px auto;
        }
        input {
            display: block;
        }
        table, tr, td {
            border: 1px solid black;
        }
        td {
            padding: 5px;
        }
    </style>
</head>

<body>
    <form action="01.WordMapper.php" method="post">
        <textarea name="input-field" id="input-field"></textarea>
        <input type="submit" value="Count words" name="submit" id="submit">
    </form>

    <div>
        <?php if (isset($_POST['submit']) && isset($_POST['input-field'])):

        preg_match_all("/\\w+/", strtolower($_POST['input-field']), $words);

        foreach ($words[0] as $word) {
            $map[$word]++;
        }
        ?>

        <table>
            <?php foreach($map as $key=>$value): ?>
                <tr><td><?php echo htmlentities($key) ?></td><td><?php echo $value ?></td></tr>
            <?php endforeach;
        endif; ?>
    </div>
</body>
</html>


