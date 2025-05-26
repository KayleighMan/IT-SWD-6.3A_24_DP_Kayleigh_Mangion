namespace Cab_Frontend.Services
{


    public class UserSessionService
    {
        public string? Email { get; private set; }
        public bool IsLoggedIn => !string.IsNullOrEmpty(Email);

        public event Action? OnChange;

        public void Login(string email)
        {
            Email = email;
            NotifyStateChanged();
        }

        public void Logout()
        {
            Email = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}