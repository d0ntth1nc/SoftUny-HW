<?php
if (isset( $_GET[ 'words' ] ) && !empty( $_GET[ 'words' ] )) {
    $allWords = preg_split( '/\W+/', $_GET[ 'words' ], null, PREG_SPLIT_NO_EMPTY );
    $words = [];
    foreach ($allWords as $word) {
        if (!isset( $words[ strtolower( $word ) ] )) {
            $words[ strtolower( $word ) ] = 0;
        }
        $words[ strtolower( $word ) ]++;
    }
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Word Mapper</title>
</head>
<body>
<main>
    <form>
        <textarea name="words"></textarea>
        <input type="submit" value="Count words">
    </form>
    <?php if (isset( $words )): ?>
    <table>
        <tbody>
            <?php foreach ($words as $word => $count): ?>
            <tr>
                <td><?= htmlspecialchars( $word ) ?></td>
                <td><?= $count ?></td>
            </tr>
            <?php endforeach; ?>
        </tbody>
    </table>
    <?php endif; ?>
</main>
</body>
</html>