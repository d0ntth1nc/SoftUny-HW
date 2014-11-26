<?php

$firstNumber = 2;
$secondNumber = 5;
printResult($firstNumber, $secondNumber);

$firstNumber = 1.567808;
$secondNumber = 0.356;
printResult($firstNumber, $secondNumber);

$firstNumber = 1234.5678;
$secondNumber = 333;
printResult($firstNumber, $secondNumber);

function printResult($firstNumber, $secondNumber) {
    $result = (float)($firstNumber + $secondNumber);
    echo '$firstNumber + $secondNumber = ';
    echo "$firstNumber + $secondNumber = " . number_format($result, 2, '.', '') . "<br/>";
}