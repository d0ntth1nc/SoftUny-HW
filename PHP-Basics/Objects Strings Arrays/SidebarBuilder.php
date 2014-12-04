<?php
$hasInfo = false;
if (isset( $_GET[ 'categories' ], $_GET[ 'tags' ], $_GET[ 'months' ] )) {
    $categoriesStr = $_GET[ 'categories' ];
    $tagsStr = $_GET[ 'tags' ];
    $monthsStr = $_GET[ 'months' ];
    if (!empty( $categoriesStr ) && !empty( $tagsStr ) && !empty( $monthsStr ) ) {
        $hasInfo = true;
        $categories = explode( ', ', $categoriesStr );
        $tags = explode( ', ', $tagsStr );
        $months = explode( ', ', $monthsStr );
    }
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Sidebar Builder</title>
</head>
<body>
<main>
    <form>
        <label for="categories">Categories:</label>
        <input type="text" name="categories" id="categories">
        <label for="tags">Tags:</label>
        <input type="text" name="tags" id="tags">
        <label for="months">Months:</label>
        <input type="text" name="months" id="months">
        <input type="submit" value="Generate">
    </form>
</main>
<?php if ($hasInfo): ?>
<aside>
    <section>
        <header>
            <h1>Categories</h1>
        </header>
        <ul type="circle">
            <?php foreach ($categories as $category): ?>
            <li><?= htmlentities( $category ) ?></li>
            <?php endforeach; ?>
        </ul>
    </section>
    <section>
        <header>
            <h1>Tags</h1>
        </header>
        <ul type="circle">
            <?php foreach ($tags as $tag): ?>
                <li><?= htmlentities( $tag ) ?></li>
            <?php endforeach; ?>
        </ul>
    </section>
    <section>
        <header>
            <h1>Months</h1>
        </header>
        <ul type="circle">
            <?php foreach ($months as $month): ?>
                <li><?= htmlentities( $month ) ?></li>
            <?php endforeach; ?>
        </ul>
    </section>
</aside>
<?php endif; ?>
</body>
</html>