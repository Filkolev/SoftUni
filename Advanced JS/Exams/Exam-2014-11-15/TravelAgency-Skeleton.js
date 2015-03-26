function processTravelAgencyCommands(commands) {
    'use strict';

    var Models = (function () {
        var Destination = (function () {
            function Destination(location, landmark) {
                this.setLocation(location);
                this.setLandmark(landmark);
            }

            Destination.prototype.getLocation = function () {
                return this._location;
            }

            Destination.prototype.setLocation = function (location) {
                if (location === undefined || location === "") {
                    throw new Error("Location cannot be empty or undefined.");
                }
                this._location = location;
            }

            Destination.prototype.getLandmark = function () {
                return this._landmark;
            }

            Destination.prototype.setLandmark = function (landmark) {
                if (landmark === undefined || landmark == "") {
                    throw new Error("Landmark cannot be empty or undefined.");
                }
                this._landmark = landmark;
            }

            Destination.prototype.toString = function () {
                return this.constructor.name + ": " +
                    "location=" + this.getLocation() +
                    ",landmark=" + this.getLandmark();
            }

            return Destination;
        }());

        var Travel = (function () {
            function Travel(name, startDate, endDate, price) {
                this.setName(name);
                this.setStartDate(startDate);
                this.setEndDate(endDate);
                this.setPrice(price);
            }

            Travel.prototype.getName = function () {
                return this._name;
            }

            Travel.prototype.setName = function (name) {
                if (!name) {
                    throw new Error('The travel name cannot be empty');
                }

                this._name = name;
            }

            Travel.prototype.getStartDate = function () {
                return this._startDate;
            }

            Travel.prototype.setStartDate = function (startDate) {
                new Date(startDate).toISOString()
                this._startDate = startDate;
            }

            Travel.prototype.getEndDate = function () {
                return this._endDate;
            }

            Travel.prototype.setEndDate = function (endDate) {
                new Date(endDate).toISOString();
                this._endDate = endDate;
            }

            Travel.prototype.getPrice = function () {
                return this._price;
            }

            Travel.prototype.setPrice = function (price) {
                if (isNaN(price) || price < 0) {
                    throw new Error('Price should be a non-negative number.');
                }

                this._price = price;
            }

            Travel.prototype.toString = function () {
                var result = ' * ' + this.constructor.name
                    + ': name=' + this.getName()
                    + ',start-date=' + formatDate(this.getStartDate())
                    + ',end-date=' + formatDate(this.getEndDate())
                    + ',price=' + this.getPrice().toFixed(2) + ',';

                return result;
            }

            function formatDate(date) {
                var monthNames = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
                    day = date.getDate(),
                    month = date.getMonth(),
                    year = date.getFullYear();

                return day + "-" + monthNames[month] + "-" + year;
            }

            return Travel;
        })();

        var Excursion = (function () {
            function Excursion(name, startDate, endDate, price, transport) {
                Travel.call(this, name, startDate, endDate, price);
                this.setTransport(transport);
                this._destinations = [];
            }

            Excursion.prototype = Object.create(Travel.prototype);
            Excursion.prototype.constructor = Excursion;

            Excursion.prototype.getTransport = function () {
                return this._transport;
            }

            Excursion.prototype.setTransport = function (transport) {
                if (!transport) {
                    throw new Error('Transport should be a non-empty string.');
                }

                this._transport = transport;
            }

            Excursion.prototype.getDestinations = function () {
                return this._destinations;
            }

            Excursion.prototype.addDestination = function (destination) {
                this._destinations.push(destination);
            }

            Excursion.prototype.removeDestination = function (destination) {
                var indexOfDestination = this._destinations.indexOf(destination);

                if (indexOfDestination == -1) {
                    throw new Error('The specified destination does not exist.');
                }

                this._destinations.splice(indexOfDestination, 1);
            }

            Excursion.prototype.toString = function () {
                var result = Travel.prototype.toString.call(this)
                    + 'transport=' + this.getTransport()
                    + '\n ** Destinations: ';

                if (this._destinations.length === 0) {
                    result += '-';
                } else {
                    result += this._destinations.join(';');
                }

                return result;
            }

            return Excursion;

        })();

        var Vacation = (function () {
            function Vacation(name, startDate, endDate, price, location, accomodation) {
                Travel.call(this, name, startDate, endDate, price);
                this.setLocation(location);
                this.setAccomodation(accomodation);
            }

            Vacation.prototype = Object.create(Travel.prototype);
            Vacation.prototype.constructor = Vacation;

            Vacation.prototype.getLocation = function () {
                return this._location;
            }

            Vacation.prototype.setLocation = function (location) {
                if (!location) {
                    throw new Error('The location cannot be empty.');
                }

                this._location = location;
            }

            Vacation.prototype.getAccomodation = function () {
                return this._accomodation;
            }

            Vacation.prototype.setAccomodation = function (accomodation) {
                if (accomodation !== undefined && accomodation === '') {
                    throw new Error('Accommodation should be a non-empty string if entered.');
                }

                this._accomodation = accomodation;
            }

            Vacation.prototype.toString = function () {
                var result = Travel.prototype.toString.call(this)
                    + 'location=' + this.getLocation();

                if (this.getAccomodation()) {
                    result += ',accommodation=' + this.getAccomodation();
                }

                return result;
            }

            return Vacation;
        })();

        var Cruise = (function () {
            var CRUISE_TRANSPORT = 'cruise liner';

            function Cruise(name, startDate, endDate, price, startDock) {
                Excursion.call(this, name, startDate, endDate, price, CRUISE_TRANSPORT);
            }

            Cruise.prototype = Object.create(Excursion.prototype);
            Cruise.prototype.constructor = Cruise;

            Cruise.prototype.getStartDock = function () {
                return this._startDock;
            }

            Cruise.prototype.setStartDock = function (startDock) {
                if (startDock !== undefined && startDock === '') {
                    throw new Error('Starting dock should be a non-empty string when entered.');
                }

                this._startDock = startDock;
            }

            return Cruise;
        })();

        return {
            Destination: Destination,
            Travel: Travel,
            Excursion: Excursion,
            Vacation: Vacation,
            Cruise: Cruise
        }
    }());

    var TravellingManager = (function () {
        var _travels;
        var _destinations;

        function init() {
            _travels = [];
            _destinations = [];
        }

        var CommandProcessor = (function () {

            function processInsertCommand(command) {
                var object;

                switch (command["type"]) {
                    case "excursion":
                        object = new Models.Excursion(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["transport"]);
                        _travels.push(object);
                        break;
                    case "vacation":
                        object = new Models.Vacation(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["location"], command["accommodation"]);
                        _travels.push(object);
                        break;
                    case "cruise":
                        object = new Models.Cruise(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["start-dock"]);
                        _travels.push(object);
                        break;
                    case "destination":
                        object = new Models.Destination(command["location"], command["landmark"]);
                        _destinations.push(object);
                        break;
                    default:
                        throw new Error("Invalid type.");
                }

                return object.constructor.name + " created.";
            }

            function processDeleteCommand(command) {
                var object,
                    index,
                    destinations;

                switch (command["type"]) {
                    case "destination":
                        object = getDestinationByLocationAndLandmark(command["location"], command["landmark"]);
                        _travels.forEach(function (t) {
                            if (t instanceof Models.Excursion && t.getDestinations().indexOf(object) !== -1) {
                                t.removeDestination(object);
                            }
                        });
                        index = _destinations.indexOf(object);
                        _destinations.splice(index, 1);
                        break;
                    case "excursion":
                    case "vacation":
                    case "cruise":
                        object = getTravelByName(command["name"]);
                        index = _travels.indexOf(object);
                        _travels.splice(index, 1);
                        break;
                    default:
                        throw new Error("Unknown type.");
                }

                return object.constructor.name + " deleted.";
            }

            function processListCommand(command) {
                return formatTravelsQuery(_travels);
            }

            function processAddDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.addDestination(destination);

                return "Added destination to " + travel.getName() + ".";
            }

            function processRemoveDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.removeDestination(destination);

                return "Removed destination from " + travel.getName() + ".";
            }


            function processFilterTravelsCommand(command) {
                var type = command['type'],
                    minPrice = parseFloat(command['price-min']),
                    maxPrice = parseFloat(command['price-max']),
                    filteredTravels;

                filteredTravels = getTravelsByType(type);
                filteredTravels = filterTravelsInPriceRange(filteredTravels, minPrice, maxPrice);

                filteredTravels = sortTravelsByStartDateAndName(filteredTravels);

                return formatTravelsQuery(filteredTravels);
            }

            function getTravelByName(name) {
                var i;

                for (i = 0; i < _travels.length; i++) {
                    if (_travels[i].getName() === name) {
                        return _travels[i];
                    }
                }
                throw new Error("No travel with such name exists.");
            }

            function getDestinationByLocationAndLandmark(location, landmark) {
                var i;

                for (i = 0; i < _destinations.length; i++) {
                    if (_destinations[i].getLocation() === location
                        && _destinations[i].getLandmark() === landmark) {
                        return _destinations[i];
                    }
                }
                throw new Error("No destination with such location and landmark exists.");
            }

            function formatTravelsQuery(travelsQuery) {
                var queryString = "";

                if (travelsQuery.length > 0) {
                    queryString += travelsQuery.join('\n');
                } else {
                    queryString = "No results.";
                }

                return queryString;
            }

            function getTravelsByType(type) {
                var filteredTravels;

                if (type === 'all') {
                    filteredTravels = _travels;
                } else {
                    filteredTravels = _travels.filter(function (travel) {
                        return type.toLocaleLowerCase() === travel.constructor.name.toLocaleLowerCase();
                    });
                }

                return filteredTravels;
            }

            function filterTravelsInPriceRange(travels, minPrice, maxPrice) {
                var filteredTravels = travels.filter(function (travel) {
                    return minPrice <= travel.getPrice() && travel.getPrice() <= maxPrice;
                });

                return filteredTravels;
            }

            function sortTravelsByStartDateAndName(travels) {
                travels.sort(function (t1, t2) {
                    if (t1.getStartDate().getTime() === t2.getStartDate().getTime()) {
                        return t1.getName().localeCompare(t2.getName());
                    }

                    return t1.getStartDate() < t2.getStartDate() ? -1 : 1;
                });

                return travels;
            }

            return {
                processInsertCommand: processInsertCommand,
                processDeleteCommand: processDeleteCommand,
                processListCommand: processListCommand,
                processAddDestinationCommand: processAddDestinationCommand,
                processRemoveDestinationCommand: processRemoveDestinationCommand,
                processFilterTravelsCommand: processFilterTravelsCommand
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
                case "add-destination":
                    output = CommandProcessor.processAddDestinationCommand(commandArgs);
                    break;
                case "remove-destination":
                    output = CommandProcessor.processRemoveDestinationCommand(commandArgs);
                    break;
                case "list":
                    output = CommandProcessor.processListCommand(commandArgs);
                    break;
                case "filter":
                    output = CommandProcessor.processFilterTravelsCommand(commandArgs);
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

    var parseDate = function (dateStr) {
        if (!dateStr) {
            return undefined;
        }
        var date = new Date(Date.parse(dateStr.replace(/-/g, ' ')));
        var dateFormatted = formatDate(date);
        if (dateStr != dateFormatted) {
            throw new Error("Invalid date: " + dateStr);
        }
        return date;
    }

    var formatDate = function (date) {
        var day = date.getDate();
        var monthName = date.toString().split(' ')[1];
        var year = date.getFullYear();
        return day + '-' + monthName + '-' + year;
    }

    var output = "";
    TravellingManager.init();

    commands.forEach(function (cmd) {
        var result;
        if (cmd != "") {
            try {
                result = TravellingManager.executeCommands(cmd) + "\n";
            } catch (e) {
                result = "Invalid command." + "\n";
            }
            output += result;
        }
    });

    return output;
}