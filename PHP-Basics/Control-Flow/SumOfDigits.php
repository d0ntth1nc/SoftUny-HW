<!DOCTYPE html>
<html>
<head>
    <title>Sum Of Digits</title>
    <style type="text/css">
        table, td, th { border: 1px solid black; }
    </style>
</head>
<body>
<form>
    <label for="inputString">Input string:</label>
    <input type="text" name="inputString" id="inputString">
    <input type="submit">
</form>
<?php if (isset( $_GET[ 'inputString' ] )): ?>
<table>
    <tbody>
    <?php foreach (explode( ',', $_GET[ 'inputString' ] ) as $num): ?>
        <tr>
            <td><?= $num ?></td>
            <td>
                <?= is_numeric( $num ) ? array_sum( str_split( trim( $num ) )) : 'I cannot sum that'; ?>
            </td>
        </tr>
    <?php endforeach; ?>
    </tbody>
</table>
<?php endif; ?>
</body>
</html>