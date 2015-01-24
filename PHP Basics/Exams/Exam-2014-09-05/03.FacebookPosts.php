<?php

date_default_timezone_set("Europe/Sofia");

$matches = preg_split("/\r?\n/", $_GET['text'], -1, PREG_SPLIT_NO_EMPTY);

$allPosts = array();

foreach ($matches as $post) {
    if (isset($post)) {
        $match = explode(";", $post);
        if (trim($match[1])) {
            $date = trim($match[1]);
        }
        $date = strtotime($date);
        $date = date('j F Y',$date);
        $allPosts[$date] = $post;
    }
}

ksort($allPosts);

$result = "";

foreach ($allPosts as $post) {
    $match = explode(";", $post);

    $author = $match[0];
    if (trim($author)) {
        $author = trim($author);
    }
    $author = htmlspecialchars($author);

    $date = $match[1];
    if (trim($date)) {
        $date = trim($date);
    }

    $date = strtotime($date);
    $date = date('j F Y',$date);

    $post = $match[2];
    if (trim($match[2])) {
        $post = trim($post);
    }
    $post = htmlspecialchars($post);

    $likes = $match[3];
    if (trim($likes)) {
        $likes = trim($likes);
    }
    $likes = htmlspecialchars($likes);

    $comments = trim($match[4]);
    if (trim($comments)) {
        $comments = trim($comments);
    }


    $result .= "<article>";
    $result .= "<header><span>$author</span><time>$date</time></header>";
    $result .= "<main><p>$post</p></main>";
    $result .= "<footer><div class=\"likes\">$likes people like this</div>";

    if (strlen($comments) > 0) {
        $comments = preg_split("/\//", $comments, -1, PREG_SPLIT_NO_EMPTY);
        $result .=   "<div class=\"comments\">";

        foreach ($comments as $comment) {
            $insert = $comment;
            if (trim($comment)) {
                $insert = trim($comment);
            }
            $insert = htmlspecialchars($insert);
            $result .=   "<p>$insert</p>";
        }

        $result .= "</div>";
    }

    $result .= "</footer>";
    $result .= "</article>";


}

echo $result;
?>