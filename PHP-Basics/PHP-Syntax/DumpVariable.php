<?php

$string = "hello";
printVariableType($string);

$int = 15;
printVariableType($int);

$float = 1.234;
printVariableType($float);

$array = array(1, 2, 3);
printVariableType($array);

$object = (object) ['property' => 'Here we go'];
printVariableType($object);

function printVariableType($variable) {
    if (is_numeric($variable)) {
        var_dump($variable);
    } else {
        echo gettype($variable);
    }
    ?>
<br/>
<?php
}
?>