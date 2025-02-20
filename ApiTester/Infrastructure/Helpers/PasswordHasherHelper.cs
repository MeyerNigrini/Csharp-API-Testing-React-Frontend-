using Microsoft.AspNetCore.Identity;

namespace ApiTester.Infrastructure.Helpers
{
    public static class PasswordHasherHelper
    {
        private static readonly PasswordHasher<object> _passwordHasher = new();

        public static string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        public static bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            return _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword) == PasswordVerificationResult.Success;
        }
    }
}
