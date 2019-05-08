using Microsoft.VisualStudio.TestTools.UnitTesting;
using Food.Models;
using System.Collections.Generic;
using System;

namespace Food.Tests
{
  [TestClass]
  public class CuisineTest : IDisposable
  {

    public void Dispose()
    {
      Item.ClearAll();
    }

    public ItemTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=food_test;";
    }

  }
}
