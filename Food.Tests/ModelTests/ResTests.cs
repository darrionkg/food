using Microsoft.VisualStudio.TestTools.UnitTesting;
using Food.Models;
using System.Collections.Generic;
using System;

namespace Food.Tests
{
    [TestClass]
    public class ResTest : IDisposable
    {

      public void Dispose()
      {
          Category.ClearAll();
      }

      // [TestMethod]
      // public void GetAll_SetsKeys_List()
      // {
      //   List<Res> testList = new List<Res> {};
      //
      //   testList = Res.GetAll();
      //
      //   Assert.AreEqual(testList, )
      // }
    }
}
