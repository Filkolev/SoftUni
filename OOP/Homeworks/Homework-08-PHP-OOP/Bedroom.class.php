<?php

class Bedroom extends Room {
    const DEFAULT_BED_COUNT = 2;
    const ROOM_TYPE = RoomType::GOLD;
    const HAS_RESTROOM = true;
    const HAS_BALCONY = true;
    const EXTRAS = ['TV', 'air-conditioner', 'refrigerator', 'mini-bar', 'bathtub'];

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
