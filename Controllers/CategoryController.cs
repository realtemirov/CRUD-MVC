using Microsoft.AspNetCore.Mvc;
using youtubelearn.Data;
using youtubelearn.Models;

namespace youtubelearn.Controllers;

public class CategoryController : Controller
{
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    
    public IActionResult Index()
    {
        IEnumerable<Category> objCategoryList = _context.Categories.ToList();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {

        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if(obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The Display Order cannot exactly match the Name");
        }
        if (ModelState.IsValid)
        {
            _context.Categories.Add(obj);
            _context.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if(id == null || id == 0)
        {
            return NotFound();
        }
        
        var categoryFromDb = _context.Categories.Find(id);

        if(categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
        if(obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("name", "The Display Order cannot exactly match the Name");
        }
        if (ModelState.IsValid)
        {
            _context.Categories.Update(obj);
            _context.SaveChanges();
            TempData["success"] = "Category edited successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //GET
    public IActionResult Delete(int? id)
    {
        if(id == null || id == 0)
        {
            return NotFound();
        }
        
        var categoryFromDb = _context.Categories.Find(id);

        if(categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    //POST
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
        var obj = _context.Categories.Find(id);

        if(obj == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(obj);
        _context.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}