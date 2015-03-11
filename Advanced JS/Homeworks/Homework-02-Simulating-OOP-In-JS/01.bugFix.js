function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;

    return {
        firstName: this.firstName,
        lastName: this.lastName,
        name: this.firstName + " " + this.lastName
    };
}

console.log("Problem 1. Bug Fix");
var peter = new Person("Peter", "Jackson");
console.log(peter.name);
console.log(peter.firstName);
console.log(peter.lastName);
console.log("\n\n");