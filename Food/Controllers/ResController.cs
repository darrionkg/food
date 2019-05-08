using Microsoft.AspNetCore.Mvc;
using Food.Models;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace Food.Controllers
{
  public class ResController : Controller
  {

    // [HttpGet("/world/{id}")]
    // public ActionResult Show(int id)
    // {
    //   Counter counter = Counter.Find(id);
    //   return View(counter);
    // }

    [HttpGet("/Res")]
    public ActionResult Index()
    {
        List<Res> allCounters = Res.GetAll();
        return View(allCounters);
    }

    [HttpGet("/Res/search")]
    public ActionResult Search()
    {
        List<Cuisine> allFood = Cuisine.GetAll();
        return View(allFood);
    }
    //
    // [HttpGet("/Furballs/date")]
    // public ActionResult DateSort()
    // {
    //     List<Furballs> allCounters = Furballs.GetAll("date_of_admittance");
    //     return View("Index",allCounters);
    // }
    [HttpGet("/Res/new")]
    public ActionResult New()
    {
        List<Cuisine> allFood = Cuisine.GetAll();
        return View(allFood);
    }

    [HttpPost("/Res")]
    public ActionResult Create(string name, string description, string primary, string secondary)
    {
      Res rest = new Res();
      rest.SetName(name);
      rest.SetDescription(description);
      rest.SetPrimaryKey(int.Parse(primary));
      rest.SetSecondaryKey(int.Parse(secondary));
      rest.Save();
      return RedirectToAction("Index");
    }

    [HttpPost("/Res/search")]
    public ActionResult Create(string cuisine)
    {
      List<Res> allFood = Cuisine.GetSome(cuisine);
      return View("Index", allFood);
    }

    // [HttpPost("/Furballs/")]
    // public ActionResult Create(string type, string name, string breed, string sex)
    // {
    //   Furballs newAnimal = new Furballs();
    //   newAnimal.SetType(type);
    //   newAnimal.SetName(name);
    //   newAnimal.SetBreed(breed);
    //   newAnimal.SetSex(sex.ToCharArray()[0]);
    //   Furballs.AddToDB(newAnimal);
    //   return RedirectToAction("Index");

  //  }

    // [HttpPost("/game")]
    // public ActionResult Create(string compare, string to)
    // {
    //     if(Regex.IsMatch(compare, @"^[a-zA-Z]+$") == true)
    //     {
    //       Counter theCounter = new Counter(compare, to);
    //     }
    //     return RedirectToAction("Index");
    // }

  }
}
