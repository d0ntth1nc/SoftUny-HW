<?php
header("Content-type: text/json");

$southAmerica = ['Brazil', 'Colombia', 'Argentina', 'Peru', 'Venezuela',
'Chile', 'Ecuador', 'Bolivia', 'Paraguay', 'Uruguay', 'Guyana', 'Suriname'];

$northAmerica = ['United States', 'Mexico', 'Canada', 'Guatemala', 'Cuba',
'Haiti', 'Dominican Republic', 'Honduras', 'Nicaragua', 'Costa Rica'];

$asia = ['Afghanistan', 'Armenia', 'Bhutan', 'Brunei', 'China', 'Iran', 'Russia', 'Iraq'];

$europe = ['Bulgaria', 'Germany', 'France', 'Spain', 'Serbia', 'Greece', 'Turkey'];

$australia = ['Australia'];

$africa = ['Algiers', 'Luanda', 'Porto Novo', 'Gaborone', 'Bujumbura', 'Moroni'];

if (isset($_GET['continent'])) {
    $continent = $_GET['continent'];
    switch($continent) {
        case 'Africa': echo json_encode($africa); break;
        case 'Europe': echo json_encode($europe); break;
        case 'Australia': echo json_encode($australia); break;
        case 'North America': echo json_encode($northAmerica); break;
        case 'South America': echo json_encode($southAmerica); break;
        case 'Asia': echo json_encode($asia); break;
    }
}