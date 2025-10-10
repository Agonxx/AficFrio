namespace AficFrio.Shared.Constants
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Dev = "Dev";

        public const string DevAccess = $"{Dev}";
        public const string AdminAccess = $"{Admin},{Dev}";
    }
}
