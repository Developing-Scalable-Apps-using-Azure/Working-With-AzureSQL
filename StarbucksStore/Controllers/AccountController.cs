using StarbucksStore.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using StarbucksStore.Models;
using System.Threading.Tasks;
using StarbucksStore.Services;

namespace StarbucksStore.Controllers
{
    public class AccountController : Controller
    {

        AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
   
            if (ModelState.IsValid)
            {
                 _accountService.RegisterNewStoreAndUser(model);
            }

            // If we got this far, redirect to successpage
            return RedirectToAction("success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
