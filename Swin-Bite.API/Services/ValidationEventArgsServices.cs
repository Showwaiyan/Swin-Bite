namespace SwinBite.Services
{
    public class ValidationEventArgs : EventArgs
    {
        public bool IsValid { get; set; } = true;
        public string ErrorMessage { get; set; }
    }
}
