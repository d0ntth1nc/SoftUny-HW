function get(arr) {
    var sortBy = arr[0].split('^')[0];
    var output = { students: [], trainers: [] };
    for (var i = 1; i < arr.length; i++) {
        var person = JSON.parse(arr[i]);
        if (person.role == "student") {
            output.students.push(person);
        } else {
            output.trainers.push(person);
        }
    }

    output.trainers.sort(function (a, b) {
        if (a.courses.length === b.courses.length) {
            return Number(a.lecturesPerDay) - Number(b.lecturesPerDay);
        } else {
            return a.courses.length - b.courses.length;
        }
    });
    output.students.sort(function (a, b) {
        if (sortBy == "name") {
            if (a.firstname == b.firstname) {
                if (a.lastname == b.lastname) return 0;
                return a.lastname < b.lastname ? -1 : 1;
            } else {
                return a.firstname < b.firstname ? -1 : 1;
            }
        } else {
            if (Number(a.level) === Number(b.level)) {
                return Number(a.id) - Number(b.id);
            } else {
                return Number(a.level) - Number(b.level);
            }
        }
    });

    var mapped = {};
    mapped.students = output.students.map(function (a) {
        return {
            id: a.id,
            firstname: a.firstname,
            lastname: a.lastname,
            averageGrade: getAvg(a.grades),
            certificate: a.certificate
        };
    });
    mapped.trainers = output.trainers.map(function (a) {
        return {
            id: a.id,
            firstname: a.firstname,
            lastname: a.lastname,
            courses: a.courses,
            lecturesPerDay: a.lecturesPerDay
        };
    });

    function getAvg(arr) {
        var sum = 0;

        for (var i = 0; i < arr.length; i++) {
            sum += parseFloat(arr[i]);
        }

        return (sum / arr.length).toFixed(2);
    }

    console.log(JSON.stringify(mapped));
}