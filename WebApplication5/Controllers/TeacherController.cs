using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.ApplicationContext;
using WebApplication5.Models;

namespace WebApplication5.Controllers;

public class TeacherController : Controller
{
    private readonly ApplicationDbContext context;

    public TeacherController(ApplicationDbContext context)
    {
        this.context = context;
    }
    [HttpGet]
    public async Task<IActionResult>  Index()
    {
        var data=await context.Set<Teacher>().AsNoTracking().ToListAsync();
        return View(data);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id)
    {
        if (id==0)
        {
            return View(new Teacher());
        }
        else
        {
            var data = await context.Set<Teacher>().FindAsync(id);
            return View(data);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(int id,Teacher teacher)
    {
        if (id==0)
        {
            if (ModelState.IsValid)
            {
                await context.Set<Teacher>().AddAsync(teacher);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        else
        {
            context.Set<Teacher>().Update(teacher);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(new Teacher());
    }

    public async Task<IActionResult> Delete(int id)
    {
        if (id!=0)
        {
            var data = await context.Set<Teacher>().FindAsync(id);
            if (data is not null)
            {
                context.Set<Teacher>().Remove(data);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var data = await context.Set<Teacher>().FindAsync(id);
        return View(data);
    }
}
