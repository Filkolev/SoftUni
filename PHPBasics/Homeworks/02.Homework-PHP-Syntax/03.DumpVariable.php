<?php
    function dumpVariable($var) {
        if (is_numeric($var)) {
          var_dump($var);
        } else {
            echo gettype($var) . "\n";
        }
    }

    dumpVariable("hello");
    dumpVariable(15);
    dumpVariable(1.234);
    dumpVariable(array(1,2,3));
    dumpVariable((object)[2,34]);
?>
 