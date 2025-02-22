using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs.DepartmentDTO;
using Project.BL.DTOs.WorkerDepartmentDTO;
using Project.BL.Exceptions;
using Project.BL.Services.Abstraction;

namespace Project.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class WorkerDepartmentController(IWorkerDepartmentService _departmentService) : Controller
{
    public async Task<IActionResult> Index()
    {
        IEnumerable<GetAllWorkerDepartmentDto> list = await _departmentService.GetAllAsync();

        return View(list);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateWorkerDepartmentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        try
        {
            await _departmentService.CreateAsync(dto);
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
    }
    public async Task<IActionResult> Update(int id)
    {
        try
        {
            return View(await _departmentService.GetByIdForUpdateAsync(id));

        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateWorkerDepartmentDto updateCategoryDto)
    {
        if (!ModelState.IsValid)
        {
            return View(updateCategoryDto);
        }
        await _departmentService.UpdateAsync(updateCategoryDto);
        return RedirectToAction("Index", "WorkerDepartment");
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _departmentService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    public async Task<IActionResult> Details(int id)
    {
        try
        {
            return View(await _departmentService.GetByIdWorkerAsync(id));
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
