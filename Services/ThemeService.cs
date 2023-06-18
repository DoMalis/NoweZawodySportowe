using Microsoft.AspNetCore.Http;

namespace ProjektZawody.Services
{
    public class ThemeService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ThemeService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetThemeFromCookie()
        {
            string cookieName = "ThemeCookie";
            var themeCookie = _httpContextAccessor.HttpContext.Request.Cookies[cookieName];
            return themeCookie;
        }

        public void SetThemeCookie(string theme)
        {
            string cookieName = "ThemeCookie";
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(7) // Ustawienie ważności ciasteczka na 7 dni
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, theme, cookieOptions);
        }
    }
}
