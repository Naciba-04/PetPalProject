using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.BL.DTOs.ProductDTO;
using Project.BL.Exceptions;
using Project.BL.Services.Abstraction;
using Project.BL.Services.Implementation;

namespace Project.MVC.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ProductController(IProductService _productService,IDepartmentService _departmentService) : Controller
{
    public async Task<IActionResult> Index()
    {
        try
        {
            IEnumerable<GetAllProductDto> list = await _productService.GetAllAsync();

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
            ViewData["Department"] = new SelectList(await _departmentService.GetDepartmentListItemsAsync(), "Id", "Name");
            return View();
        }
        catch (Exception)
        {
            return BadRequest("Something went wrong!");
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Department"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
            return View(dto);
        }
        try
        {
            await _productService.CreateAsync(dto);
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ViewData["Department"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
    }
    public async Task<IActionResult> Update(int id)
    {
        try
        {
            ViewData["Department"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
            return View(await _productService.GetByIdForUpdateAsync(id));

        }
        catch (BaseException ex)
        {
            ViewData["Department"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateProductDto dto)
    {
        //if (!ModelState.IsValid)
        //{
        //    ViewData["Department"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
        //    return View(dto);
        //}
        try
        {
            await _productService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }
        catch (BaseException ex)
        {
            ViewData["Department"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
            ModelState.AddModelError("CustomError", ex.Message);
            return View(dto);
        }
        catch (Exception)
        {
            ViewData["Department"] = new SelectList(await _departmentService.GetAllAsync(), "Id", "Name");
            ModelState.AddModelError("CustomError", "Something went wrong!");
            return View(dto);
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _productService.DeleteAsync(id);
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
            return View(await _productService.GetByIdWithChildrenAsync(id));
        }
        catch (BaseException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
