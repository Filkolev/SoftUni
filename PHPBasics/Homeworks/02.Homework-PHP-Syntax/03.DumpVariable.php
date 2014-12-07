<?php
    function dumpVariable($var) {
        if (gettype($var) == 'integer' || gettype($var) == 'double') {
          var_dump($var);
        } else {
            echo gettype($var) . "\n";
        }
    }

    dumpVariable("hello");
    dumpVariable(15);
    dumpVariable("1.234");
    dumpVariable(array(1,2,3));
    dumpVariable((object)[2,34]);
?>