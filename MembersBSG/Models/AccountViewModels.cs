using MembersBSG.HtmlHelpers.PhoneNumberValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BSG.WebUI.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterAsCoachViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }
        [Required]
        public bool RegisterNow { get; set; }
        public string WebSite { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[A-Za-z0-9-]+(\\.[A-Za-z0-9-]+)*(\\.[A-Za-z]{2,100})$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        [EnforcePattern(ErrorMessage = "Please enter a valid phone number including area code if it’s a landline")]
        //[MaxLength(16, ErrorMessage = "Please enter a valid phone number including area code if it’s a landline")]
        [RegularExpression(@"^[0][0-9]{9,10}$", ErrorMessage = "Please enter a valid phone number including area code if it’s a landline")]
        [ExcludeRadioTVDramaNumbers(ErrorMessage = "Please enter a valid phone number including area code if it’s a landline")]
        [ExcludeCountryCodeNumbers(ErrorMessage = "No international numbers!")]
        //[EnforceLength(ErrorMessage = "Phone Number must be 10,11 numbers long")]
        [ExcludeNonDigits(ErrorMessage = "Please enter a valid phone number including area code")]
        [ExcludeOFiveHundredRange(ErrorMessage = "Please enter a valid phone number including area code")]
        public string Phone { get; set; }

        [ExcludeNonDigits(ErrorMessage = "Please enter a valid mobile phone number")]
        [ExcludeOFiveHundredRange(ErrorMessage = "Please enter a valid mobile phone number")]
        public string MobilePhone { get; set; }
        public string GolfFacilityName { get; set; }

        
        public CoachAddress Address { get; set; }

        public string Coach1 { get; set; }
        public string Coach2 { get; set; }

        public CoachReferral Referral { get; set; }

        public bool SendUpdates { get; set; }
        public DateTime SubscriptionEnd { get; set; }


        //sms, etc

    }

    public class CoachAddress
    {
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        [DataType(DataType.PostalCode)]
        [MaxLength(8, ErrorMessage = "Please enter your correct postcode")]
        [MinLength(5, ErrorMessage = "Please enter your correct postcode")]
        [RegularExpression("^(([gG][iI][rR] {0,}0[aA]{2})|((([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y]?[0-9][0-9]?)|(([a-pr-uwyzA-PR-UWYZ][0-9][a-hjkstuwA-HJKSTUW])|([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y][0-9][abehmnprv-yABEHMNPRV-Y]))) {0,}[0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2}))$", ErrorMessage = "Please enter your correct postcode")] //FAIRLY LOOSE REGEX - ALLOWS LOWER CASE AND MULTIPLE SPACES
        [Display(Name = "Postcode")]
        public string PostalCode { get; set; }
        public string Country { get; set; }

    }

    public enum CoachReferral
    {
        Recommendation, Facebook, Twitter, LinkedIn, Email, MagazineArticle, WebSiteSearch, Other
    }
}
