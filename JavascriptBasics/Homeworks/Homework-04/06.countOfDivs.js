function countDivs(html) {
    var openingTags = html.split(/<div[^<>]*>/g).length - 1;
    var closingTags = html.split(/<\/div>/g).length - 1;

    return Math.min(openingTags, closingTags);
}

var checkValue = [
    '<!DOCTYPE html>',
    '<html>',
    '<head lang="en">',
    '    <meta charset="UTF-8">',
    '    <title>index</title>',
    '    <script src="/yourScript.js" defer></script>',
    '</head>',
    '<body>',
    '    <div id="outerDiv">',
    '        <div',
    '    class="first">',
    '            <div><div>hello</div></div>',
    '        </div>',
    '        <div>hi<div></div></div>        ',
    '        <div>I am a div</div>',
    '    </div>',
    '</body>',
    '</html>'
].join('');

console.log(countDivs(checkValue));