<?php
$tags = [];
if (isset($_POST['tags']) && !empty($_POST["tags"])) {
    foreach (explode(", ", $_POST['tags']) as $tag) {
        if (isset($tags[$tag])) {
            $tags[$tag] += 1;
        } else {
            $tags[$tag] = 1;
        }
    }
}
arsort($tags);
?>
<!DOCTYPE html>
<html>
<head>
    <title>02.Most Frequent Tag</title>
</head>
<body>
<main>
    <form method="post" action="#">
        Enter Tags: <input type="text" name="tags">
        <input type="submit">
    </form>
    <dl>
        <?php foreach($tags as $tagName => $occurrences) :?>
            <dt><?=htmlentities($tagName)?></dt>
            <dd><?=$occurrences?> times</dd>
        <?php endforeach; ?>
    </dl>
    <?php if(reset($tags)) :?>
        <p>Most Frequent Tag is: <?= htmlentities(key($tags)) ?></p>
    <?php endif; ?>
</main>
</body>
</html>