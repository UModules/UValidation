namespace UValidation
{
    public interface IValidator
    {
        string ErrorMessage { get; }
        bool Validate(string value);
    }
}
