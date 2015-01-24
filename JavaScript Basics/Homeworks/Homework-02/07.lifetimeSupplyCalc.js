function calcSupply(age, maxAge, favoriteFood, dailyConsumption) {
    var years = maxAge - age;
    var amount = 365 * years * dailyConsumption;

    console.log(amount + 'kg of ' + favoriteFood + ' would be enough until I am ' + maxAge + ' years old.');
};

calcSupply(38, 118, 'chocolate', 0.5);
calcSupply(20, 87, 'fruits', 2);
calcSupply(16, 102, 'nuts', 1.1);