var continentsSelector = document.getElementById("continents-holder");
var countriesSelector = document.getElementById("countries-holder");

continentsSelector.addEventListener("change", function(e) {
    var value = e.target.options[e.target.selectedIndex].text;
    if (!value) {
        countriesSelector.innerHTML = '';
        return;
    }
    var result = httpGet(value);
    if (result) {
        changeOptions(JSON.parse(result));
    }
});

function httpGet(value) {
    var url = "countriesProvider.php";

    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open( "GET", url + "?continent=" + value, false );
    xmlHttp.send();
    return xmlHttp.responseText;
}

function changeOptions(options) {
    countriesSelector.innerHTML = '';
    var docFragment = document.createDocumentFragment();
    for (var i = 0, len = options.length; i < len; i++) {
        var option = document.createElement("option");
        option.text = options[i];
        docFragment.appendChild(option);
    }
    countriesSelector.appendChild(docFragment);
}