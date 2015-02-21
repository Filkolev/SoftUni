<?php

class Apartment extends Room {
    const DEFAULT_BED_COUNT = 4;
    const ROOM_TYPE = RoomType::DIAMOND;
    const HAS_RESTROOM = true;
    const HAS_BALCONY = true;
    const EXTRAS = ['TV', 'air-conditioner', 'refrigerator', 'kitchen box', 'mini-bar', 'bathtub', 'free Wi-fi'];

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