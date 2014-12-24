<?php
$str = $_GET['html'];
$semanticTags = ['main', 'header', 'nav', 'article', 'section', 'aside', 'footer'];

$openTagsPattern = '/<div.*?\b((id|class)\s*=\s*"(.*?)").*?>/';
preg_match_all($openTagsPattern, $str, $openingTags);
//var_dump($openingTags);
foreach ($openingTags[0] as $key => $match) {
    $attrName = $openingTags[1][$key];
    $attrValue = $openingTags[3][$key];
    if (in_array($attrValue, $semanticTags)) {
        $replaceTag = str_replace('div', $attrValue, $match);
        $replaceTag = str_replace($attrName, '', $replaceTag);
        $replaceTag = preg_replace('/\s*>/', '>', $replaceTag);
        $replaceTag = preg_replace('/\s{2,}/', ' ', $replaceTag);
        $str = str_replace($match, $replaceTag, $str);
    }
}

$closeTagsPattern = '/<\/div>\s.*?(\w+)\s*-->/';
preg_match_all($closeTagsPattern, $str, $closingTags);
//var_dump($closingTags);
foreach ($closingTags[0] as $key => $match) {
    $commentValue = $closingTags[1][$key];
    if (in_array($commentValue, $semanticTags)) {
        $str = str_replace($match, "</$commentValue>", $str);
    }
}
echo $str;
