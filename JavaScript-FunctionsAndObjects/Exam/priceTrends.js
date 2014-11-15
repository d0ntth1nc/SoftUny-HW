function printPriceTrends(input) {
    console.log("<table>");
    console.log("<tr><th>Price</th><th>Trend</th></tr>");

    var lastPrice = Number(input[0]);
    for (var i = 0, len = input.length; i < len; i++) {
        var currentPrice = Number(input[i]);

        var tableRow = "<tr><td>" + currentPrice.toFixed(2) + "</td><td><img src=\"";
        if (lastPrice < currentPrice) {
            tableRow += "up.png" + "\"/></td></tr>";
        } else if (lastPrice > currentPrice) {
            tableRow += "down.png" + "\"/></td></tr>";
        } else {
            tableRow += "fixed.png" + "\"/></td></tr>";
        }

        lastPrice = currentPrice;
        console.log(tableRow);
    }
    console.log("</table>");
}

printPriceTrends([36.33, 36.50, 37.02, 35.40, 35.00, 35.00, 36.23]);