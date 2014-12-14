<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Sidebar Builder</title>
    <style>
        aside {
            padding: 10px 0 10px 10px;
            border-radius: 10px;
            border: 1px solid black;
            margin: 5px;
            width: 200px;
            background: linear-gradient(lightblue 50%, lightseagreen 100%);
        }
        h2 {
            border-bottom: 1px solid black;
        }
        a {
            color: black;
            font-size: 1.2em;
        }
        a:hover {
            color: red;
        }
        ul {
            list-style-type: circle;
        }
        form {
            margin: 20px;
        }
        label {
            margin: 10px;
        }
    </style>
</head>
<body>
    <form action="03.SidebarBuilder.php" method="post">
        <label for="categories">Categories: <input type="text" name="categories" id="categories"></label>
        <label for="tags">Tags: <input type="text" name="tags" id="tags"></label>
        <label for="months">Months: <input type="text" name="months" id="months"></label>
        <input type="submit" name="submit" id="submit" value="Generate">
    </form>

    <?php if (isset($_POST['submit']) && isset($_POST['categories']) && isset($_POST['tags']) && isset($_POST['months'])):
        $categories = explode(", ", $_POST['categories']);
        $tags = explode(", ", $_POST['tags']);
        $months = explode(", ", $_POST['months']); ?>

    <aside>
        <h2>Categories</h2>
        <ul>
            <?php foreach ($categories as $categoryEntry): ?>
                <li><a href=#><?php echo htmlentities($categoryEntry); ?></a></li>
            <?php endforeach; ?>
        </ul>
    </aside>

    <aside>
        <h2>Tags</h2>
        <ul>
            <?php foreach ($tags as $tagEntry): ?>
                <li><a href=#><?php echo htmlentities($tagEntry); ?></a></li>
            <?php endforeach; ?>
        </ul>
    </aside>

    <aside>
        <h2>Months</h2>
        <ul>
            <?php foreach ($months as $monthEntry): ?>
                <li><a href=#><?php echo htmlentities($monthEntry); ?></a></li>
            <?php endforeach; ?>
        </ul>
    </aside>

    <?php endif; ?>

</body>
</html>
