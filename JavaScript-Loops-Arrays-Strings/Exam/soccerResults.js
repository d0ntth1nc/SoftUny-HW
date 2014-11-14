function printSoccerResult(arr) {
    var regex = /(.+)\/(.+):(.+)-(.+)/;

    var matchesResults = {};

    for (var i = 0; i < arr.length; i++) {
        var match = regex.exec(arr[i]);
        var leftTeam = match[1].trim();
        var rightTeam = match[2].trim();
        var leftResult = Number(match[3]);
        var rightResult = Number(match[4]);

        if (!matchesResults[leftTeam]) {
            matchesResults[leftTeam] = {
                goalsScored: 0, goalsConceded: 0, matchesPlayedWith: []
            };
        }

        if (!matchesResults[rightTeam]) {
            matchesResults[rightTeam] = {
                goalsScored: 0, goalsConceded: 0, matchesPlayedWith: []
            };
        }

        matchesResults[leftTeam].goalsScored += leftResult;
        matchesResults[leftTeam].goalsConceded += rightResult;
        if (matchesResults[leftTeam].matchesPlayedWith.indexOf(rightTeam) < 0) {
            matchesResults[leftTeam].matchesPlayedWith.push(rightTeam);
        }

        matchesResults[rightTeam].goalsScored += rightResult;
        matchesResults[rightTeam].goalsConceded += leftResult;
        if (matchesResults[rightTeam].matchesPlayedWith.indexOf(leftTeam) < 0) {
            matchesResults[rightTeam].matchesPlayedWith.push(leftTeam);
        }
    }

    var sortedTeams = Object.keys(matchesResults).sort();
    var sortedResults = {};
    for (var i = 0; i < sortedTeams.length; i++) {
        sortedResults[sortedTeams[i]] = matchesResults[sortedTeams[i]];
        sortedResults[sortedTeams[i]].matchesPlayedWith.sort();
    }

    console.log(JSON.stringify(sortedResults));
}

printSoccerResult([
    "Germany / Argentina: 1-0",
    "Brazil / Netherlands: 0-3",
    "Netherlands / Argentina: 0-0",
    "Brazil / Germany: 1-7",
    "Argentina / Belgium: 1-0",
    "Netherlands / Costa Rica: 0-0",
    "France / Germany: 0-1",
    "Brazil / Colombia: 2-1",
]);