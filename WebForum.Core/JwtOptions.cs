
namespace WebForum.Core
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;

        public int ExpiresTime { get; set; }
    }
}
