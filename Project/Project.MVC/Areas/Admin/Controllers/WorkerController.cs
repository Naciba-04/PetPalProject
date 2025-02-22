using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BL.DTOs.ProductDTO;
using Project.BL.DTOs.WorkerDTO;
using Project.BL.Exceptions;
using Project.BL.Services.Abstraction;
using Project.BL.Services.Implementation;

namespace Project.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class WorkerController(IWorkerService _workerService, IWorkerDepartmentService _departmentService) : Controller
{
    public async Task<IActionResult> Index()
    {
        try
        {
            IEnumerable<GetAllWorkerDto> list = await _workerService.GetAllAsync();

            return View(list);
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }
    public async Task<IActionResult> Create()
    {

        try
        {
            ViewData["WorkerDepartment"] = new SelectList(await _departmentService.GetDepartmentListItemsAsync(), "Id", "Name");
            return View();
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateWorkerDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["WorkerDepartment"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
            return View(dto);
        }
        try
        {
            await _workerService.CreateAsync(dto);
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ViewData["WorkerDepartment"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
    }
    public async Task<IActionResult> Update(int id)
    {
        try
        {
            ViewData["WorkerDepartment"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
            return View(await _workerService.GetByIdForUpdateAsync(id));

        }
        catch (BaseException ex)
        {
            ViewData["WorkerDepartment"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateWorkerDto dto)
    {
        //if (!ModelState.IsValid)
        //{
        //    ViewData["Department"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
        //    return View(dto);
        //}
        try
        {
            await _workerService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ViewData["WorkerDepartment"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ViewData["WorkerDepartment"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _workerService.DeleteAsync(id);
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
            return View(await _workerService.GetByIdWithChildrenAsync(id));
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
