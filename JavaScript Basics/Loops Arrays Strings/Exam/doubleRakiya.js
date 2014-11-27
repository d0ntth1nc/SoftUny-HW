function findDoubleRakiyaNumbers(arr) {
    var start = Number(arr[0]);
    var end = Number(arr[1]);

    console.log("<ul>");

    for (var i = start; i <= end; i++) {
        //if (i > 1000) {
            var numAsString = i.toString();
            var isRakiyaNum = false;

            for (var j = 0; j < numAsString.length - 1; j++) {
                var firstRakiyaNum = numAsString[j] + numAsString[j + 1];
                for (var k = j + 2; k < numAsString.length - 1; k++) {
                    var secondRakiyaNum = numAsString[k] + numAsString[k + 1];
                    if (firstRakiyaNum == secondRakiyaNum) {
                        isRakiyaNum = true;
                        break;
                    }
                }
            }

            printListItem(isRakiyaNum, i);
        //}
    }

    console.log("</ul>");

    function printListItem(isDoubleRakiyaNum, num) {
        var spanClass = isDoubleRakiyaNum ? "rakiya" : "num";
        var listItem =
            "<li>" + "<span class='" + spanClass + "'>" +
            num + "</span>";

        if (isDoubleRakiyaNum) {
            listItem += "<a href=\"view.php?id=" + num + ">" +
                "View</a>";
        }

        listItem += "</li>";

        console.log(listItem);
    }
}

findDoubleRakiyaNumbers(11210, 11215);