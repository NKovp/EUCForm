using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace EUCFormApp.Controllers
{
    public class LanguageController : Controller
    {
        /// <summary>
        /// Nastaví jazyk aplikace a přesměruje zpět na původní URL
        /// </summary>
        /// <param name="culture">Culture, ktera se ma nastavit.</param>
        /// <param name="returnUrl">Puvodni URL</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Set(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return LocalRedirect(returnUrl);
        }
    }
}
