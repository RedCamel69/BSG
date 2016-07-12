using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BSG.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //BSG.Domain.Concrete.EFDbContext c = new BSG.Domain.Concrete.EFDbContext();

            BSG.Domain.Concrete.EFStudentRepository rep = new Domain.Concrete.EFStudentRepository();

            var s = rep.Students;

            //var first = s.Find(sId == "2eaf2db4-5a35-45ad-b787-3ba2bd748591");
        }
    }
}
