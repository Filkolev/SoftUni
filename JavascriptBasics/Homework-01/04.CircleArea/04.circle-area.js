function calcCircleArea(r) {
    var area = Math.PI * (r * r);
    return area;
}


document.getElementById("first").innerHTML = calcCircleArea(7);
document.getElementById("second").innerHTML = calcCircleArea(1.5);
document.getElementById("third").innerHTML = calcCircleArea(20);