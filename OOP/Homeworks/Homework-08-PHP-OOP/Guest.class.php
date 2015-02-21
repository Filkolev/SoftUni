<?php

class Guest {
    private $firstName;
    private $lastName;
    private $id;

    public function __construct($firstName, $lastName, $id) {
        $this->setFirstName($firstName);
        $this->setLastName($lastName);
        $this->setId($id);
    }

    public function getFirstName(){
        return $this->firstName;
    }

    public function setFirstName($firstName) {
        if (strlen($firstName) < 2) {
            throw new Exception("The first name of the guest should be at least 2 symbols long.");
        }

        $this->firstName = $firstName;
    }

    public function getLastName(){
        return $this->lastName;
    }

    public function setLastName($lastName) {
        if (strlen($lastName) < 2) {
            throw new Exception("The last name of the guest should be at least 2 symbols long.");
        }

        $this->lastName = $lastName;
    }

    public function getId() {
        return $this->id;
    }

    public function setId($id) {
        if (!is_numeric($id)) {
            throw new Exception("The id should be a number.");
        }

        if ($id < 1000000000 || 9999999999 < $id) {
            throw new Exception("The id should be a 10-digit number.");
        }

        $this->id = $id;
    }

    public function __toString() {
        return $this->getFirstName() . " " . $this->getLastName();
    }
}