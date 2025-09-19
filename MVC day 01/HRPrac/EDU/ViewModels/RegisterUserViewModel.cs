namespace EDU.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "User name is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirmation is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Does not match password.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
