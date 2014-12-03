<?php
$tags = [];
if (isset($_POST['tags']) && !empty($_POST['tags'])) {
    $tags = explode(", ", $_POST['tags']);
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>01.Print Tags</title>
</head>
<body>
<main>
    <form method="post" action="#">
        Enter Tags: <input type="text" name="tags">
        <input type="submit">
    </form>
    <ol type="1">
        <?php foreach($tags as $tag) :?>
            <li><?=htmlentities($tag)?></li>
        <?php endforeach; ?>
    </ol>
</main>
</body>
</html>