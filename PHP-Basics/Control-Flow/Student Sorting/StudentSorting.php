<?php
include_once( 'sorter.php' );
$studentsSorter = new StudentsSorter( $_POST );
?>
<!DOCTYPE html>
<html>
<head>
    <title>Student Sorting</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<?php
include_once( 'form.html' );
if ($studentsSorter->studentsCount() > 0):
    $students = $studentsSorter->sort( $_POST[ 'orderBy' ], $_POST[ 'order' ] );
    $totalScore = 0;
?>
<table>
<thead>
<tr>
    <th>First name:</th>
    <th>Second name:</th>
    <th>Email:</th>
    <th>Exam score:</th>
</tr>
</thead>
    <tbody>
    <?php foreach ($students as $student): $totalScore += $student[ 'grade' ]?>
        <tr>
            <td><?=htmlentities( $student[ 'firstName' ] )?></td>
            <td><?=htmlentities( $student[ 'lastName' ] )?></td>
            <td><?=htmlentities( $student[ 'email' ] )?></td>
            <td><?=htmlentities( $student[ 'grade' ] )?></td>
        </tr>
    <?php endforeach; ?>
    <tr>
        <td colspan="3">Average Score:</td>
        <td><?=round( $totalScore / $studentsSorter->studentsCount() )?></td>
    </tr>
    </tbody>
</table>


<?php endif; ?>
<script src="script.js"></script>
</body>
</html>