using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XorAttribute : ValidationAttribute
    {
        private string targetProperty;

        public XorAttribute(string targetProperty)
        {
            this.targetProperty = targetProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object targetPropValue = validationContext
                .ObjectType
                .GetProperty(this.targetProperty)
                .GetValue(validationContext.ObjectInstance);

            if ((value == null) ^ (targetPropValue == null))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("OppositeValues");
        }
    }
}
