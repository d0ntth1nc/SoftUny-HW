function sortTable(arr) {
    var regex = /<td>(.*?)<\/td><td>(.*?)<\/td>/;

    var tableRows = [];
    for (var i = 2; i < arr.length - 1; i++) {
        var match = regex.exec(arr[i]);
        var row = { name : match[1], price: match[2], data: arr[i] };
        tableRows.push(row);
    }

    tableRows.sort(function (left, right) {
        if (left.price != right.price) {
            return left.price - right.price;
        } else {
            if (left.name == right.name) {
                return 0;
            } else {
                return left.name < right.name ? -1 : 1;
            }
        }
    });

    console.log(arr[0]);
    console.log(arr[1]);
    for (var i = 0; i < tableRows.length; i++) {
        console.log(tableRows[i].data);
    }
    console.log(arr[arr.length - 1]);
}

var asd = [
"<table>",
"<tr><th>Product</th><th>Price</th><th>Votes</th></tr>",
"<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>",
"<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>",
"<tr><td>Laptop HP 250 G2</td><td>629</td><td>+1</td></tr>",
"<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>",
"<tr><td>Ariana Grapefruit 1.5 l</td><td>1.85</td><td>+7</td></tr>",
"<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>",
"</table>"
];

sortTable(asd);