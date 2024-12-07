using BLL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPl;
public class BaseController<TEntity,TViewModel> : Controller, IBaseController<TEntity,TViewModel>
    where TEntity : ModelBase
    where TViewModel : ModelViewBase
{
    protected readonly IBaseUnitOfWork<TEntity, TViewModel> _unitOfWork;

    public BaseController(IBaseUnitOfWork<TEntity, TViewModel> unitOfWork)
    {
        _unitOfWork = unitOfWork;
       
    }


    public virtual async Task<IActionResult> Get( int id)
    {

        TViewModel? entity = await _unitOfWork.ReadAsync(id);

        if (entity == null)
            return NotFound();

        return Ok(entity);
    }

    //[HttpPost]
    //public virtual async Task<IActionResult> Create(TViewModel viewModel)
    //{
    //    if (!ModelState.IsValid)
    //        return View(viewModel);

    //   TViewModel? d =  await _unitOfWork.CreateAsync(viewModel);

    //    if (d == null)
    //        throw new Exception("dddd");

    //    return RedirectToAction(nameof(Index));
    //}
    [HttpPut]
    public virtual async Task<IActionResult> Edit(TViewModel tviewModel)
    {
        var entity = await  _unitOfWork.UpdateAsync(tviewModel);
        
        if (entity == null)
            return NotFound();

       
        return View(entity);
    }

    [HttpDelete]
    public virtual async Task<IActionResult> Delete(int id)
    {
        TViewModel? entity = await _unitOfWork.DeleteAsync(id);
        if (entity == null)
            return NotFound();

        return View(entity);
    }


}

