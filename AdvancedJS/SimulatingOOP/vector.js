var Vector = (function() {
    function Vector( dimensions ) {
        if (!dimensions || !(dimensions instanceof Array) ||
            !dimensions.length) {
                throw new Error( "Enter dimensions as array object!" );
            }
            
        this.dimensions = dimensions;
    }
    
    function addVectors( left, right, isAddition ) {
        if (left.dimensions.length != right.dimensions.length) {
            throw new Error( "Dimensions must be the same!" );
        }
    
        var dimensions = [];
        for (var i = 0, len = left.dimensions.length; i < len; i++) {
            if (isAddition) {
                dimensions[ i ] = left.dimensions[ i ] + right.dimensions[ i ];
            } else {
                dimensions[ i ] = left.dimensions[ i ] - right.dimensions[ i ];
            }
        }
        
        return new Vector( dimensions );
    }
    
    Vector.prototype.add = function( other ) {
        return addVectors( this, other, true );
    };

    Vector.prototype.substract = function( other ) {
        return addVectors( this, other, false );
    };
    
    Vector.prototype.dot = function( other ) {
        if (this.dimensions.length != other.dimensions.length) {
            throw new Error( "Dimensions must be the same!" );
        }
        
        for (var result = 0, i = 0, len = this.dimensions.length; i < len; i++) {
            result += this.dimensions[ i ] * other.dimensions[ i ];
        }
        
        return result;
    };
    
    Vector.prototype.norm = function() {
        for (var result = 0, i = 0, len = this.dimensions.length; i < len; i++) {
            result += Math.pow( this.dimensions[ i ], 2 );
        }
        return Math.sqrt( result );
    };
    
    Vector.prototype.toString = function() {
        var string = "(" + this.dimensions.join() + ")";
        return string;
    }
    
    return Vector;
}());

var a = new Vector([1, 2, 3]);
var b = new Vector([4, 5, 6]);
var c = new Vector([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]);
console.log(a.norm());
console.log(b.norm());
console.log(c.norm());
console.log(a.add(b).norm());
