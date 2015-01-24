<?php
$pattern = "/\s*(.*?)\s*;\s*(.*?)\s*;\s*(.*?)\s*;\s*(.*?)\s*;\s*(.*)\s*/";
date_default_timezone_set("Europe/Sofia");

preg_match_all($pattern, $_GET['text'], $posts, PREG_SET_ORDER);

$assoc_posts = array();

for ($i = 0; $i < count($posts); $i++) {
    $posts[$i][2] = strtotime($posts[$i][2]);
    $comments = $items = preg_split("/\//", $posts[$i][5], -1, PREG_SPLIT_NO_EMPTY);
    $assoc_posts[$posts[$i][2]] = [$posts[$i][1], $posts[$i][3], $posts[$i][4], $comments];
}

krsort($assoc_posts);

foreach ($assoc_posts as $date=>$post) {
    $date = date('j F Y',$date);

    echo "<article>";
    echo "<header><span>" . htmlspecialchars($post[0]) . "</span><time>$date</time></header>";
    echo "<main><p>" . htmlspecialchars($post[1]) . "</p></main>";
    echo "<footer><div class=\"likes\">$post[2] people like this</div>";

    if (count($post[3]) > 0) {
        echo "<div class=\"comments\">";

        foreach ($post[3] as $comment) {
            echo "<p>" . htmlspecialchars(trim($comment)) . "</p>";
        }
        echo "</div>";
    }

    echo "</footer></article>";
}
?>
