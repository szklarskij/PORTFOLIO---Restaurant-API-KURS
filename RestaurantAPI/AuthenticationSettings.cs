namespace RestaurantAPI
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public int JwtEspireDays { get; set; }
        public string JwtIssuer { get; set; }


    }
}
