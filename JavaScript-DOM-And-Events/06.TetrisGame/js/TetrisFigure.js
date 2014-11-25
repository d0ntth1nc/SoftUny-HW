"use strict";

var TetrisFigure;
(function () {
    var FigureTypes = ['O', 'I', 'J', 'S', 'L', 'Z', 'T'];
    var tableElement = document.getElementById("gameField");

    function generateRandomType() {
        var randomIndex = Math.floor(Math.random() * FigureTypes.length);
        var type = FigureTypes[randomIndex];
        var figure = [];
        switch (type) {
            case 'O':
                figure.push([true, true]);
                figure.push([true, true]);
                break;
            case 'I':
                figure.push([true]);
                figure.push([true]);
                figure.push([true]);
                figure.push([true]);
                break;
            case 'J':
                figure.push([false, true]);
                figure.push([false, true]);
                figure.push([true, true]);
                break;
            case 'S':
                figure.push([true, false]);
                figure.push([true, true]);
                figure.push([false, true]);
                break;
            case 'L':
                figure.push([true, false]);
                figure.push([true, false]);
                figure.push([true, true]);
                break;
            case 'Z':
                figure.push([false, true]);
                figure.push([true, true]);
                figure.push([true, false]);
                break;
            case 'T':
                figure.push([true, true, true]);
                figure.push([false, true, false]);
                break;
        }
        return figure;
    }

    TetrisFigure = function (table) {
        this.position = { left: Math.floor(tableElement.dataset.colsCount / 2), right: 0 };
        this.table = table;
        this.figure = generateRandomType();
    }

    TetrisFigure.prototype = {
        draw: function () {
            var figureHeight = this.figure.length;
            var figureWidth = this.figure[0].length;
            var tableMiddleCell = Math.floor(tableElement.dataset.colsCount / 2) - Math.floor(figureWidth / 2);

            for (var row = 0; row < figureHeight; row++) {
                for (var col = 0; col < figureWidth; col++) {
                    var tableCell = tableElement.rows[row].cells[col + tableMiddleCell];
                    if (this.figure[row][col]) {
                        tableCell.addAttribute("class", "active");
                    }
                }
            }
        },

        moveDown: function () {

        },

        freeze: function () {},

        rotate: function () {
            this.table.clear();
            var newFigure = [];
            for (var col = 0; col < this.figure[0].length; col++) {
                newFigure.push([]);
                for (var row = this.figure.length - 1; row >= 0; row--) {
                    newFigure[col].push(this.figure[row][col]);
                }
            }
            this.figure = newFigure;
            this.draw();
        }
    };
}());