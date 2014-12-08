<!DOCTYPE html>
<html lang="en">
<head>
    <title>Sentence Extractor</title>
</head>
<body>
<main>
    <form>
        <textarea name="text"></textarea>
        <label for="word">Word:</label>
        <input type="text" name="word" id="word">
        <input type="submit" value="Extract">
    </form>
    <?php
    if (isset( $_GET[ 'text' ], $_GET[ 'word' ] ) &&
        !empty( $_GET[ 'text' ] ) && !empty( $_GET[ 'word' ] )):
        $sentences = preg_split( '/(\.|!|\?)/', $_GET[ 'text' ] );
        $validSentences = array_filter( $sentences, function( $val )
        {
            if (!preg_match( '/.|!|\?/', $val )) return false;
            $word = $_GET[ 'word' ];
            return strlen( $val ) && preg_match( "/[^a-zA-Z]".$word."[^a-zA-Z]/", $val );
        });
        foreach ($validSentences as $sentence): ?>
            <p><?= htmlentities( $sentence ) ?></p>
        <?php endforeach; ?>
    <?php endif; ?>
</main>
</body>
</html>