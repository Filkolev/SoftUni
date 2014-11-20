var hours = new Date().getHours();
var minutes = new Date().getMinutes() < 10 ? '0' : '' + new Date().getMinutes();

console.log(hours + ":" + minutes);