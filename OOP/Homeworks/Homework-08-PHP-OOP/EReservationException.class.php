<?php

class EReservationException extends Exception {
    public function __construct($message) {
        parent::__construct($message, 404);
    }
}