<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>CV Generator</title>
    <link href="style.css" rel="stylesheet">
</head>
<body>

<?php
$name_matcher = "/^[a-zA-Z]{2,20}$/";
$company_matcher = "/^[a-zA-Z0-9]{2,20}$/";
$email_matcher = "/^[a-zA-Z0-9]+@[a-zA-Z0-9]+\\.[a-zA-Z0-9]+$/";
$phone_matcher = "/^[0-9+\\-\\s]+$/";

    if (isset($_POST['submit'])) {
        $firstName = $_POST['first-name'];
        $lastName = $_POST['last-name'];
        $email = $_POST['email'];
        $phone = $_POST['phone'];
        $gender = $_POST['gender'];
        $birthDate = $_POST['birth-date']; // change format
        $nationality = $_POST['nationality'];
        $companyName = $_POST['company-name'];
        $workFrom = $_POST['work-from'];
        $workTo = $_POST['work-to'];
        $programmingLangs = $_POST['prog-lang'];
        $programmingLangsLevel = $_POST['prog-lang-level'];
        $languages = $_POST['langs'];
        $langComprehension = $_POST['langs-comprehension'];
        $langReading = $_POST['langs-reading'];
        $langWriting = $_POST['langs-writing'];
        $driverLicense = $_POST['driver-license'];

        if (preg_match($name_matcher, $firstName) != 1 || preg_match($name_matcher, $lastName) != 1){
            die("First and last name should contain only letters, between 2 and 20");
        }
        if (preg_match($company_matcher, $companyName) != 1) {
            die("Company name should contain letters and numbers only, between 2 and 20");
        }
        if (preg_match($email_matcher, $email) != 1) {
            die("Email should contain letters and numbers, only one dot and only one @.");
        }
        if (preg_match($phone_matcher, $phone) != 1) {
            die("Phone number should contain digits, -, + and space.");
        }
    }
?>

<h1>CV</h1>
<table>
    <thead>
    <tr>
        <th colspan="2">Personal Information</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>First Name</td>
        <td><?php echo $firstName ?></td>
    </tr>
    <tr>
        <td>Last Name</td>
        <td><?php echo $lastName ?></td>
    </tr>
    <tr>
        <td>Email</td>
        <td><?php echo $email ?></td>
    </tr>
    <tr>
        <td>Phone Number</td>
        <td><?php echo $phone ?></td>
    </tr>
    <tr>
        <td>Gender</td>
        <td><?php echo $gender ?></td>
    </tr>
    <tr>
        <td>Birth Date</td>
        <td><?php echo $birthDate ?></td>
    </tr>
    <tr>
        <td>Nationality</td>
        <td><?php echo $nationality ?></td>
    </tr>
    </tbody>
</table>

<table>
    <thead>
    <tr>
        <th colspan="2">Last Work Position</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Company Name</td>
        <td><?php echo $companyName ?></td>
    </tr>
    <tr>
        <td>From</td>
        <td><?php echo $workFrom ?></td>
    </tr>
    <tr>
        <td>To</td>
        <td><?php echo $workTo ?></td>
    </tr>
    </tbody>
</table>

<table>
    <thead>
    <tr>
        <th colspan="2">Computer Skills</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Programming Languages</td>
        <td>
            <table>
                <thead>
                <tr>
                    <th>Language</th>
                    <th>Skill Level</th>
                </tr>
                </thead>
                <tbody>
                <?php
                for ($i = 0; $i < count($programmingLangs); $i++): ?>
                <tr><td> <?php echo $programmingLangs[$i] ?></td><td><?php echo $programmingLangsLevel[$i] ?></td></tr>
                <?php endfor ?>
                </tbody>
            </table>
        </td>
    </tr>
    </tbody>
</table>

<table>
    <thead>
    <tr>
        <th colspan="2">Other Skills</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Languages</td>
        <td>
            <table>
                <thead>
                <tr>
                    <th>Language</th>
                    <th>Comprehension</th>
                    <th>Reading</th>
                    <th>Writing</th>
                </tr>
                </thead>
                <tbody>
                <?php
                for ($i = 0; $i < count($languages); $i++): ?>
                <tr><td><?php echo $languages[$i] ?></td><td><?php echo $langComprehension[$i] ?></td><td><?php echo $langReading[$i] ?></td><td><?php echo $langWriting[$i] ?></td></tr>
                <?php endfor ?>
                </tbody>
            </table>
        </td>
    </tr>
    <tr>
        <td>Driver's license</td>
        <td>
            <?php echo implode(", ", $driverLicense) ?>
        </td>
    </tr>
    </tbody>
</table>

</body>
</html>
 