using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathTaskClassLibrary;

namespace MathTaskClassLibraryTests
{
    [TestClass]
    public class  GeometryTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a= 3;
            int b= 5;
            int expected = 15;

             Geometry geometry = new Geometry();    
            int actual=geometry.CalculateArea(a,b);
            Assert.AreEqual(expected, actual);
        }
    }
}
