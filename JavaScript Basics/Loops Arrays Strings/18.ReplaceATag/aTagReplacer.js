/*
    Write a JavaScript function replaceATag(str) that
    replaces in a HTML document given as
    string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].
    Write JS program aTagReplacer.js that invokes your
    function with the sample input data below and prints the output at the console. 
*/

function replaceATag(str) {
    var openTagRegex = /<a\W+/g;
    var closeTagRegex = /<\/a>/g;

    var newStr = str.replace(openTagRegex, "[URL ");
    return newStr.replace(closeTagRegex, "[/URL]");
}

console.log(replaceATag(
"<ul>\n" +
 "\t<li>\n" +
  "\t\t<a href=http://softuni.bg>SoftUni</a>\n" +
 "\t</li>\n" +
"</ul>"
));