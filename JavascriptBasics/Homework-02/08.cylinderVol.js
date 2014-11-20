function calcCylinderVol(radius, height) {
    var volume = (Math.PI * radius * radius * height).toFixed(3);
    console.log(volume);
};

calcCylinderVol(2, 4);
calcCylinderVol(5, 8);
calcCylinderVol(12, 3);