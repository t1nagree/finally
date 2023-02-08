namespace InfrormationSystem
{
    public class Program
    {
        public static void Main()
        {
            User user = new AuthenticationCntrl().StartAuthentication();
            new AuthorizationCntrl().StartAuthorization(user);
        }
    }
}