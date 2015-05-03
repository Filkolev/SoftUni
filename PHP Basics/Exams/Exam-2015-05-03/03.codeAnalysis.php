<?php

$variablePattern = '/\$[\w]+/';
$conditionalStatementPattern = '/((?:else\s*)*if\s+\((?:[\s\S]+?)\))\s+\{/';
$loopPattern = '/((?:for|while|foreach)\s+\((?:.*?)\))\s+\{/';

preg_match_all($variablePattern, $_GET['code'], $variables);
preg_match_all($conditionalStatementPattern, $_GET['code'], $conditionals);
preg_match_all($loopPattern, $_GET['code'], $loops);

$data = [
    'variables' => [],
    'loops' => [
        'while' => [],
        'for' => [],
        'foreach' => []
    ],
    'conditionals' => []
];

foreach ($variables[0] as $variable) {
    if (!isset($data['variables'][$variable])) {
        $data['variables'][$variable] = 0;
    }

    $data['variables'][$variable]++;
}

foreach ($loops[1] as $loop) {
    $loopType = explode(" ", $loop)[0];
    $data['loops'][$loopType][] = $loop;
}

$data['conditionals'] = $conditionals[1];

echo json_encode($data);