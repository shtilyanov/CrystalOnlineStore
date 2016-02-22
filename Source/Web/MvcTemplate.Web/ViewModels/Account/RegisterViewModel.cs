namespace OnlineCrystalStore.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email/Username")]
        [UIHint("EmailAdress")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [UIHint("Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [UIHint("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Address")]
        [StringLength(1500, ErrorMessage = "The address is too long.")]
        [UIHint("MultilineText")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [UIHint("SingleLineText")]
        public string PhoneNumber { get; set; }

        [Display(Name ="Avatar")]
        public HttpPostedFileBase UploadedAvatar { get; set; }
    }
}
