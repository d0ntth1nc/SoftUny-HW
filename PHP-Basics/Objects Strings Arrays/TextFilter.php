<!DOCTYPE html>
<html lang="en">
<head>
    <title>Text Filter</title>
</head>
<body>
<main>
    <form>
        <textarea name="text"></textarea>
        <label for="banlist">BanList:</label>
        <input type="text" name="banlist" id="banlist">
        <input type="submit" value="Filter">
    </form>
    <?php
    if (isset( $_GET[ 'text' ], $_GET[ 'banlist' ] ) &&
        !empty( $_GET[ 'text' ] ) && !empty( $_GET[ 'banlist' ] )) {
        $text = $_GET[ 'text' ];
        $banList = explode( ', ', $_GET[ 'banlist' ] );
        foreach ($banList as $bannedItem) {
            $censoredStr = str_repeat( '*', strlen( $bannedItem ) );
            $text = str_replace( $bannedItem, $censoredStr, $text );
        }
        echo htmlentities( $text );
    }
    ?>
</main>
</body>
</html>