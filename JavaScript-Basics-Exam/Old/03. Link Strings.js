function get(arr) {
    for (var i = 0; i < arr.length; i++) {
        var output = {};
        var keyValuePairs = arr[i].split('&');
        for (var j = 0; j < keyValuePairs.length; j++) {
            var keyValuePair = keyValuePairs[j];
            if (keyValuePair.indexOf('?')) {
                keyValuePair = keyValuePair.substring(keyValuePair.indexOf('?') + 1, keyValuePair.length);
            }
            keyValuePair = keyValuePair.split('=');
            var key = keyValuePair[0].replace(/%20+/g, ' ').replace(/\++/g, ' ').split(/ +/).join(' ').trim();
            var value = keyValuePair[1].replace(/%20+/g, ' ').replace(/\++/g, ' ').split(/ +/).join(' ').trim();
            if (!output[key]) {
                output[key] = [];
            }
            output[key].push(value);
        }

        var result = '';
        for (var key in output) {
            result += key + '=' + '[' + output[key].join(', ') + ']';
        }
        console.log(result);
    }
}