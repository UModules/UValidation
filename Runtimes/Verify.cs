using System;
using System.Collections.Generic;

namespace UValidation
{
    public static class Verify
    {
        private static readonly Dictionary<string, IValidator> catched = new();

        public static void AddValidator<T>(string key, T validator) where T : IValidator
        {
            if (catched.ContainsKey(key))
            {
                throw new ArgumentException($"A validator with the key '{key}' already exists.");
            }

            catched.Add(key, validator);
        }

        public static void AddValidator<T>(string key) where T : Validator, new()
        {
            if (catched.ContainsKey(key))
            {
                throw new ArgumentException($"A validator with the key '{key}' already exists.");
            }

            var validator = new T();
            catched.Add(key, validator);
        }

        public static void AddValidator<T>(string key, string errorMessage) where T : Validator, new()
        {
            if (catched.ContainsKey(key))
            {
                throw new ArgumentException($"A validator with the key '{key}' already exists.");
            }

            var validator = Validator.Create<T>(errorMessage);
            catched.Add(key, validator);
        }

        public static T GetValidator<T>(string key) where T : class, IValidator
        {
            if (catched.TryGetValue(key, out var validator))
            {
                return validator as T;
            }

            throw new KeyNotFoundException($"No validator found with the key '{key}'.");
        }

        public static IValidator GetValidator(string key)
        {
            if (catched.TryGetValue(key, out var validator))
            {
                return validator;
            }

            throw new KeyNotFoundException($"No validator found with the key '{key}'.");
        }
    }
}
