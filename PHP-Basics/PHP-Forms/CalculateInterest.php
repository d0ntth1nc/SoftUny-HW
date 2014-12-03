<?php
if (isset($_POST['amount'], $_POST['currency'], $_POST['compound'])) {
    $amount = floatval($_POST['amount']) or die("Invalid Amount!");
    $currency = $_POST['currency'];
    $cmpAnnualInterest = floatval($_POST['compound'])
        or die("Invalid Compound Interest Amount!");
    $period = intval($_POST['period']) or die("Invalid period!");

    $result = $amount;
    $interestPerMonthPercentage = $cmpAnnualInterest / 12 / 100;
    for ($i = 0; $i < $period; $i++) {
        $result += $result * $interestPerMonthPercentage;
    }

    $result = round($result, 2);
    $currencySymbol = '';
    switch ($currency) {
        case 'USD' : $currencySymbol = '$'; break;
        case 'EUR' : $currencySymbol = '&euro;'; break;
        case 'BGN' : $currencySymbol = 'Lv'; break;
        default: $currencySymbol = '';
    }
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>02.Most Frequent Tag</title>
</head>
<body>
<main>
    <?php if(isset($result)) :?>
        <p><?= $currencySymbol . ' ' . $result ?></p>
    <?php endif; ?>
    <form method="post" action="#">
        Enter Amount: <input type="text" name="amount"><br>
        <input type="radio" name="currency" value="USD" id="usd">
        <label for="usd">USD</label>
        <input type="radio" name="currency" value="EUR" id="eur">
        <label for="eur">EUR</label>
        <input type="radio" name="currency" value="BGN" id="bgn">
        <label for="bgn">BGN</label><br>
        Compound Interest Amount <input type="text" name="compound"><br>
        <select name="period">
            <option value="6">6 Months</option>
            <option value="12">1 Year</option>
            <option value="24">2 Years</option>
            <option value="60">5 Years</option>
        </select>
        <input type="submit" value="Calculate">
    </form>
</main>
</body>
</html>