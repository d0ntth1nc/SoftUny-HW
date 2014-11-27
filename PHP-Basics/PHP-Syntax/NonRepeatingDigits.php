<?php

$digits = findDigits(1234);
printResult($digits);

$digits = findDigits(145);
printResult($digits);

$digits = findDigits(15);
printResult($digits);

$digits = findDigits(247);
printResult($digits);

function printResult($digits) {
    if (count($digits) > 0) {
        echo implode(', ', $digits);
    } else {
        echo "no";
    }
    echo "<hr>";
}

function findDigits($n) {
    $array = array();
    if ($n < 100) {
        return $array;
    }

    for ($i = 1; $i <= 9; $i++) {
        for ($j = 0; $j <= 9; $j++) {
            for ($k = 0; $k <= 9; $k ++) {
                if ($i != $j && $j != $k && $k != $i) {
                    $result = "${i}${j}${k}";
                    if ((int)$result <= $n) {
                        array_push($array, $result);
                    }
                }
            }
        }
    }

    return $array;
}