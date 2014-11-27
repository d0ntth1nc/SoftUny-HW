"use strict";

var table = (function () {
    var table = document.getElementById("gameField");

    var module = {
        init: function() {
            for (var i = 0; i < 20; i++) {
                var tableRow = table.insertRow();
                for (var j = 0; j < 10; j++) {
                    tableRow.insertCell();
                }
            }
        },

        clear: function () {
            var activeCells = table.querySelectorAll("td.active");
            for (var i = 0; i < activeCells.length; i++) {
                activeCells[i].removeAttribute("class");
            }
        }
    };

    return module;
}());