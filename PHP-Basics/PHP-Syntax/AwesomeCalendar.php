<?php
date_default_timezone_set("Europe/Sofia");
$currentYear = getdate()['year'];
$months = array("Януари", "Февруари", "Март", "Април",
"Май", "Юни", "Юли", "Август", "Септември", "Октомври", "Ноември", "Декември");

function getDayOfWeek($monthIndex, $year) {
    return date("N", strtotime("01-$monthIndex-$year"));
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Awesome Calendar</title>
    <style type="text/css">
        * { margin: 0; padding: 0; }
        h1 { text-align: center; }
        td { vertical-align: top; padding: 10px; }
        .inner-table td { padding: 2px; }
        .last-day { color: red; }
        .outer-table { width: 700px; margin: auto; }
    </style>
</head>
<body>
    <h1><?= $currentYear ?></h1>
<table class="outer-table">
    <tbody>
    <?php for ($row = 0, $monthIndex = 0; $row < 3; $row++) { ?>
        <tr>
            <?php for ($col = 0; $col < 4; $col++, $monthIndex++) { ?>
                <td>
                    <table class="inner-table">
                        <thead>
                        <tr>
                            <th colspan="7"><?= $months[$monthIndex] ?></th>
                        </tr>
                        <tr>
                            <th>По</th>
                            <th>Вт</th>
                            <th>Ср</th>
                            <th>Чт</th>
                            <th>Пе</th>
                            <th>Сб</th>
                            <th class="last-day">Не</th>
                        </tr>
                        </thead>
                        <tbody>
                        <?php
                        $monthDays = cal_days_in_month(CAL_GREGORIAN, $monthIndex + 1, $currentYear);
                        $dayOfWeek = getDayOfWeek($monthIndex + 1, $currentYear);

                        $daysCounter = 0;
                        for ($innerRow = 0; $innerRow < 6; $innerRow++) {
                        ?>
                            <tr>
                                <?php for ($innerCol = 0; $innerCol < 7; $innerCol++, $daysCounter++) { ?>
                                    <td>
                                        <?php
                                        $currentDay = $daysCounter - $dayOfWeek + 2;
                                        if ($currentDay >= 1 && $currentDay <= $monthDays) {
                                            echo $currentDay;
                                        }
                                        ?>
                                    </td>
                                <?php } ?>
                            </tr>
                        <?php } ?>
                        </tbody>
                    </table>
                </td>
            <?php }?>
        </tr>
    <?php }?>
    </tbody>
</table>
</body>
</html>