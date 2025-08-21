namespace SwinBite.DTO
{
    public class CreateCustomerDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }
        public string Address { get; set; }
    }
}
