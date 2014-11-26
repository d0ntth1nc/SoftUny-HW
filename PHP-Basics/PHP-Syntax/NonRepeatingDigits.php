<?php

findDigits(1234);
echo "<hr>";
findDigits(145);
echo "<hr>";
findDigits(15);
echo "<hr>";
findDigits(247);

function findDigits($n) {
    if ($n < 100) {
        echo "no";
        return;
    }

    $array = array();
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
    echo implode(', ', $array);
}