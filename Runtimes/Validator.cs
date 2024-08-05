using System.Text.RegularExpressions;

namespace UValidation
{
    public abstract class Validator : IValidator
    {
        protected abstract string Pattern { get; }

        public bool IsValid { get; private set; }

        public string ErrorMessage { get; private set; }

        protected Validator(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public bool Validate(string value)
        {
            IsValid = CheckCondition(value);
            if (!IsValid)
            {
                ErrorMessage = $"Validation failed for value: {value}";
            }
            return IsValid;
        }

        protected virtual bool CheckCondition(string value)
        {
            return !string.IsNullOrEmpty(value) && Regex.IsMatch(value, Pattern);
        }

        internal static T Create<T>(string errorMessage) where T : Validator, new()
        {
            var instance = new T();
            instance.SetErrorMessage(errorMessage);
            return instance;
        }

        private void SetErrorMessage(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
