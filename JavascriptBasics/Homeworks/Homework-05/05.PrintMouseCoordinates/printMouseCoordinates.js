document.onmousemove = handleMouseMove;


function handleMouseMove(event) {
    var textarea = document.getElementById('pos-info');

    var posX = event.pageX;
    var posY = event.pageY;
    var time = new Date();

    textarea.innerHTML += 'X: ' + posX + '; Y: ' + posY + ' Time: ' + time + '\n';
}