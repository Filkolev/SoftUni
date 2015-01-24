<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>Get Form Data</title>
        <style>
            input[type="text"], input[type="submit"] {
                display: block;
                margin: 5px;
            }

            form, p {
                margin: 20px auto;
                width: 500px;
            }
        </style>
    </head>

    <body>
        <form action="07.GetFormData.php" method="post" name="user-data">
            <input type="text" name="name" id="name" placeholder="Name.." pattern="[A-Za-z\- ]+" required="required"/>
            <input type="text" name="age" id="age" placeholder="Age.." required="required" pattern="[0-9]+"/>
            <input type="radio" name="gender" value="m" id="male" checked/>
            <label for="male">Male</label>
            <input type="radio" name="gender" value="f" id="female"/>
            <label for="female">Female</label>
            <input type="submit" name="submitBtn" value="Submit" />
        </form>

        <?php

        if(isset($_POST['submitBtn']))
        {
            $name = $_POST["name"];
            $age = $_POST["age"];
            $gender = $_POST["gender"] == 'm' ? "male" : "female";

            if ($name != '' && $gender != '' && $age != '') {
                echo "<p>My name is $name. I am $age years old. I am $gender.</p>";
            }
        }

        ?>
    </body>
</html>