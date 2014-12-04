<?php
$w3schools = file_get_contents('http://www.w3schools.com/cssref/css_colornames.asp');
$colors = [];
preg_match_all('/<td><a.+>(.+)<\/a>&nbsp;<\/td>/', $w3schools, $colors);

const MAX_COUNT = 5;
const MIN_COUNT = 1;
if (isset( $_GET[ 'cars' ] ) && !empty( $_GET[ 'cars' ] )) {
    $cars = [];
    $carsArray = explode(',', $_GET['cars']);
    foreach ($carsArray as $car) {
        $color = $colors[ 1 ][ rand( 0, count( $colors[ 1 ] ) ) ];
        $cars[ trim( $car ) ] =
            ['color' => $color,
                'count' => rand( MIN_COUNT, MAX_COUNT )];
    }
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Rich People's Problems</title>
    <style type="text/css">
        table, td, th { border:1px solid black; }
    </style>
</head>
<body>
<form>
    <label for="carsInput">Enter cars</label>
    <input type="text" name="cars" id="carsInput">
    <input type="submit" value="Show result">
</form>
<?php if(isset( $cars )): ?>
<table>
    <thead>
    <tr>
        <th>Car</th>
        <th>Color</th>
        <th>Count</th>
    </tr>
    </thead>
    <tbody>
    <?php foreach ($cars as $car => $values): ?>
    <tr>
        <td><?= htmlentities($car) ?></td>
        <td><?= strtolower($values['color']) ?></td>
        <td><?= $values['count'] ?></td>
    </tr>
    <?php endforeach; ?>
    </tbody>
</table>
<?php endif; ?>
</body>
</html>