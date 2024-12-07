using AdminPl.ViewModel;
using BLL;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPl;

public class AdminController : BaseController<Admin, AdminVM>
{
    private readonly IAdminUnitOfWork AdminunitOfWork;

    public AdminController(IAdminUnitOfWork unitOfWork) : base(unitOfWork)
    {
        AdminunitOfWork = unitOfWork;
    }


    #region See All admin       
    public async Task<IActionResult > Index()
    {
       var  Admins = await AdminunitOfWork.ReadAllAsync();
        return View(Admins);
    }
    #endregion
    #region Create Admin
    public IActionResult Create()
    {
        return View("Create");
    }
    [HttpPost]
    public async Task<IActionResult> Create(AdminVM adminVM)
    {
        if (ModelState.IsValid)
        {
            var Admin = await AdminunitOfWork.CreateAsync(adminVM);
            return RedirectToAction(nameof(Index));  //subsequence request
        }
        return View(adminVM);
    }
    #endregion
    #region CheckEmail
    public IActionResult CheckEmail(string Email)
    {
        var result = AdminunitOfWork.SearchByEmail(Email);
        return Json(result);
    }
    #endregion
}
