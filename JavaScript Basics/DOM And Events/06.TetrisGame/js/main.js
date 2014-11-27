"use strict";

var Keys = { spaceBar: 32, left: 37, up: 38, right: 39, down: 40 };

var table = (function () {
    var table = document.getElementById("gameField");

    var module = {
        init: function () {
            for (var i = 0; i < 20; i++) {
                var tableRow = table.insertRow();
                for (var j = 0; j < 11; j++) {
                    tableRow.insertCell().dataset.value = false;
                }
            }
        },

        clearActive: function () {
            var activeCells = table.querySelectorAll("td.active");
            for (var i = 0; i < activeCells.length; i++) {
                activeCells[i].removeAttribute("class");
            }
        },

        clearLastLine: function() {
            var tableRow = table.rows(table.rows.length - 1);
            for (var i = 0; i < tableRow.length; i++) {
                tableRow.cell(i).dataset.value = false;
            }
        }
    };

    return module;
}());

table.init();

var figure = new TetrisFigure(table);

figure.draw();

document.addEventListener("keyup", function (e) {
    e.preventDefault();

    if (e.keyCode == Keys.spaceBar) {
        figure.rotate();
    }

    if (e.keyCode == Keys.down) {
        figure.moveDown();
    }
});