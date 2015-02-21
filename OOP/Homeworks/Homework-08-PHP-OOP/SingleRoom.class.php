<?php

class SingleRoom extends Room {
    const DEFAULT_BED_COUNT = 1;
    const ROOM_TYPE = RoomType::STANDARD;
    const HAS_RESTROOM = true;
    const HAS_BALCONY = false;
    const EXTRAS = ['TV', 'air-conditioner'];

    public function __construct($roomNumber, $price) {
        parent::__construct(
            self::ROOM_TYPE,
            self::HAS_RESTROOM,
            self::HAS_BALCONY,
            self::DEFAULT_BED_COUNT,
            $roomNumber,
            self::EXTRAS,
            $price);
    }
}