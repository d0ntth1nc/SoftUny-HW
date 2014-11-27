function findBiggestTableRow(arr) {
    var regex = /<tr><td>.+<\/td><td>(.+)<\/td><td>(.+)<\/td><td>(.+)<\/td><\/tr>/;
    var maxResult = { result: Number.NEGATIVE_INFINITY, string: "no data" };

    for (var i = 2; i < arr.length - 1; i++) {
        var match = regex.exec(arr[i]);
        var store1 = Number(match[1]) || 0;
        var store2 = Number(match[2]) || 0;
        var store3 = Number(match[3]) || 0;
        var currentResult = store1 + store2 + store3;
        if (currentResult > maxResult.result) {
            var string = currentResult + " = ";
            store1 ? string += match[1] + " + " : 0;
            store2 ? string += match[2] + " + " : 0;
            store3 ? string += match[3] : 0;
            if (store1 || store2 || store3) {
                maxResult = { result: currentResult, string: string };
            }
        }
    }

    var currentString = maxResult.string;
    if (currentString[currentString.length - 2] == '+') {
        currentString = currentString.substring(0, currentString.length - 3);
    }

    console.log(currentString);
}

findBiggestTableRow([
"    <table>                                                                ",
"<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>        ",
"<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>                ",
"<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>           ",
"<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>            ",
"<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>                 ",
"</table>                                                                   ",
]);

findBiggestTableRow([
"<table>                                                                 ",
"<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>     ",
"<tr><td>Sofia</td><td>-</td><td>-</td><td>-</td></tr>                   ",
"</table>"
]);

findBiggestTableRow([
"<table>                                                              ",
"<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>  ",
"<tr><td>Sofia</td><td>12850</td><td>-560</td><td>20833</td></tr>     ",
"<tr><td>Rousse</td><td>-</td><td>50000.0</td><td>-</td></tr>         ",
"<tr><td>Bourgas</td><td>25000</td><td>25000</td><td>-</td></tr>      ",
"</table>                                                             "
]);