<?php
const MONTHS_COUNT = 12;
$months = new DatePeriod(
    new DateTime( "first month" ),
    DateInterval::createFromDateString( 'next month' ),
    MONTHS_COUNT - 1);
?>
<!DOCTYPE html>
<html>
<head>
    <title>Show Annual Expenses</title>
    <style type="text/css">
        table, td, th { border:1px solid black; }
    </style>
</head>
<body>
<form>
    <label for="yearsInput">Enter number of years:</label>
    <input type="text" name="yearsCount" id="yearsInput">
    <input type="submit" value="Show costs">
</form>
<?php if(isset( $_GET[ 'yearsCount' ] ) && is_numeric( $_GET[ 'yearsCount' ] )): ?>
<table>
    <thead>
    <tr>
        <th>Year</th>
        <?php foreach ($months as $date): ?>
            <th><?= $date->format('F') ?></th>
        <?php endforeach; ?>
        <th>Total:</th>
    </tr>
    </thead>
    <tbody>
    <?php for ($year = date( 'Y' ); $year > date( 'Y' ) - $_GET[ 'yearsCount' ]; $year--): ?>
    <tr>
        <td><?= $year ?></td>
        <?php for ($i = 0, $total = 0; $i < MONTHS_COUNT; $i++): ?>
            <td><?php
                $current = rand(0, 999);
                $total += $current;
                echo $current;
                ?></td>
        <?php endfor; ?>
        <td><?= $total ?></td>
    </tr>
    <?php endfor; ?>
    </tbody>
</table>
<?php endif; ?>
</body>
</html>