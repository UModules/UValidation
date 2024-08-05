namespace UValidation
{
    public class PhoneNumberValidator : Validator
    {
        protected override string Pattern => @"^\+?(\d{1,3})?[-. ]?\(?\d{3}\)?[-. ]?\d{3}[-. ]?\d{4}$";

        public PhoneNumberValidator() : base("Invalid phone number format.") { }
    }
}
