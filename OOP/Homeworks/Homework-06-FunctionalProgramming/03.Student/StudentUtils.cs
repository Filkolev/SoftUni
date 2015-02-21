namespace _03.Student
{
    using System.Text.RegularExpressions;

    public static class StudentUtils
    {
        private const string NameMatcher = @"^[A-Z][a-zA-Z\-]{1,19}$";
        private const int ValidFacultyNumberMinValue = 100000;
        private const int ValidFacultyNumberMaxValue = 999999;
        private const string PhoneMatcher =
            @"(?:\+\d{3}(?:[ \-]?))?\(?([0-9]{2,3})\)?([ .\-\/]?)([0-9]{2,3})\2([0-9]{2,4})";

        private const string EmailMatcher =
            @"^[a-z0-9!#$%&'*+\/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+\/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";

        public static bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            if (!Regex.IsMatch(name, NameMatcher))
            {
                return false;
            }

            return true;
        }

        public static bool IsValidFacultyNumber(int number)
        {
            if (number < ValidFacultyNumberMinValue || ValidFacultyNumberMaxValue < number)
            {
                return false;
            }

            return true;
        }

        public static bool IsValidPhoneNumber(string phone)
        {
            if (!Regex.IsMatch(phone, PhoneMatcher))
            {
                return false;
            }

            return true;
        }

        public static bool IsValidEmail(string email)
        {
            if (!Regex.IsMatch(email, EmailMatcher))
            {
                return false;
            }

            return true;
        }
    }
}
