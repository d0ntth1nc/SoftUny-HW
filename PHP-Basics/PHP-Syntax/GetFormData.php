<?php
$info = "";
if (isset($_POST['name']) && isset($_POST['age']) && isset($_POST['sex'])) {
    $info = "My name is $_POST[name]. I am $_POST[age] years old. I am $_POST[sex].";
    //unset($_POST['name']);
    //unset($_POST['age']);
    //unset($_POST['sex']);
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Get Form Data</title>
</head>
<body>
    <form action="GetFormData.php" method="post">
        <input type="text" name="name" placeholder="Name...">
        <input type="text" name="age" placeholder="Age...">
        <input type="radio" name="sex" value="male" id="male-radio">
        <label for="male-radio">Male</label>
        <input type="radio" name="sex" value="female" id="female-radio">
        <label for="female-radio">Female</label>
        <input type="submit" value="Submit">
    </form>
<p><?= $info ?></p>
</body>
</html>