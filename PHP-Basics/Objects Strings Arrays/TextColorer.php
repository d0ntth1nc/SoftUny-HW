<!DOCTYPE html>
<html lang="en">
<head>
    <title>Coloring Texts</title>
</head>
<body>
<main>
    <form>
        <textarea name="text"></textarea>
        <input type="submit" value="Color text">
    </form>
    <?php if (isset( $_GET[ 'text' ] )):
        $chars = array_filter( str_split( $_GET[ 'text' ] ), function( $val ) {
            return $val != ' ';
        });
        foreach ($chars as $char):
            $color = ord( $char ) % 2 == 0 ? 'red' : 'blue';
        ?>
            <span style="color:<?= $color ?>;"><?= htmlentities( $char ) ?></span>
        <?php endforeach; ?>
    <?php endif; ?>
</main>
</body>
</html>