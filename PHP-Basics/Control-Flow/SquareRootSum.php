<!DOCTYPE html>
<html>
<body>
<table>
    <thead>
    <tr>
        <th>Number</th>
        <th>Square</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>0</td>
        <td>0</td>
    </tr>
    <?php for($i = 2; $i <= 100; $i += 2):
        static $sum = 0;
        $current = round( sqrt( $i ), 2 );
        $sum += $current;
        ?>
        <tr>
            <td><?=$i?></td>
            <td><?=$current?></td>
        </tr>
    <?php endfor; ?>
    <tr>
        <td>Total:</td>
        <td><?=round( $sum, 2 )?></td>
    </tr>
    </tbody>
</table>
</body>
</html>