<?php
date_default_timezone_set("Europe/Sofia");
$newYear = new DateTime('01/01/2015');
$now = new DateTime();
$difference = $newYear->diff($now);

$hoursLeft = $difference->days * 24 + $difference->h;
$minutesLeft = $hoursLeft * 60 + $difference->i;
$secondsLeft = $minutesLeft * 60 + $difference->s;
$formatted = $difference->format("%a:%H:%I:%S");

echo "Hours until new year : $hoursLeft <br>";
echo "Minutes until new year : $minutesLeft <br>";
echo "Seconds until new year : $secondsLeft <br>";
echo "Days:Hours:Minutes:Seconds $formatted";