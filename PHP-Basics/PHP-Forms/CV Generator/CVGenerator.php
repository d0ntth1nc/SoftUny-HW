<?php
require("validator.php");
$validator = new FormDataParser($_POST);
?>

<!DOCTYPE html>
<html>
<head>
    <title>05.CV Generator</title>
    <style type="text/css">
        table, td, th {
            border: 1px solid black;
        }
    </style>
</head>
<body>
<main>
    <?php if($validator->validate()) {
        include("output.php");
    } else {
        include("form.html");
    }?>
</main>
<script src="script.js"></script>
</body>
</html>