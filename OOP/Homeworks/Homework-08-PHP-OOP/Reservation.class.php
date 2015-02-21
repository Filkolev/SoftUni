<?php

class Reservation {
    private $startDate;
    private $endDate;
    private $guest;

    public function __construct($startDate, $endDate, Guest $guest) {
        $this->setStartDate($startDate);
        $this->setEndDate($endDate);
        $this->setGuest($guest);
    }

    public function getStarDate() {
        $date = new DateTime();
        $date->setTimestamp($this->startDate);

        return $date;
    }

    public function setStartDate($startDate) {
        try{
            $date = new DateTime();
            $date->setTimestamp($startDate);
        } catch (Exception $ex) {
            throw new Exception("Start date is not a valid date.");
        }

        $this->startDate = $startDate;
    }

    public function getEndDate() {
        $date = new DateTime();
        $date->setTimestamp($this->endDate);

        return $date;
    }

    public function setEndDate($endDate) {
        try{
            $date = new DateTime();
            $date->setTimestamp($endDate);
        } catch (Exception $ex) {
            throw new Exception("End date is not a valid date.");
        }

        $this->endDate = $endDate;
    }

    public function getGuest() {
        return $this->guest;
    }

    public function setGuest(Guest $guest) {
        $this->guest = $guest;
    }

    public function __toString() {
        $reservationInfo = "Reservation for: " . $this->getGuest() . ", ";
        $reservationInfo .= "from " . $this->getStarDate()->format("m.d.Y");
        $reservationInfo .= " to " . $this->getEndDate()->format("m.d.Y");
        $reservationInfo .= "</br>";

        return $reservationInfo;
    }
}