document.getElementById("btnHideOddRows").onclick =  function () {
    var oddTableRows = document.body.querySelectorAll("tr:nth-child(odd)");
    for (var i = 0, len = oddTableRows.length; i < len; i++) {
        oddTableRows[i].style.display = "none";
    }
};