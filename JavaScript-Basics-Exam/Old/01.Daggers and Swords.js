function get(arr) {
    console.log('<table border="1">');
    console.log('<thead>');
    console.log('<tr><th colspan="3">Blades</th></tr>');
    console.log('<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>');
    console.log('</thead>');
    console.log('<tbody>');

    for (var i = 0; i < arr.length; i++) {
        if (arr[i] > 10) {
            var height = Math.floor(parseFloat(arr[i]));
            var bladeType = height > 40 ? "sword" : "dagger";
            var bladeScore = height % 5;
            var bladeName = "";
            switch (bladeScore) {
                case 1: bladeName = "blade"; break;
                case 2: bladeName = "quite a blade"; break;
                case 3: bladeName = "pants-scraper"; break;
                case 4: bladeName = "frog-butcher"; break;
                case 0: bladeName = "*rap-poker"; break;
            }

            console.log('<tr><td>%d</td><td>%s</td><td>%s</td></tr>', height, bladeType, bladeName);
        }
    }

    console.log('</tbody>');
    console.log('</table>');
}