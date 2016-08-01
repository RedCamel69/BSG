using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MembersBSG.HtmlHelpers.PhoneNumberValidation
{
    public abstract class BaseTelephoneValidationAttribute : ValidationAttribute, IClientValidatable
    {
        protected string expressions; // || seperated list of reg expressions
        protected string derivedType; //used as validationType for client rules

        public BaseTelephoneValidationAttribute()
        {

            derivedType = this.GetType().Name.ToLower();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null) { }
            else
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }

            var phoneNumber = RemoveHyphens(RemoveSpaces(value.ToString()));

            Regex regex = new Regex(expressions);
            Match match = regex.Match(phoneNumber);
            if (match.Success)
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }


            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("expressions", expressions);
            rule.ValidationType = derivedType;
            //rule.ValidationType = "genericphonevalidationhandler";
            yield return rule;
        }


        protected string RemoveSpaces(string number)
        {
            return Regex.Replace(number, @"\s+", "");
        }

        protected string RemoveHyphens(string number)
        {
            return Regex.Replace(number, @"[-]+", "");
        }
    }
}