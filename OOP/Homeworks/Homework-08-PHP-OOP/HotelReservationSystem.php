<?php

date_default_timezone_set("Europe/Sofia");

function __autoload($className) {
    include_once("./" . $className . ".class.php");
}

$room = new SingleRoom(1408, 99);
$guest = new Guest("Svetlin", "Nakov", 8003224277);
$startDate = strtotime("24.10.2014");
$endDate = strtotime("26.10.2014");
$reservation = new Reservation($startDate, $endDate, $guest);
BookingManager::bookRoom($room, $reservation);

echo $room;
echo $reservation;

$rooms = [
    new Bedroom(11, 1100),
    new SingleRoom(12, 59),
    new Apartment(13, 599),
    new Bedroom(14, 250),
    new Apartment(15, 3432),
    new SingleRoom(16, 23.66),
    new Apartment(17, 120)
];

BookingManager::bookRoom($rooms[0], $reservation);
BookingManager::bookRoom($rooms[0], $reservation);
BookingManager::bookRoom($rooms[1], $reservation);

// Filter the array by bedrooms and apartments with a price less or equal to 250.00
$filteredByTypeAndPrice = array_filter($rooms, function (Room $room) {
    if ($room->getPrice() <= 250 && ($room instanceof Bedroom || $room instanceof Apartment)) {
        return true;
    }

    return false;
});

echo "</br><strong>Bedrooms and apartments with price of 250 or less:</strong></br>";
foreach($filteredByTypeAndPrice as $room) {
    echo $room . "</br>";
}

// Filter the array by all rooms with a balcony
$roomsWithBalcony = array_filter($rooms, function (Room $room) {
    if ($room->getHasBalcony() === true) {
        return true;
    }

    return false;
});

echo "</br><strong>Rooms with a balcony:</strong></br>";
foreach($roomsWithBalcony as $room) {
    echo $room . "</br>";
}

// Return the room numbers of all rooms which have a bathtub in their extras
$roomsWithBathtub = array_filter($rooms, function (Room $room) {
    if (array_search('bathtub', $room->getExtras()) !== false) {
        return true;
    }
    return false;
});

echo "</br><strong>Room numbers for all rooms with a bathtub:</strong></br>";

$roomNumbers = array();
foreach ($roomsWithBathtub as $room) {
    $roomNumbers[] = $room->getRoomNumber();
}

echo implode(", ", $roomNumbers) . "</br>";

// Filter the array by all apartments which are not booked in a given time period (e.g. between 17.10.2014 and 19.10.2014)
$startDate = DateTime::createFromFormat("d.m.Y", "25.10.2014");
$endDate = DateTime::createFromFormat("d.m.Y", "26.10.2014");

$availableRoomsInPeriod = array_filter($rooms, function(Room $room) {
    global $startDate;
    global $endDate;

    $reservations = $room->getReservations();
    $isAvailable = true;

    foreach ($reservations as $reservation) {
        $startInPeriod = $reservation->getStarDate() > $startDate &&
            $reservation->getStarDate() < $endDate;

        $endsInPeriod = $reservation->getEndDate() > $startDate &&
            $reservation->getEndDate() <  $endDate;

        if ($startInPeriod || $endsInPeriod) {
            $isAvailable = false;
            break;
        }
    }

    return $isAvailable;
});

echo "</br><strong>Rooms available between 25th and 26th October 2014:</strong></br>";
foreach ($availableRoomsInPeriod as $room) {
    echo $room . "</br>";
}
