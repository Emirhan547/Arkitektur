namespace Arkitektur.WebUI.DTOs.TokenDtos
{
    public class TokenResponseDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; } // ← BU OLMALI
        public DateTime ExpireTime { get; set; }
    }
}
