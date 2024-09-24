namespace Customer.Application.Constants.Messages.CustomerMessages
{
    public static class CustomerMessage
    {
        public const string EmailIsNotValid = "Email is not valid.";
        public const string EmailRequired = "Email is required.";
        public const string FirstNameRequired = "FirstName is required.";
        public const string LastNameRequired = "LastName is required.";
        public const string EmailExceeded = "Email must not exceed 256 characters.";
        public const string FirstNameExceeded = "FirstName must not exceed 128 characters.";
        public const string LastNameExceeded = "LastName must not exceed 128 characters.";
    }
}
