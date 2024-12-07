using AdminPl.ViewModel;
using AutoMapper;
using BLL.Interfaces;
using BLL.Repositories;
using DAL;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AdminPl.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        #region See All Companies       
        public IActionResult Index(string SearchInp)
        {
            var Company = Enumerable.Empty<Company>();

            if (string.IsNullOrEmpty(SearchInp))
            {
                Company = _unitOfWork.CompanyRepository.GetAll();
            }
            else
            {
                Company = _unitOfWork.CompanyRepository.SearchByName(SearchInp.ToLower());
            }
            var mappedCompany = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyVm>>(Company);
            return View(mappedCompany);
        }
        #endregion

        #region Create company
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CompanyVm companyVm)
        {
            if (ModelState.IsValid)
            {
                var mappedcompany = _mapper.Map<Company>(companyVm);
                
                _unitOfWork.CompanyRepository.Add(mappedcompany);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));  //subsequence request
            }
            return View(companyVm);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var company = _unitOfWork.CompanyRepository.GetWithTravles(id);
            if (company == null)
            {
                return NotFound();
            }
            var companyVM = _mapper.Map<CompanyDetailsVM>(company);
            return View("Details", companyVM);


        }
        #endregion
        #region Delete
        public IActionResult Delete(int id)
        {
            var compeny = _unitOfWork.CompanyRepository.Get(id);
            if (compeny is not null)
            {
                _unitOfWork.CompanyRepository.Delete(compeny);
                _unitOfWork.Complete();

            }
            return RedirectToAction("index");
        } 
        #endregion

        public IActionResult Edit(int id)
        {
            var companyDB = _unitOfWork.CompanyRepository.Get(id);
            var CompanyVM  =  _mapper.Map<CompanyVm>(companyDB);    

            return View("Edit", CompanyVM);

        }
        [HttpPost]
        public IActionResult SaveEdit(CompanyVm companyVM)
        {
            if (ModelState.IsValid)
            { 
                var companyDB = _unitOfWork.CompanyRepository.Get(companyVM.Id);
                if (companyDB == null)
                {
                    return NotFound(); 
                }

              // we don't use mapper here because the email is readonly and(Unique)
              // if you insert to the database an error will appeare to you(can't insert duplicate)
              // this because the validation we put in the ViewModel Of the company
                companyDB.Name = companyVM.Name;
                companyDB.IsActive = companyVM.IsActive;

                _unitOfWork.CompanyRepository.Update(companyDB);
                _unitOfWork.Complete();

                return RedirectToAction("index");
            }

            return View("Edit",companyVM); 

        }

        #region CheckEmail
        public IActionResult CheckEmail(string Email)
        {
            var result= _unitOfWork.CompanyRepository.SearchByEmail(Email);
            return Json(result);
        }
        #endregion

    }
}
