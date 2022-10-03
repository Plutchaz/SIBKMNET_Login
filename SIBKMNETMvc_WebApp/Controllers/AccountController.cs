﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIBKMNETMvc_WebApp.Context;
using SIBKMNETMvc_WebApp.Repositories.Data;
using SIBKMNETMvc_WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNETMvc_WebApp.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                //statement mengambil data dari database sesuai dengan email dan password
                //return Id employee, FullName, Email, Role -> Masukkan ke ViewModels
                var data = accountRepository.Login(login);

                if (data != null)
                {
                    //inisialisasi nilai pada session
                    HttpContext.Session.SetString("Role", data.Role);
                    return RedirectToAction("Index", "Province");
                }
                return View();
            }
            return View();
        }
    }
}
