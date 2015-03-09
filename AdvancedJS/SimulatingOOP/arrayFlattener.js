Array.prototype.flatten = function() {
    var newArray = [];
    
    function extractValues( arr ) {
        for (var i = 0, len = arr.length; i < len; i++) {
            var val = arr[ i ];
            
            if (val instanceof Array) {
                extractValues( val );
            } else {
                newArray.push( val );
            }
        }
    }
    
    extractValues( this );
    return newArray;
}

var array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());


