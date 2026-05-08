using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcMovie.Controllers;

public class MoviesController : Controller
{
    // Static list for demo (no database needed for submission)
    private static List<Movie> _movies = new()
    {
        new Movie { Id = 1, Title = "When Harry Met Sally", ReleaseDate = DateTime.Parse("1989-07-21"), Price = 19.99m, Genre = "Romantic Comedy", Rating = "R" },
        new Movie { Id = 2, Title = "Ghostbusters", ReleaseDate = DateTime.Parse("1984-06-08"), Price = 14.99m, Genre = "Comedy", Rating = "PG" }
    };

    // GET: Movies
    public IActionResult Index()
    {
        return View(_movies);
    }

    // GET: Movies/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null) return NotFound();
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    // GET: Movies/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Movies/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Id,Title,ReleaseDate,Price,Genre,Rating")] Movie movie)
    {
        if (ModelState.IsValid)
        {
            movie.Id = _movies.Any() ? _movies.Max(m => m.Id) + 1 : 1;
            _movies.Add(movie);
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    // GET: Movies/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null) return NotFound();
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    // POST: Movies/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("Id,Title,ReleaseDate,Price,Genre,Rating")] Movie movie)
    {
        if (id != movie.Id) return NotFound();
        if (ModelState.IsValid)
        {
            var existing = _movies.FirstOrDefault(m => m.Id == id);
            if (existing != null)
            {
                existing.Title = movie.Title;
                existing.ReleaseDate = movie.ReleaseDate;
                existing.Price = movie.Price;
                existing.Genre = movie.Genre;
                existing.Rating = movie.Rating;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    // GET: Movies/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null) return NotFound();
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var movie = _movies.FirstOrDefault(m => m.Id == id);
        if (movie != null) _movies.Remove(movie);
        return RedirectToAction(nameof(Index));
    }
}
