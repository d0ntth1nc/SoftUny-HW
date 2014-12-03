<?php
session_start();
if (!isset($_SESSION['score'])) {
    $_SESSION['score'] = 0;
    $_SESSION['tags'] = [];
}

if (isset($_POST['tag']) && !empty($_POST['tag'])) {
    // Get all possible tags from the official website
    $html = file_get_contents("http://www.w3schools.com/tags/");
    $regex = "/<td.*><a.+>(.+)<\/a><\/td>/";
    $result = [];
    preg_match_all($regex, $html, $result);

    $tag = $_POST['tag'];
    $htmlTag = "<$tag>";

    $isValid = in_array(htmlspecialchars($htmlTag), $result[1]);
    if($isValid) {
        $_SESSION['score']++;
        $_SESSION['tags'][] = $tag;
    }
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>02.Most Frequent Tag</title>
</head>
<body>
<main>
    <form method="post" action="#">
        <label for="tag">Enter HTML Tags:</label>
        <input type="text" name="tag" id="tag">
        <input type="submit">
    </form>
    <?php if (isset($isValid)) :?>
    <h2><?=$isValid ? "Valid" : "Invalid"?> HTML tag!</h2>
    <?php endif; ?>
    <h2>Score: <?=$_SESSION['score']?></h2>
</main>
</body>
</html>