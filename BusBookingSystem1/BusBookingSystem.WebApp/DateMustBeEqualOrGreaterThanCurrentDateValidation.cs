using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Web.Models.Validation
{

    //[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class DateMustBeEqualOrGreaterThanCurrentDateValidation : ValidationAttribute
    {

        private const string DefaultErrorMessage = "Date selected  must be on or after today";

        public DateMustBeEqualOrGreaterThanCurrentDateValidation()
            : base(DefaultErrorMessage)
        {
        }

      

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value !=null)
            {
                var dateEntered = (DateTime)value;
                if (dateEntered < DateTime.Today)
                {
                    var message = DefaultErrorMessage;
                    return new ValidationResult(message);
                }
            }
            
            return null;
        }

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    var rule = new ModelClientCustomDateValidationRule(FormatErrorMessage(metadata.DisplayName));
        //    yield return rule;
        //}
    }

    //public sealed class ModelClientCustomDateValidationRule : ModelClientValidationRule
    //{

    //    public ModelClientCustomDateValidationRule(string errorMessage)
    //    {
    //        ErrorMessage = errorMessage;
    //        ValidationType = "datemustbeequalorgreaterthancurrentdate";
    //    }
    //}
}