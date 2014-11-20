function groupFilesByExt(arr) {
    var filesGroups = {};

    for (var i = 0, length = arr.length; i < length; i++) {
        var fileInfo = arr[i].trim().split(' ');
        var fileName = fileInfo[0];
        var fileExt = fileInfo[1];
        var fileSize = Number(fileInfo[2].substring(0, fileInfo[2].length - 2));

        if (!filesGroups[fileExt]) {
            filesGroups[fileExt] = {
                files: [], memory: 0
            };
        }

        filesGroups[fileExt].files.push(fileName);
        filesGroups[fileExt].memory += fileSize;
    }

    var sortedExtensions = Object.keys(filesGroups).sort();
    var sortedGroups = {};
    for (var i = 0, length = sortedExtensions.length; i < length; i++) {
        var key = sortedExtensions[i];
        sortedGroups[key] = {
            files: filesGroups[key].files.sort(),
            memory: filesGroups[key].memory.toFixed(2)
        };
    }

    console.log(JSON.stringify(sortedGroups));
}

groupFilesByExt([
"    sentinel .exe 15MB     ",
"zoomIt .msi 3MB            ",
"skype .exe 45MB            ",
"trojanStopper .bat 23MB    ",
"kindleInstaller .exe 120MB ",
"setup .msi 33.4MB          ",
"winBlock .bat 1MB          "
]);