<?php
function isPrime($n) {
    if ($n % 1 || $n < 2) return false;
    if ($n % 2 == 0) return $n == 2 ;
    if ($n % 3 == 0) return $n == 3 ;
    $m = sqrt( $n );
    for ($i = 5; $i <= $m; $i+=6) {
        if ( $n % $i==0 ) return false;
        if ($n % ($i + 2) ==0) return false;
    }
    return true;
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Find Primes in Range</title>
</head>
<body>
<form>
    <label for="start">Starting Index:</label>
    <input type="text" name="start" id="start">
    <label for="end">End:</label>
    <input type="text" name="end" id="end">
    <input type="submit">
</form>
<?php
if (isset( $_GET[ 'start' ] ) && isset( $_GET[ 'end' ] )) {
    if(is_numeric( $_GET[ 'start' ] ) && is_numeric( $_GET[ 'end' ] )) {
        for ($i = intval( $_GET[ 'start' ] ), $count = 0; $i <= intval( $_GET[ 'end' ] ); $i++, $count++) {
            $value = isPrime( $i ) ? "<b>$i</b>" : $i;
            if ($count != 0) echo ', ' . $value;
            else echo $value;
        }
    }
}?>
</body>
</html>