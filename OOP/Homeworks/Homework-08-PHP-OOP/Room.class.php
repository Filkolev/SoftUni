<?php

abstract class Room implements iReservable {
    private $roomType;
    private $hasRestroom;
    private $hasBalcony;
    private $bedCount;
    private $roomNumber;
    private $extras;
    private $reservations = array();
    private $price;

    protected function __construct($roomType, $hasRestroom, $hasBalcony, $bedCount, $roomNumber, array $extras, $price) {
        $this->setRoomType($roomType);
        $this->setHasRestroom($hasRestroom);
        $this->setHasBalcony($hasBalcony);
        $this->setBedCount($bedCount);
        $this->setRoomNumber($roomNumber);
        $this->setExtras($extras);
        $this->setPrice($price);
    }

    public function getRoomType() {
        return $this->roomType;
    }

    public function setRoomType($roomType) {
        if (!RoomType::isValidRoomType($roomType)) {
            throw new Exception("Room type is not valid.");
        }

        $this->roomType = $roomType;
    }

    public function getHasRestroom() {
        return $this->hasRestroom;
    }

    public function setHasRestroom($hasRestroom) {
        if (!is_bool($hasRestroom)) {
            throw new Exception("Boolean value expected for parameter 'hasRestroom'.");
        }

        $this->hasRestroom = $hasRestroom;
    }

    public function getHasBalcony() {
        return $this->hasRestroom;
    }

    public function setHasBalcony($hasBalcony) {
        if (!is_bool($hasBalcony)) {
            throw new Exception("Boolean value expected for parameter 'hasBalcony'.");
        }

        $this->hasBalcony = $hasBalcony;
    }

    public function getBedCount() {
        return $this->bedCount;
    }

    public function setBedCount($bedCount) {
        if (!is_int($bedCount)) {
            throw new Exception("An integer value expected for parameter 'bedCount'.");
        }

        $this->bedCount = $bedCount;
    }

    public function getRoomNumber() {
        return $this->roomNumber;
    }

    public function setRoomNumber($roomNumber) {
        if (!is_int($roomNumber)) {
            throw new Exception("An integer value expected for parameter 'roomNumber'.");
        }

        $this->roomNumber = $roomNumber;
    }

    public function getExtras() {
        $extrasCopy = $this->extras;
        return $extrasCopy;
    }

    private function setExtras(array $extras) {
        $this->extras = $extras;
    }

    public function getReservations() {
        $reservationsCopy = $this->reservations;
        return $reservationsCopy;
    }

    public function getPrice() {
        return $this->price;
    }

    public function setPrice($price) {
        if (!is_numeric($price)) {
            throw new Exception("Numeric value expected for parameter 'price'.");
        }

        if ($price <= 0) {
            throw new Exception("Price should be positive.");
        }

        $this->price = $price;
    }

    public function addReservation(Reservation $reservation) {
        if ($this->hasReservationOverlap($reservation)) {
            throw new EReservationException("The reservation overlaps with an existing reservation for the specified room.");
        }

        $this->reservations[] = $reservation;
    }

    public function removeReservation(Reservation $reservation) {
        if (($key = array_search($reservation, $this->reservations)) === false) {
            throw new Exception("The specified reservation does not exist");
        }

        unset($this->reservations[$key]);
    }

    private function hasReservationOverlap(Reservation $reservation) {
        foreach($this->reservations as $currentReservation) {
            if ($this->areOverlappingReservations($currentReservation, $reservation)) {
                return true;
            }

            return false;
        }
    }

    private function areOverlappingReservations(Reservation $reservation1, Reservation $reservation2) {
        $secondStartsDuringFirst = $reservation2->getStarDate() >= $reservation1->getStarDate() &&
            $reservation2->getStarDate() <= $reservation1->getEndDate();

        $firstStartsDuringSecond = $reservation1->getStarDate() >= $reservation2->getStarDate() &&
            $reservation1->getStarDate() <=  $reservation2->getEndDate();

        return $firstStartsDuringSecond || $secondStartsDuringFirst;
    }

    public function __toString() {
        $roomInfo = "Room " . $this->getRoomNumber() . "</br>";
        $roomInfo .= "Type: " . $this->getRoomType() . "</br>";
        $roomInfo .= "Number of beds: " . $this->getBedCount() . "</br>";
        $roomInfo .= "Restroom: " . ($this->getHasRestroom() ? "Yes" : "No") . "</br>";
        $roomInfo .= "Balcony: " . ($this->getHasBalcony() ? "Yes" : "No") . "</br>";
        $roomInfo .= "Extras: " . implode(", ", $this->getExtras()) . "</br>";
        $roomInfo .= "Price: " . $this->getPrice() . "</br>";

        return $roomInfo;
    }
}