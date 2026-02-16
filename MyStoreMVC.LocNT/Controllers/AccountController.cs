using Microsoft.AspNetCore.Mvc;
using MyStore.Business.LocNT;
using MyStore.Services.LocNT;

namespace MyStoreMVC.LocNT.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountMember model)
        {
           
            if (model == null || string.IsNullOrEmpty(model.EmailAddress) || string.IsNullOrEmpty(model.MemberPassword))
            {
                ModelState.AddModelError("", "Vui lòng nhập đầy đủ thông tin!");
                return View(model);
            }

            var account = _accountService.GetAccountByEmail(model.EmailAddress);

            if (account != null && account.MemberPassword == model.MemberPassword)
            {
                
                HttpContext.Session.SetString("UserEmail", account.EmailAddress);

                
                HttpContext.Session.SetString("UserRole", account.MemberRole.ToString());

          
                return RedirectToAction("Index", "Products");
            }

            
            ModelState.AddModelError("", "Sai thông tin đăng nhập!"); 
            return View(model); 
        }

        public IActionResult Logout()
        {
            HttpContext.Session?.Clear();
            return RedirectToAction("Login");
        }

    }
}
