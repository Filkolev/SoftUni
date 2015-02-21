<?php

class BookingManager {
    public static function bookRoom(Room $room, Reservation $reservation) {
        try{
            $room->addReservation($reservation);

            $successMessage =  "Room <strong>" . $room->getRoomNumber() . "</strong> successfully booked ";
            $successMessage .= "for <strong>" . $reservation->getGuest();
            $successMessage .= "</strong> from <time>" . $reservation->getStarDate()->format("d.m.Y") . "</time> ";
            $successMessage .= "to <time>" . $reservation->getEndDate()->format("d.m.Y") . "</time>!";
            $successMessage .= "</br>";

            echo $successMessage;
        } catch (EReservationException $ex) {
            echo "<strong>Operation failed.</strong> " . $ex->getMessage() . "</br>";
            return;
        }
    }
}