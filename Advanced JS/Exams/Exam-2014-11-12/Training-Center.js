function processTrainingCenterCommands(commands) {

    'use strict';

    var trainingcenter = (function () {

        var TrainingCenterEngine = (function () {

            var _trainers;
            var _uniqueTrainerUsernames;
            var _trainings;

            function initialize() {
                _trainers = [];
                _uniqueTrainerUsernames = {};
                _trainings = [];
            }

            function executeCommand(command) {
                var cmdParts = command.split(' ');
                var cmdName = cmdParts[0];
                var cmdArgs = cmdParts.splice(1);
                switch (cmdName) {
                    case 'create':
                        return executeCreateCommand(cmdArgs);
                    case 'list':
                        return executeListCommand();
                    case 'delete':
                        return executeDeleteCommand(cmdArgs);
                    default:
                        throw new Error('Unknown command: ' + cmdName);
                }
            }

            function executeCreateCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var createArgs = cmdArgs.splice(1).join(' ');
                var objectData = JSON.parse(createArgs);
                var trainer;
                switch (objectType) {
                    case 'Trainer':
                        trainer = new trainingcenter.Trainer(objectData.username, objectData.firstName,
                            objectData.lastName, objectData.email);
                        addTrainer(trainer);
                        break;
                    case 'Course':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var course = new trainingcenter.Course(objectData.name, objectData.description, trainer,
                            parseDate(objectData.startDate), objectData.duration);
                        addTraining(course);
                        break;
                    case 'Seminar':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var seminar = new trainingcenter.Seminar(objectData.name, objectData.description,
                            trainer, parseDate(objectData.date));
                        addTraining(seminar);
                        break;
                    case 'RemoteCourse':
                        trainer = findTrainerByUsername(objectData.trainer);
                        var remoteCourse = new trainingcenter.RemoteCourse(objectData.name, objectData.description,
                            trainer, parseDate(objectData.startDate), objectData.duration, objectData.location);
                        addTraining(remoteCourse);
                        break;
                    default:
                        throw new Error('Unknown object to create: ' + objectType);
                }
                return objectType + ' created.';
            }

            function findTrainerByUsername(username) {
                if (!username) {
                    return undefined;
                }
                for (var i = 0; i < _trainers.length; i++) {
                    if (_trainers[i].getUsername() == username) {
                        return _trainers[i];
                    }
                }
                throw new Error("Trainer not found: " + username);
            }

            function addTrainer(trainer) {
                if (_uniqueTrainerUsernames[trainer.getUsername()]) {
                    throw new Error('Duplicated trainer: ' + trainer.getUsername());
                }
                _uniqueTrainerUsernames[trainer.getUsername()] = true;
                _trainers.push(trainer);
            }

            function addTraining(training) {
                _trainings.push(training);
            }

            function executeListCommand() {
                var result = '', i;
                if (_trainers.length > 0) {
                    result += 'Trainers:\n' + ' * ' + _trainers.join('\n * ') + '\n';
                } else {
                    result += 'No trainers\n';
                }

                if (_trainings.length > 0) {
                    result += 'Trainings:\n' + ' * ' + _trainings.join('\n * ') + '\n';
                } else {
                    result += 'No trainings\n';
                }

                return result.trim();
            }

            function executeDeleteCommand(cmdArgs) {
                var objectType = cmdArgs[0];
                var deleteArgs = cmdArgs.splice(1).join(' ');
                switch (objectType) {
                    case 'Trainer':
                        deleteTrainerFromDatabase(deleteArgs);
                        break;
                    default:
                        throw new Error('Unknown object to delete: ' + objectType);
                }
                return objectType + ' deleted.';
            }

            function deleteTrainerFromDatabase(args) {
                var trainer = findTrainerByUsername(args),
                    indexOFTrainer = _trainers.indexOf(trainer);

                if (indexOFTrainer === -1) {
                    throw new Error('Trainer does not exist.');
                }

                _trainers.splice(indexOFTrainer, 1);

                _trainings.forEach(function (training) {
                    if (training.getTrainer() === trainer) {
                        training.setTrainer(undefined);
                    }
                });

                delete _uniqueTrainerUsernames[args];
            }

            var trainingCenterEngine = {
                initialize: initialize,
                executeCommand: executeCommand
            };
            return trainingCenterEngine;
        }());

        var Trainer = (function () {
            function Trainer(username, firstName, lastName, email) {
                this.setUsername(username);
                this.setFirstName(firstName);
                this.setLastName(lastName);
                this.setEmail(email);
            }

            Trainer.prototype.getUsername = function () {
                return this._username;
            }

            Trainer.prototype.setUsername = function (username) {
                if (!username || typeof (username) !== 'string') {
                    throw new Error('The username cannot be empty.');
                }

                this._username = username;
            }

            Trainer.prototype.getFirstName = function () {
                return this._firstName;
            }

            Trainer.prototype.setFirstName = function (firstName) {
                if (firstName !== undefined && (firstName === '' || typeof (firstName) !== 'string')) {
                    throw new Error('The first name cannot be empty when added.');
                }

                this._firstName = firstName;
            }

            Trainer.prototype.getLastName = function () {
                return this._lastName;
            }

            Trainer.prototype.setLastName = function (lastName) {
                if (!lastName || typeof (lastName) !== 'string') {
                    throw new Error('The last name cannot be empty.');
                }

                this._lastName = lastName;
            }

            Trainer.prototype.getEmail = function () {
                return this._email;
            }

            Trainer.prototype.setEmail = function (email) {
                if (email !== undefined && email.indexOf('@') === -1) {
                    throw new Error('Email is not valid.');
                }

                this._email = email;
            }

            Trainer.prototype.toString = function () {
                var result = 'Trainer[username=' + this.getUsername();

                if (this.getFirstName()) {
                    result += ';first-name=' + this.getFirstName();
                }

                result += ';last-name=' + this.getLastName();

                if (this.getEmail()) {
                    result += ';email=' + this.getEmail();
                }

                result += ']';

                return result;
            }

            return Trainer;
        })();

        var Training = (function () {
            function Training(name, description, trainer, startDate, duration) {
                if (this.constructor === Training) {
                    throw new Error('Cannot create instance of abstract class Training.');
                }

                this.setName(name);
                this.setDescription(description);
                this.setTrainer(trainer);
                this.setStartDate(startDate);
                this.setDuration(duration);
            }

            Training.prototype.getName = function () {
                return this._name;
            }

            Training.prototype.setName = function (name) {
                if (!name || typeof (name) !== 'string') {
                    throw new Error('Name cannot be empty.');
                }

                this._name = name;
            }

            Training.prototype.getDescription = function () {
                return this._description;
            }

            Training.prototype.setDescription = function (description) {
                if (description !== undefined && (description === '' || typeof (description) !== 'string')) {
                    throw new Error('Description cannot be empty when provided.');
                }

                this._description = description;
            }

            Training.prototype.getTrainer = function () {
                return this._trainer;
            }

            Training.prototype.setTrainer = function (trainer) {
                if (trainer !== undefined && !trainer) {
                    throw new Error('Trainer cannot be empty when provided.');
                }

                this._trainer = trainer;
            }

            Training.prototype.getStartDate = function () {
                return this._startDate;
            }

            Training.prototype.setStartDate = function (startDate) {
                if (!startDate) {
                    throw new Error('Start date is invalid');
                }

                validateDate(startDate);

                this._startDate = startDate;
            }

            Training.prototype.getDuration = function () {
                return this._duration;
            }

            Training.prototype.setDuration = function (duration) {
                if (duration !== undefined && (typeof (duration) !== 'number' || parseFloat(duration) != parseInt(duration) || parseInt(duration) < 1 || 99 < parseInt(duration))) {
                    throw new Error('Duration must be in the range [1 ... 99] when provided.');
                }

                this._duration = duration;
            }

            Training.prototype.toString = function () {
                var result = this.constructor.name
                    + '[name=' + this.getName();

                if (this.getDescription()) {
                    result += ';description=' + this.getDescription()
                }

                if (this.getTrainer()) {
                    result += ';trainer=' + this.getTrainer();
                }

                result += ';start-date=' + formatDate(this.getStartDate());

                return result;
            }

            function validateDate(date) {
                var minStartDate = new Date('1-Jan-2000'),
                    maxStartDate = new Date('31-Dec-2020');

                if (date.getTime() < minStartDate.getTime() || maxStartDate.getTime() < date.getTime()) {
                    throw new Error('Start date is out of range.');
                }
            }

            return Training;
        })();

        var Course = (function () {
            function Course(name, description, trainer, startDate, duration) {
                Training.call(this, name, description, trainer, startDate, duration);
            }

            Course.prototype = Object.create(Training.prototype);
            Course.prototype.constructor = Course;

            Course.prototype.toString = function () {
                var result = Training.prototype.toString.call(this);

                if (this.getDuration()) {
                    result += ';duration=' + this.getDuration();
                }

                result += ']';

                return result;
            }

            return Course;
        })();

        var Seminar = (function () {
            var SEMINAR_DURATION = 1;

            function Seminar(name, description, trainer, startDate) {
                Training.call(this, name, description, trainer, startDate, SEMINAR_DURATION);
            }

            Seminar.prototype = Object.create(Training.prototype);
            Seminar.prototype.constructor = Seminar;

            Seminar.prototype.toString = function () {
                var result = Training.prototype.toString.call(this).replace('start-date', 'date')
                    + ']';

                return result;
            }

            return Seminar;
        })();

        var RemoteCourse = (function () {
            function RemoteCourse(name, description, trainer, startDate, duration, location) {
                Course.call(this, name, description, trainer, startDate, duration);
                this.setLocation(location);
            }

            RemoteCourse.prototype = Object.create(Course.prototype);
            RemoteCourse.prototype.constructor = RemoteCourse;

            RemoteCourse.prototype.getLocation = function () {
                return this._location;
            }

            RemoteCourse.prototype.setLocation = function (location) {
                if (!location) {
                    throw new Error('Location cannot be empty.');
                }

                this._location = location;
            }

            RemoteCourse.prototype.toString = function () {
                var parentToString = Course.prototype.toString.call(this);
                var result = parentToString.substring(0, parentToString.length - 1);

                result += ';location=' + this.getLocation();
                result += ']';

                return result;
            }

            return RemoteCourse;
        })();

        var trainingcenter = {
            Trainer: Trainer,
            Course: Course,
            Seminar: Seminar,
            RemoteCourse: RemoteCourse,
            engine: {
                TrainingCenterEngine: TrainingCenterEngine
            }
        };

        return trainingcenter;
    })();


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


    // Process the input commands and return the results
    var results = '';
    trainingcenter.engine.TrainingCenterEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != '') {
            try {
                var cmdResult = trainingcenter.engine.TrainingCenterEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err.stack);
                results += 'Invalid command.\n';
            }
        }
    });
    return results.trim();
}
