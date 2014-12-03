<?php
$continents = ['Europe', 'Asia', 'South America', 'North America', 'Australia', 'Africa'];
$southAmerica = ['Brazil', 'Colombia', 'Argentina', 'Peru', 'Venezuela',
    'Chile', 'Ecuador', 'Bolivia', 'Paraguay', 'Uruguay', 'Guyana', 'Suriname'];
$northAmerica = ['United States', 'Mexico', 'Canada', 'Guatemala', 'Cuba',
    'Haiti', 'Dominican Republic', 'Honduras', 'Nicaragua', 'Costa Rica'];
$asia = ['Afghanistan', 'Armenia', 'Bhutan', 'Brunei', 'China', 'Iran', 'Russia', 'Iraq'];
$europe = ['Bulgaria', 'Germany', 'France', 'Spain', 'Serbia', 'Greece', 'Turkey'];
$australia = ['Australia'];
$africa = ['Algiers', 'Luanda', 'Porto Novo', 'Gaborone', 'Bujumbura', 'Moroni'];

$currentContinent = "Europe"; //Default
if (isset($_GET['continent'])) {
    $currentContinent = $_GET['continent'];
}
switch($currentContinent) {
    case 'Africa': $countries = $africa; break;
    case 'Europe': $countries = $europe; break;
    case 'Australia': $countries = $australia; break;
    case 'North America': $countries = $northAmerica; break;
    case 'South America': $countries = $southAmerica; break;
    case 'Asia': $countries = $asia; break;
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Combo Box</title>
</head>
<body>
<main>
    <form action="#" method="get">
        <select name="continent" id="continents-holder">
            <?php foreach($continents as $continent) :?>
                <option <?php
                if ($continent == $currentContinent) {
                    echo "selected";
                }
                ?>><?=$continent?></option>
            <?php endforeach; ?>
        </select>
        <select>
            <?php foreach($countries as $country) :?>
            <option><?=$country?></option>
            <?php endforeach; ?>
        </select>
    </form>
</main>
<script>
    //Force form submit
    document.getElementById("continents-holder")
        .addEventListener("change", function(e) {
            e.target.parentNode.submit();
    });
</script>
</body>
</html>