<?php

class RoomType {
    const STANDARD = 1;
    const GOLD = 2;
    const DIAMOND = 3;

    public static function isValidRoomType($roomType) {
        if (!is_int($roomType)) {
            return false;
        }

        if ($roomType < self::STANDARD || self::DIAMOND < $roomType) {
            return false;
        }

        return true;
    }
}