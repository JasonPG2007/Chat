using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;
using System.Security.Claims;

namespace Chat.Controllers
{
    public class LoginController : Controller
    {
        #region Variable
        private readonly IAccountRepository accountRepository;
        #endregion

        #region  Constructor
        public LoginController()
        {
            accountRepository = new AccountRepository();
        }
        #endregion

        // GET: LoginController
        public async Task<ActionResult> IndexAsync(Account account)
        {
            var user = accountRepository.Login(account.UserName, account.Password);
            if (user != null)
            {
                Response.Cookies.Append("accountId", user.AccountId.ToString());
                Response.Cookies.Append("username", user.UserName);
                var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, account.UserName),
                        new Claim(ClaimTypes.Role,"User")
                    };
                var identity = new ClaimsIdentity(claims, "User");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("User", principal, new AuthenticationProperties()
                {
                    IsPersistent = true
                });

                return RedirectToAction("", "Home");
            }
            else
            {
                return View();
            }
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(IndexAsync));
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            try
            {
                await HttpContext.SignOutAsync("User");
                Response.Cookies.Delete("username");
                Response.Cookies.Delete("accountId");
                return RedirectToAction("", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.errorQuiz = "Có lỗi xảy ra, hãy thử lại và đừng hành động quá nhanh";
                return View("Error");
            }
        }

    }
}
