function getjSon(arr) {
    var courses = {};

    for (var i = 0; i < arr.length; i++) {
        var items = arr[i].split('|');
        var student = items[0].trim();
        var course = items[1].trim();
        var score = Number(items[2].trim());
        var visits = Number(items[3].trim());

        if (!courses[course]) {
            courses[course] = { scores: [], visits: [], students: []};
        }

        courses[course].scores.push(score);
        courses[course].visits.push(visits);
        if (courses[course].students.indexOf(student) < 0) {
            courses[course].students.push(student);
        }
    }

    var sorted = {}
    var sortedKeys = Object.keys(courses).sort();
    for (var i = 0; i < sortedKeys.length; i++) {
        var key = sortedKeys[i];

        var scoresCount = courses[key].scores.length;
        var avgScore = courses[key].scores.reduce(function (a, b) { return a + b });
        avgScore = (avgScore / scoresCount);
        avgScore = Math.round(avgScore * 100) / 100;

        var visitsCount = courses[key].visits.length;
        var avgVisits = courses[key].visits.reduce(function (a, b) { return a + b });
        avgVisits = (avgVisits / visitsCount);
        avgVisits = Math.round(avgVisits * 100) / 100;

        sorted[key] = {
            avgGrade: avgScore,
            avgVisits: avgVisits,
            students: courses[key].students.sort()
        };
    }

    console.log(JSON.stringify(sorted));
}

getjSon([
"    Peter Nikolov | PHP  | 5.50 | 8                    ",
"Maria Ivanova | Java | 5.83 | 7                        ",
"            Ivan Petrov   | PHP  | 3.00 | 2            ",
"            Ivan Petrov   | C#   | 3.00 | 2            ",
"            Peter Nikolov | C#   | 5.50 | 8            ",
"            Maria Ivanova | C#   | 5.83 | 7            ",
"            Ivan Petrov   | C#   | 4.12 | 5            ",
"            Ivan Petrov   | PHP  | 3.10 | 2            ",
"            Peter Nikolov | Java | 6.00 | 9            "

]);