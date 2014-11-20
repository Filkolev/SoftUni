function calculate() {
    var expression = document.getElementById('expression').value;
	var regex = /[^0-9\-*/()+%]+/g;
	expression = expression.replace(regex, '');
	
    document.getElementById('toEval').textContent = expression + "=";
    document.getElementById('result').textContent = eval(expression);
}
