namespace HealthCare.UI.Shared
{
    public class Authenticate
    {
        private static bool _login = false;
        public static bool IsLogin { get => _login; set {
                _login = value;
                OnLoginChanged?.Invoke();
            } }

        public static event Action OnLoginChanged;
    }
}
