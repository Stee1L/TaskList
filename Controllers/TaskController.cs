using TaskList.Data;
using TaskList.Models;
namespace TaskList.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class TaskController : Controller
{
    private readonly TaskDbContext _context;

    public TaskController(TaskDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        var tasks = _context.Tasks.ToList(); // Получаем все задачи из базы данных
        return View(tasks); // Передаем задачи в представление Index.cshtml
    }
    
    public IActionResult Create(ToDoTask task)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Add(task); // Добавляем новую задачу в контекст данных
            _context.SaveChanges(); // Сохраняем изменения в базе данных

            return RedirectToAction("Index"); // Перенаправляем пользователя на список задач
        }

        return View(task); // Возвращаем представление с формой для исправления ошибок
    }
    
    public IActionResult Delete(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }

        return View(task);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task == null)
        {
            return NotFound();
        }

        return View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(ToDoTask task)
    {
        if (ModelState.IsValid)
        {
            _context.Update(task);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(task);
    }
}