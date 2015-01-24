// Broke down the algorithm to make the steps of the calculation easier to read and understand

function treeHouseCompare(a, b) {
    var houseBase = a * a;
    var houseRoof = a * a / 3;
    var houseArea = houseBase + houseRoof;

    var trunk = b * b / 3;
    var crownRadius = 2 / 3 * b;
    var crownArea = crownRadius * crownRadius * Math.PI;
    var treeArea = trunk + crownArea;

    console.log((houseArea > treeArea ? 'house': 'tree') + '/' + Math.max(treeArea, houseArea).toFixed(2));
}

treeHouseCompare(3, 2);
treeHouseCompare(3, 3);
treeHouseCompare(4, 5);