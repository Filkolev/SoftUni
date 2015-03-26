function processVehicleParkCommands(commands) {
    'use strict';

    var Models = (function () {
        var Employee = (function () {
            function Employee(name, position, grade) {
                this.setName(name);
                this.setPosition(position);
                this.setGrade(grade);
            }

            Employee.prototype.getName = function () {
                return this._name;
            }

            Employee.prototype.setName = function (name) {
                if (name === undefined || name === "") {
                    throw new Error("Name cannot be empty or undefined.");
                }
                this._name = name;
            }

            Employee.prototype.getPosition = function () {
                return this._position;
            }

            Employee.prototype.setPosition = function (position) {
                if (position === undefined || position === "") {
                    throw new Error("Position cannot be empty or undefined.");
                }
                this._position = position;
            }

            Employee.prototype.getGrade = function () {
                return this._grade;
            }

            Employee.prototype.setGrade = function (grade) {
                if (grade === undefined || isNaN(grade) || grade < 0) {
                    throw new Error("Grade cannot be negative.");
                }
                this._grade = grade;
            }

            Employee.prototype.toString = function () {
                return " ---> " + this.getName() +
                    ",position=" + this.getPosition();
            }

            return Employee;
        }());

        var Vehicle = (function () {
            function Vehicle(brand, age, terrainCoverage, numberOfWheels) {
                if (this === Vehicle) {
                    throw new Error('Cannot create instance of an abstract class (Vehicle).');
                }

                this.setBrand(brand);
                this.setAge(age);
                this.setTerrainCoverage(terrainCoverage);
                this.setNumberOfWheels(numberOfWheels);
            }

            Vehicle.prototype.getBrand = function () {
                return this._brand;
            }

            Vehicle.prototype.setBrand = function (brand) {
                if (!brand) {
                    throw new Error('Vehicle brand should be a non-empty string.');
                }

                this._brand = brand;
            }

            Vehicle.prototype.getAge = function () {
                return this._age.toFixed(1);
            }

            Vehicle.prototype.setAge = function (age) {
                if (!age || age < 0) {
                    throw new Error('Vehicle age should be a positive number.');
                }

                this._age = age;
            }

            Vehicle.prototype.getTerrainCoverage = function () {
                return this._terrainCoverage;
            }

            Vehicle.prototype.setTerrainCoverage = function (terrainCoverage) {
                if (terrainCoverage !== 'all' && terrainCoverage !== 'road') {
                    throw new Error('Vehicle\'s terrain coverage can be either "road" or "all".');
                }

                this._terrainCoverage = terrainCoverage;
            }

            Vehicle.prototype.getNumberOfWheels = function () {
                return this._numberOfWheels;
            }

            Vehicle.prototype.setNumberOfWheels = function (numberOfWheels) {
                if (!numberOfWheels || numberOfWheels < 0) {
                    throw new Error('Vehicle should have a positive number of wheels.');
                }

                this._numberOfWheels = numberOfWheels;
            }

            Vehicle.prototype.toString = function () {
                var result = ' -> ' + this.constructor.name
                    + ': brand=' + this.getBrand()
                    + ',age=' + this.getAge()
                    + ',terrainCoverage=' + this.getTerrainCoverage()
                    + ',numberOfWheels=' + this.getNumberOfWheels() + ',';

                return result;
            }

            return Vehicle;

        })();

        var Bike = (function () {
            var BIKE_NUMBER_OF_WHEELS = 2;

            function Bike(brand, age, terrainCoverage, frameSize, numberOfShifts) {
                Vehicle.call(this, brand, age, terrainCoverage, BIKE_NUMBER_OF_WHEELS);
                this.setFrameSize(frameSize);
                this.setNumberOfShifts(numberOfShifts);
            }

            Bike.prototype = Object.create(Vehicle.prototype);
            Bike.prototype.constructor = Bike;

            Bike.prototype.getFrameSize = function () {
                return this._frameSize;
            }

            Bike.prototype.setFrameSize = function (frameSize) {
                if (!frameSize || frameSize < 0) {
                    throw new Error('Bike\'s frame size should be a positive number.');
                }

                this._frameSize = frameSize;
            }

            Bike.prototype.getNumberOfShifts = function () {
                return this._numberOfShifts;
            }

            Bike.prototype.setNumberOfShifts = function (numberOfShifts) {
                if (numberOfShifts !== undefined && numberOfShifts === '') {
                    throw new Error('Bike\'s number of shifts should be a non-empty string when entered.');
                }

                this._numberOfShifts = numberOfShifts;
            }

            Bike.prototype.toString = function () {
                var result = Vehicle.prototype.toString.call(this)
                    + 'frameSize=' + this.getFrameSize();

                if (this.getNumberOfShifts()) {
                    result += ',numberOfShifts=' + this.getNumberOfShifts();
                }

                return result;
            }

            return Bike;
        })();

        var Automobile = (function () {
            function Automobile(brand, age, terrainCoverage, numberOfWheels, consumption, typeOfFuel) {
                if (this === Automobile) {
                    throw new Error('Cannot create instance of an abstract class (Automobile).')
                }

                Vehicle.call(this, brand, age, terrainCoverage, numberOfWheels);
                this.setConsumption(consumption);
                this.setTypeOfFuel(typeOfFuel);
            }

            Automobile.prototype = Object.create(Vehicle.prototype);
            Automobile.prototype.constructor = Automobile;

            Automobile.prototype.getConsumption = function () {
                return this._consumption;
            }

            Automobile.prototype.setConsumption = function (consumption) {
                if (!consumption || consumption < 0) {
                    throw new Error('Automobile\'s consumption should be a positive number.');
                }

                this._consumption = consumption;
            }

            Automobile.prototype.getTypeOfFuel = function () {
                return this._typeOfFuel;
            }

            Automobile.prototype.setTypeOfFuel = function (typeOfFuel) {
                if (!typeOfFuel) {
                    throw new Error('Automobile\'s type of fuel cannot be empty.');
                }

                this._typeOfFuel = typeOfFuel;
            }

            Automobile.prototype.toString = function () {
                var result = Vehicle.prototype.toString.call(this)
                    + 'consumption=[' + this._consumption + 'l/100km ' + this._typeOfFuel + ']';

                return result;
            }

            return Automobile;
        })();

        var Truck = (function () {
            var TRUCK_DEFAULT_TERRAIN_COVERAGE = 'all',
                TRUCK_NUMBER_OF_WHEELS = 4;

            function Truck(brand, age, terrainCoverage, consumption, typeOfFuel, numberOfDoors) {
                terrainCoverage = terrainCoverage || TRUCK_DEFAULT_TERRAIN_COVERAGE;
                Automobile.call(this, brand, age, terrainCoverage, TRUCK_NUMBER_OF_WHEELS, consumption, typeOfFuel);
                this.setNumberOfDoors(numberOfDoors);
            }

            Truck.prototype = Object.create(Automobile.prototype);
            Truck.prototype.constructor = Truck;

            Truck.prototype.getNumberOfDorrs = function () {
                return this._numberOfDoors;
            }

            Truck.prototype.setNumberOfDoors = function (numberOfDoors) {
                if (!numberOfDoors || numberOfDoors < 0) {
                    throw new Error('Truck\'s number of doors should be a positive number.');
                }

                this._numberOfDoors = numberOfDoors;
            }

            Truck.prototype.toString = function () {
                var result = Automobile.prototype.toString.call(this)
                    + ',numberOfDoors=' + this._numberOfDoors;

                return result;
            }

            return Truck;
        })();

        var Limo = (function () {
            var LIMO_TERRAIN_COVERAGE = 'road';

            function Limo(brand, age, numberOfWheels, consumption, typeOfFuel) {
                Automobile.call(this, brand, age, LIMO_TERRAIN_COVERAGE, numberOfWheels, consumption, typeOfFuel);
                this._employees = [];
            }

            Limo.prototype = Object.create(Automobile.prototype);
            Limo.prototype.constructor = Limo;

            Limo.prototype.appendEmployee = function (employee) {
                if (this._employees.indexOf(employee) === -1) {
                    this._employees.push(employee);
                }
            }

            Limo.prototype.detachEmployee = function (employee) {
                var indexOfEmployee = this._employees.indexOf(employee);

                if (indexOfEmployee === -1) {
                    throw new Error('No such employee.');
                }

                this._employees.splice(indexOfEmployee, 1);
            }

            Limo.prototype.toString = function () {
                var result = Automobile.prototype.toString.call(this)
                    + '\n --> Employees, allowed to drive:';

                for (var i in this._employees) {
                    result += '\n' + this._employees[i];
                }

                if (this._employees.length === 0) {
                    result += ' ---';
                }

                return result;
            }

            return Limo;
        })();

        return {
            Employee: Employee,
            Vehicle: Vehicle,
            Bike: Bike,
            Automobile: Automobile,
            Truck: Truck,
            Limo: Limo
        }
    }());

    var ParkManager = (function () {
        var _vehicles;
        var _employees;

        function init() {
            _vehicles = [];
            _employees = [];
        }

        var CommandProcessor = (function () {

            function processInsertCommand(command) {
                var object;

                switch (command["type"]) {
                    case "bike":
                        object = new Models.Bike(
                            command["brand"],
                            parseFloat(command["age"]),
                            command["terrain-coverage"],
                            parseFloat(command["frame-size"]),
                            command["number-of-shifts"]);
                        _vehicles.push(object);
                        break;
                    case "truck":
                        object = new Models.Truck(
                            command["brand"],
                            parseFloat(command["age"]),
                            command["terrain-coverage"],
                            parseFloat(command["consumption"]),
                            command["type-of-fuel"],
                            parseFloat(command["number-of-doors"]));
                        _vehicles.push(object);
                        break;
                    case "limo":
                        object = new Models.Limo(
                            command["brand"],
                            parseFloat(command["age"]),
                            parseFloat(command["number-of-wheels"]),
                            parseFloat(command["consumption"]),
                            command["type-of-fuel"]);
                        _vehicles.push(object);
                        break;
                    case "employee":
                        object = new Models.Employee(command["name"], command["position"], parseFloat(command["grade"]));
                        _employees.push(object);
                        break;
                    default:
                        throw new Error("Invalid type.");
                }

                return object.constructor.name + " created.";
            }

            function processDeleteCommand(command) {
                var object,
                    index;

                switch (command["type"]) {
                    case "employee":
                        object = getEmployeeByName(command["name"]);
                        _vehicles.forEach(function (t) {
                            if (t instanceof Models.Limo && t.getEmployees().indexOf(object) !== -1) {
                                t.detachEmployee(object);
                            }
                        });
                        index = _employees.indexOf(object);
                        _employees.splice(index, 1);
                        break;
                    case "bike":
                    case "truck":
                    case "limo":
                        object = getVehicleByBrandAndType(command["brand"], command["type"]);
                        index = _vehicles.indexOf(object);
                        _vehicles.splice(index, 1);
                        break;
                    default:
                        throw new Error("Unknown type.");
                }

                return object.constructor.name + " deleted.";
            }

            function processListCommand(command) {
                return formatOutputList(_vehicles);
            }

            function processAppendEmployeeCommand(command) {
                var employee = getEmployeeByName(command["name"]);
                var limos = getLimosByBrand(command["brand"]);

                for (var i = 0; i < limos.length; i++) {
                    limos[i].appendEmployee(employee);
                }
                return "Added employee to possible Limos.";
            }

            function processDetachEmployeeCommand(command) {
                var employee = getEmployeeByName(command["name"]);
                var limos = getLimosByBrand(command["brand"]);

                for (var i = 0; i < limos.length; i++) {
                    limos[i].detachEmployee(employee);
                }

                return "Removed employee from possible Limos.";
            }

            function processListEmployees(commandArgs) {
                var employees = getEmployeesByGrade(commandArgs['grade']);

                employees.sort(function (e1, e2) {
                    return e1._name.localeCompare(e2._name);
                });

                return formatOutputList(employees);
            }

            // Functions below are not revealed

            function getVehicleByBrandAndType(brand, type) {
                for (var i = 0; i < _vehicles.length; i++) {
                    if (_vehicles[i].constructor.name.toString().toLowerCase() === type &&
                        _vehicles[i].getBrand() === brand) {
                        return _vehicles[i];
                    }
                }
                throw new Error("No Limo with such brand exists.");
            }

            function getLimosByBrand(brand) {
                var currentVehicles = [];
                for (var i = 0; i < _vehicles.length; i++) {
                    if (_vehicles[i] instanceof Models.Limo &&
                        _vehicles[i].getBrand() === brand) {
                        currentVehicles.push(_vehicles[i]);
                    }
                }
                if (currentVehicles.length > 0) {
                    return currentVehicles;
                }
                throw new Error("No Limo with such brand exists.");
            }

            function getEmployeeByName(name) {

                for (var i = 0; i < _employees.length; i++) {
                    if (_employees[i].getName() === name) {
                        return _employees[i];
                    }
                }
                throw new Error("No Employee with such name exists.");
            }

            function formatOutputList(output) {
                var queryString = "List Output:\n";

                if (output.length > 0) {
                    queryString += output.join("\n");
                } else {
                    queryString = "No results.";
                }

                return queryString;
            }

            function getEmployeesByGrade(grade) {
                var employees;

                if (grade === 'all') {
                    employees = _employees;
                } else {
                    grade = parseFloat(grade);

                    employees = _employees.filter(function (employee) {
                        return employee.getGrade() >= grade;
                    });
                }

                return employees;
            }

            return {
                processInsertCommand: processInsertCommand,
                processDeleteCommand: processDeleteCommand,
                processListCommand: processListCommand,
                processAppendEmployeeCommand: processAppendEmployeeCommand,
                processDetachEmployeeCommand: processDetachEmployeeCommand,
                processListEmployees: processListEmployees
            }
        }());

        var Command = (function () {
            function Command(cmdLine) {
                this._cmdArgs = processCommand(cmdLine);
            }

            function processCommand(cmdLine) {
                var parameters = [],
                    matches = [],
                    pattern = /(.+?)=(.+?)[;)]/g,
                    key,
                    value,
                    split;

                split = cmdLine.split("(");
                parameters["command"] = split[0];
                while ((matches = pattern.exec(split[1])) !== null) {
                    key = matches[1];
                    value = matches[2];
                    parameters[key] = value;
                }

                return parameters;
            }

            return Command;
        }());

        function executeCommands(cmds) {
            var commandArgs = new Command(cmds)._cmdArgs,
                action = commandArgs["command"],
                output;

            switch (action) {
                case "insert":
                    output = CommandProcessor.processInsertCommand(commandArgs);
                    break;
                case "delete":
                    output = CommandProcessor.processDeleteCommand(commandArgs);
                    break;
                case "append-employee":
                    output = CommandProcessor.processAppendEmployeeCommand(commandArgs);
                    break;
                case "detach-employee":
                    output = CommandProcessor.processDetachEmployeeCommand(commandArgs);
                    break;
                case "list":
                    output = CommandProcessor.processListCommand(commandArgs);
                    break;
                case "list-employees":
                    output = CommandProcessor.processListEmployees(commandArgs);
                    break;
                default:
                    throw new Error("Unsupported command.");
            }

            return output;
        }

        return {
            init: init,
            executeCommands: executeCommands
        }
    }());

    var output = "";
    ParkManager.init();

    commands.forEach(function (cmd) {
        var result;
        if (cmd != "") {
            try {
                result = ParkManager.executeCommands(cmd) + "\n";
            } catch (e) {
                result = "Invalid command." + "\n";
                //result = e.message + "\n";
            }
            output += result;
        }
    });

    return output;
}