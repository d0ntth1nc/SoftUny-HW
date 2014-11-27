/*
    Write a JavaScript function findYoungestPerson(persons) that
    accepts as parameter an array of persons,
    finds the youngest person and returns his full name.
    Write a JS program youngestPerson.js to execute your function for
    the below examples and print the result at the console.
*/

function findYoungestPerson(persons) {
    persons.sort(function (left, right) {
        return left.age - right.age;
    });

    return persons[0].firstname + ' ' + persons[0].lastname;
}

var persons = [
  { firstname: 'George', lastname: 'Kolev', age: 92 }, // Changed value!!!
  { firstname: 'Bay', lastname: 'Ivan', age: 81 },
  { firstname: 'Baba', lastname: 'Ginka', age: 40 }];

var youngestPersonName = findYoungestPerson(persons);
console.log("The youngest person is %s", youngestPersonName);