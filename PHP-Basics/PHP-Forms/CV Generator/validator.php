<?php
class FormDataParser
{
    private $fieldsInfo = '';
    private $lettersOnlyRegex = "/[^a-zA-Z]/";
    private $numbersAndLettersRegex = "/[^a-zA-Z0-9]/";
    private $phoneNumberRegex = "/\+?([0-9]\-?\ ?){1,}/";
    private $emailRegex = "/[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z]+/";

    function __construct($fieldsInfo) {
        $this->fieldsInfo = $fieldsInfo;
    }

    public function validate() {
        if (isset(
            $this->fieldsInfo['fname'],
            $this->fieldsInfo['lname'],
            $this->fieldsInfo['email'],
            $this->fieldsInfo['sex'])) {
            return $this->validateData();
        }

        return false;
    }

    public function getField($fieldName) {
        if (isset($this->fieldsInfo[$fieldName])) {
            return htmlentities($this->fieldsInfo[$fieldName]);
        }
        return '';
    }

    public function getProgrammingLanguages() {
        $langs = [];
        $skillLevels = $this->fieldsInfo["pLangLevel"];
        $index = 0;
        foreach ($this->fieldsInfo["pLangs"] as $lang) {
            $langs[htmlentities($lang)] = htmlentities($skillLevels[$index++]);
        }

        return $langs;
    }

    public function getLanguages() {
        $langs = [];
        $comprehension = $this->fieldsInfo["comprehension"];
        $readingLevels = $this->fieldsInfo["readingLevel"];
        $writingLevels = $this->fieldsInfo["writingLevel"];
        $index = 0;
        foreach ($this->fieldsInfo["langs"] as $lang) {
            $langs[htmlentities($lang)] =
                (object)['comprehension' => htmlentities($comprehension[$index]),
                'readingLevel' => htmlentities($readingLevels[$index]),
                'writingLevel' => htmlentities($writingLevels[$index])];
            $index++;
        }

        return $langs;
    }

    public function getDriverLicenses() {
        if (isset($this->fieldsInfo['category'])) {
            return htmlentities(implode(',', $this->fieldsInfo['category']));
        }

        return "";
    }

    // Long function to provide good information
    private function validateData() {
        $lengthError = 'name must be between 2 and 20 symbols!';

        $firstName = $this->fieldsInfo['fname'];
        $this->checkLength($firstName) or die("First ".$lengthError);
        !preg_match($this->lettersOnlyRegex, $firstName)
        or die("First name must contain only letters!");

        $lastName = $this->fieldsInfo['lname'];
        $this->checkLength($lastName) or die("Last ".$lengthError);
        !preg_match($this->lettersOnlyRegex, $lastName)
        or die("Last name must contain only letters!");

        $companyName = $this->fieldsInfo['companyName'];
        $this->checkLength($companyName) or die("Company ".$lengthError);
        !preg_match($this->numbersAndLettersRegex, $companyName)
        or die("Company name must contain only letters and numbers!");

        $phoneNumber = $this->fieldsInfo['phoneNumber'];
        preg_match($this->phoneNumberRegex, $phoneNumber)
        or die("Phone number must contain Numbers and “+”, “-”, “ ” only!");

        $email = $this->fieldsInfo['email'];
        preg_match($this->emailRegex, $email)
        or die("Email must contain Letters, Numbers and only one “@”, only one “.”");

        // Validate languages arrays
        $this->validateLanguages();

        return true;
    }

    private function checkLength($field) {
        return strlen($field) >= 2 && strlen($field) <= 20;
    }

    private function validateLanguages() {
        $lengthError = 'language must be between 2 and 20 symbols!';

        foreach($this->fieldsInfo['pLangs'] as $lang) {
            $this->checkLength($lang) or die('Programming '.$lengthError);
            !preg_match($this->lettersOnlyRegex, $lang)
            or die("Programming language must contain only letters!");
        }

        foreach ($this->fieldsInfo['langs'] as $lang) {
            $this->checkLength($lang) or die($lengthError);
            !preg_match($this->lettersOnlyRegex, $lang)
            or die("language must contain only letters!");
        }
    }
}