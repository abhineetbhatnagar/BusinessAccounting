using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingPlanner.System
{
    #region ValidValues Annotation
    public class ValidValuesAttribute : ValidationAttribute
    {
        string[] _args;

        public ValidValuesAttribute(params string[] args)
        {
            _args = args;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (_args.Contains((string)value))
                return ValidationResult.Success;
            return new ValidationResult(ErrorMessage);
        }
    }
    #endregion

    #region Verhoeff Aadhar Validator
    public class AadharAttribute : ValidationAttribute
    {
        string[] _args;

        private static int[,] _multiplicationTable = {
            { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            { 1, 2, 3, 4, 0, 6, 7, 8, 9, 5 },
            { 2, 3, 4, 0, 1, 7, 8, 9, 5, 6 },
            { 3, 4, 0, 1, 2, 8, 9, 5, 6, 7 },
            { 4, 0, 1, 2, 3, 9, 5, 6, 7, 8 },
            { 5, 9, 8, 7, 6, 0, 4, 3, 2, 1 },
            { 6, 5, 9, 8, 7, 1, 0, 4, 3, 2 },
            { 7, 6, 5, 9, 8, 2, 1, 0, 4, 3 },
            { 8, 7, 6, 5, 9, 3, 2, 1, 0, 4 },
            { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }
        };

        private static int[,] _permutationTable = {
            { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            { 1, 5, 7, 6, 2, 8, 3, 0, 9, 4 },
            { 5, 8, 0, 3, 7, 9, 6, 1, 4, 2 },
            { 8, 9, 1, 6, 0, 4, 3, 5, 2, 7 },
            { 9, 4, 5, 3, 1, 2, 6, 8, 7, 0 },
            { 4, 2, 8, 6, 5, 7, 3, 9, 0, 1 },
            { 2, 7, 9, 3, 8, 0, 6, 4, 1, 5 },
            { 7, 0, 4, 6, 9, 1, 3, 2, 5, 8 }
        };

        private static int[] _inverseTable = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };

        public AadharAttribute(params string[] args)
        {
            _args = args;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int c = 0;

            // NULL CHECK FOR AADHAAR.
            if (value == null) return ValidationResult.Success;

            int len = value.ToString().Length;

            for (int i = 0; i < len; ++i)
                c = _multiplicationTable[c, _permutationTable[(i % 8), value.ToString()[len - i - 1] - '0']];

            if (c == 0)
                return ValidationResult.Success;
            return new ValidationResult(ErrorMessage);
        }
    }
    #endregion

    #region RequiredIf Validator
    public class RequiredIfAttribute : ValidationAttribute
    {
        RequiredAttribute _innerAttribute = new RequiredAttribute();
        public string _dependentProperty { get; set; }
        public object _targetValue { get; set; }

        public RequiredIfAttribute(string dependentProperty, object targetValue)
        {
            this._dependentProperty = dependentProperty;
            this._targetValue = targetValue;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var field = validationContext.ObjectType.GetProperty(_dependentProperty);
            if (field != null)
            {
                var dependentValue = field.GetValue(validationContext.ObjectInstance, null);
                if ((dependentValue == null && _targetValue == null) || (dependentValue.Equals(_targetValue)))
                {
                    if (!_innerAttribute.IsValid(value))
                    {
                        string name = validationContext.DisplayName;
                        return new ValidationResult(ErrorMessage = name + " Is required.");
                    }
                }
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(FormatErrorMessage(_dependentProperty));
            }
        }
    }
    #endregion
}
