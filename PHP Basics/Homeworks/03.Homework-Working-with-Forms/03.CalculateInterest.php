<!DOCTYPE html>

<html>
    <head>
        <meta charset="utf-8" />
        <title>Calculate Interest</title>
        <style>
            label[for="amount"], label[for="BGN"], label[for="interest"] {
                display: block;
            }
            form * {
                margin: 10px 2px;
            }

            form {
                width: 500px;
                margin: 0 auto;
            }
        </style>
    </head>

    <body>
    <form action="03.CalculateInterest.php" method="post">
        <label for="amount" title="Digits and dot only!">Enter Amount <input type="text" name="amount" id="amount" pattern="[0-9]+\.?[0-9]+" required="required"></label>
        <input type="radio" name="currency" id="usd" value="usd" required="required">
        <label for="usd">USD
        <input type="radio" name="currency" id="eur" value="eur">
        <label for="eur">EUR</label>
        <input type="radio" name="currency" id="bgn" value="bgn">
        <label for="bgn">BGN</label>
        <label for="interest" title="Digits and dot only!">Compound Interest Amount <input type="text" name="interest" id="interest" pattern="[0-9]+\.?[0-9]+" required="required" /></label>
        <select name="period" required="required">
            <option value="6">6 Months</option>
            <option value="12">1 Year</option>
            <option value="24">2 Years</option>
            <option value="60">5 Years</option>
        </select>

        <input type="submit" name="submit" value="Calculate">
    </form>
    <p>
    <?php
    $amount = floatval($_POST['amount']);
    $currency = $_POST['currency'];
    $interest = floatval($_POST['interest']) / 12;
    $period = $_POST['period'];
    $result = $amount * pow(1 + $interest / 100, $period);

    if ($currency == "USD") {
        echo '$ ' . number_format($result, 2);
    } else if ($currency == "EUR") {
        $unicodeChar = '\u20AC ';
        echo json_decode('"'.$unicodeChar.'"') . " " . number_format($result, 2);
    } else {
        echo number_format($result, 2) . " лв.";
    }

    ?>
    </p>
    </body>
</html>


 