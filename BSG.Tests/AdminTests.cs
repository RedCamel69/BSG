using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSG.Domain.Abstract;
using Moq;
using BSG.Domain.Entities;
using BSG.WebUI.Controllers;
using System.Collections;
using System.Collections.Generic;
using BSG.WebUI.Models;

namespace BSG.Tests
{
    class AdminTests
    {

        [TestMethod]
        public void Coaches_Can_Paginate()
        {

            //assert
            Assert.IsFalse(true);

        }


        [TestMethod]
        public void Coaches_List_Contains_All_Coaches()
        {

            //assert
            Assert.IsFalse(true);

        }



        [TestMethod]
        public void Index_Contains_All_Coaches()
        {

            //arrange
            Mock<ICoachRepository> mock = new Mock<ICoachRepository>();
            mock.Setup(m => m.Coaches).Returns(new Coach[]
            {
                new Coach() { FirstName = "Coach1" },
                new Coach() { FirstName = "Coach2" },
                new Coach() { FirstName = "Coach3" },
            });

            AdminViewModel vm = new AdminViewModel();
            vm.Coaches = new List<Coach>();
            vm.Coaches = mock.Object.Coaches as List<Coach>;

            AdminController target = new AdminController(mock.Object);


            //action



            //assert
            Assert.IsFalse(false);

        }

    }
}
