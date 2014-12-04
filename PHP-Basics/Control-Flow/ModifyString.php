<?php
function isPalindrome( $str ) {
    $chars = str_split( $str );
    for ($i = 0, $count = count( $chars ); $i < ceil( $count / 2 ); $i++) {
        if ($chars[ $i ] != $chars[ $count - 1 - $i ]) {
            return false;
        }
    }
    return true;
}

if (isset( $_GET[ 'inputString' ], $_GET[ 'op' ] ) &&
    !empty( $_GET[ 'inputString' ] )) {
    $str = $_GET[ 'inputString' ];
    switch ($_GET[ 'op' ]) {
        case 'reverse':
            $output = strrev( $str );
            break;
        case 'split':
            $letters = [];
            preg_match_all( '/[a-zA-Z]/', $str, $letters );
            $output = implode( ' ', $letters[0] );
            break;
        case 'hash':
            $output = crypt( $str, 'defsalt' );
            break;
        case 'shuffle':
            $output = str_shuffle( $str );
            break;
        default:
            $output = isPalindrome( $str ) ? $str . ' is palindrome!' : $str . ' is not a palindrome!';
            break;
    }
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Modify String</title>
</head>
<body>
<form>
    <input type="text" name="inputString">
    <input type="radio" name="op" value="isPalindrome" id="isPalindrome" checked>
    <label for="isPalindrome">Check Palindrome</label>
    <input type="radio" name="op" value="reverse" id="reverse">
    <label for="reverse">Reverse String</label>
    <input type="radio" name="op" value="split" id="split">
    <label for="split">Split</label>
    <input type="radio" name="op" value="hash" id="hash">
    <label for="hash">Hash String</label>
    <input type="radio" name="op" value="shuffle" id="shuffle">
    <label for="shuffle">Shuffle String</label>
    <input type="submit">
</form>
<?php if (isset( $output )): ?>
    <p><?= htmlspecialchars( $output ) ?></p>
<?php endif; ?>
</body>
</html>