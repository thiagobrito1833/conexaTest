using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Conexa.Domain.Tests
{
  public  class TesteBasico
    {

        [Xunit.Fact]
        public  void TestBasico()
        {
            //Arrange

            var TemperaturaFesta = 31;
           
            //Act
            var actFesta = 31;
           
            //Assert

            Assert.Equals(actFesta, TemperaturaFesta);
        }

    }
}
