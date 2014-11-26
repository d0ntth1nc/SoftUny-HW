<?php
$name = 'Gosho';
$phoneNumber = "0882-321-213";
$age = 24;
$address = "Hadji Dimitar";
?>
<!DOCTYPE html>
<html>
<head>
    <title>Information Table</title>
</head>
<body>
<table>
    <tbody>
        <tr>
            <td>Name</td>
            <td><?= $name ?></td>
        </tr>
        <tr>
            <td>Phone Number</td>
            <td><?= $phoneNumber ?></td>
        </tr>
        <tr>
            <td>Age</td>
            <td><?= $age ?></td>
        </tr>
        <tr>
            <td>Address</td>
            <td><?= $address ?></td>
        </tr>
    </tbody>
</table>
</body>
</html>