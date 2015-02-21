<?php

interface iReservable{
    public function addReservation(Reservation $reservation);

    public function removeReservation(Reservation $reservation);
}
