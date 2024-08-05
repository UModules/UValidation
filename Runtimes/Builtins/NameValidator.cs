namespace UValidation
{
    public class NameValidator : Validator
    {
        protected override string Pattern => @"^[a-zA-Z\s']{2,}$";

        public NameValidator() : base("Invalid name format.") { }
    }
}
