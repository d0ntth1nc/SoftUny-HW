"use strict";

Element.prototype.remove = function() {
    this.parentElement.removeChild(this);
};

var pLangsInputsHolder =
    document.getElementById("programmingLanguagesInputs");
var langsInputsHolder =
    document.getElementById("languagesInputs");

//Cache templates
var pLangsTemplate = pLangsInputsHolder
    .querySelector("div")
    .innerHTML;
var langsTemplate = langsInputsHolder
    .querySelector("div")
    .innerHTML;

function addFields(holder) {
    var parentNode = document.getElementById(holder);
    var newElement = document.createElement("div");
    if (parentNode == pLangsInputsHolder) {
        newElement.innerHTML = pLangsTemplate;
    } else {
        newElement.innerHTML = langsTemplate;
    }
    parentNode.appendChild(newElement);
}

function removeFields(holder) {
    var parentNode = document.getElementById(holder);
    var lastElement = parentNode
        .querySelector("div:last-child");
    // We need at least 1 field
    if (lastElement != parentNode.querySelector("div:first-child")) {
        lastElement.remove();
    }
}