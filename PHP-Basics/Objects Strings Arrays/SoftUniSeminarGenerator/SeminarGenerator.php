<?php include( 'seminar.php' ); ?>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>SoftUni Seminar Generator</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<main style="width:700px;margin:auto;">
    <form method="post">
        <textarea name="text"></textarea>
        <label for="orderBy">Sort by:</label>
        <select name="orderBy" id="orderBy">
            <option value="date">Date</option>
            <option value="date">Name</option>
        </select>
        <label for="order">Order:</label>
        <select name="order" id="order">
            <option value="ascending">Ascending</option>
            <option value="descending">Descending</option>
        </select>
        <input type="submit">
    </form>
    <?php if(isset( $seminars )): ?>
    <table id="main-table">
        <thead>
        <tr>
            <th>Seminar name</th>
            <th>Date</th>
            <th>Participate</th>
        </tr>
        </thead>
        <tbody>
        <?php foreach ($seminars as $seminar): ?>
            <tr>
                <td>
                    <a href=""><?= htmlspecialchars( $seminar->name ) ?></a>
                    <div class="details-box">
                        <p>
                            <span class="details-info">Lecturer:</span>
                            <?= htmlspecialchars( $seminar->lecturer ); ?>
                        </p>
                        <p>
                            <span class="details-info">Details:</span>
                            <?= htmlspecialchars( $seminar->details ); ?>
                        </p>
                    </div>
                </td>
                <td><?= htmlspecialchars( $seminar->date ) ?></td>
                <td>
                    <button type="button">Sign Up</button>
                </td>
            </tr>
        <?php endforeach; ?>
        </tbody>
    </table>
    <?php endif; ?>
</main>
<script src="script.js"></script>
</body>
</html>