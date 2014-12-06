<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8" />
        <title>Information Table</title>
        <style>
            th {
                background-color: orange;
                text-align: left;
                padding: 5px;
            }
            td {
                text-align: right;
                padding: 5px;
            }
            table, tr, th, td {
                border: 1px solid black;
                border-collapse: collapse;
            }
        </style>
    </head>

    <body>
    <?php
    function buildTable($name, $phone, $age, $address) {
        echo "\t<table>";
        echo "\n\t\t\t\t<tr>\n\t\t\t\t\t<th>Name</th>\n\t\t\t\t\t<td>$name</td>\n\t\t\t\t</tr>";
        echo "\n\t\t\t\t<tr>\n\t\t\t\t\t<th>Phone number</th>\n\t\t\t\t\t<td>$phone</td>\n\t\t\t\t</tr>";
        echo "\n\t\t\t\t<tr>\n\t\t\t\t\t<th>Age</th>\n\t\t\t\t\t<td>$age</td>\n\t\t\t\t</tr>";
        echo "\n\t\t\t\t<tr>\n\t\t\t\t\t<th>Address</th>\n\t\t\t\t\t<td>$address</td>\n\t\t\t\t</tr>";
        echo "\n\t\t\t</table><br/>";
    }

    buildTable("Gosho", "0882-321-423", 24, "Hadji Dimitar");
    buildTable("Pesho", "0884-888-888", 67, "Suhata Reka");
    ?>

    </body>
</html>


 