function get(arr) {
    var notebook = {};
    for (var i = 0; i < arr.length; i++) {
        var info = arr[i].trim().split('|');
        var color = info[0];
        if (!notebook[color]) {
            notebook[color] = { age: undefined, name: undefined, opponents: [], rank: 0, loss: 0, win: 0 };
        }
        if (info[1] == "loss" || info[1] == "win") {
            notebook[color].opponents.push(info[2]);
            if (info[1] == "loss") {
                notebook[color].loss++;
            } else {
                notebook[color].win++;
            }
        } else {
            notebook[color][info[1]] = info[2];
        }
    }

    var output = {};
    var colors = Object.keys(notebook).sort();
    for (var i = 0; i < colors.length; i++) {
        if (notebook[colors[i]].name && notebook[colors[i]].age) {
            output[colors[i]] = {
                age: notebook[colors[i]].age,
                name: notebook[colors[i]].name,
                opponents: notebook[colors[i]].opponents.sort(),
                rank: ((notebook[colors[i]].win + 1) / (notebook[colors[i]].loss + 1)).toFixed(2)
            };
        }
    }

    console.log(JSON.stringify(output));
}