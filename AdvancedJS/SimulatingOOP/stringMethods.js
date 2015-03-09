String.prototype.startsWith = function( substring ) {
    var thisLen = this.length,
        substrLen = substring.length;
        
    if (thisLen < substrLen) {
        return false;
    }
    
    for (var i = 0; i < substrLen; i++) {
        if (this[ i ] != substring[ i ]) {
            return false;
        }
    }
    
    return true;
};

String.prototype.endsWith = function( substring ) {
    var thisLen = this.length,
        substrLen = substring.length;
        
    if (thisLen < substrLen) {
        return false;
    }
    
    for (var i = thisLen - substrLen, j = 0; i < thisLen; i++, j++) {
        if (this[ i ] != substring[ j ]) {
            return false;
        }
    }
    
    return true;
};

String.prototype.left = function( count ) {
    return this.substr( 0, count );
};

String.prototype.right = function( count ) {
    var thisLen = this.length;
    
    if (count >= thisLen) {
        return this.toString();
    } else {
        return this.substr( thisLen - count, thisLen );
    }
};

String.prototype.padLeft = function( count, character ) {
    var ch = character || " ";
    var result = ch.repeat( count ) + this;
    return result;
};

String.prototype.padRight = function( count, character ) {
    var ch = character || " ";
    var result = this + ch.repeat( count );
    return result;
};

String.prototype.repeat = function( count ) {
    var repeat = [];
    
    for (var i = 0; i < count; i++) {
        repeat[ i ] = this;
    }
    
    return repeat.join( '' );
};

// Another combination
console.log("*".repeat(5).padLeft(10, "-").padRight(15, "+"));
