/*
    Write a JavaScript function group(persons) that
    groups an array of persons by age, first or last name.
    Create a Person constructor to add every person in the person array.
    The group(persons) function must return an associative array,
    with keys – the groups (age, firstName and lastName) and
    values – arrays with persons in this group.
    Print on the console every entry of the returned associative array.
    Use function overloading (i.e. just one function). 
*/

function Person(firstName, lastName, age) {
    this.firstName = firstName || "";
    this.lastName = lastName || "";
    this.age = age || 0;
}

function group(persons) {
    var groupBy = arguments[1];
    if (!groupBy) return persons;

    var group = {};
    for (var i = 0, len = persons.length; i < len; i++) {
        var person = persons[i];
        var groupName = "Group ";
        switch (groupBy) {
            case "firstname": groupName += person.firstName; break;
            case "lastname": groupName += person.lastName; break;
            case "age": groupName += person.age; break;
        }

        if (!group[groupName]) {
            group[groupName] = [];
        }

        group[groupName].push(
            person.firstName + " " + person.lastName +
            "(age " + person.age + ")"
        );
    }

    return group;
}

var people = [];
people.push(new Person("Scott", "Guthrie", 38));
people.push(new Person("Scott", "Johns", 36));
people.push(new Person("Scott", "Hanselman", 39));
people.push(new Person("Jesse", "Liberty", 57));
people.push(new Person("Jon", "Skeet", 38));

console.log(group(people, 'firstname'));
console.log("------------------");
console.log(group(people, 'age'));
console.log("------------------");
console.log(group(people, 'lastname'));