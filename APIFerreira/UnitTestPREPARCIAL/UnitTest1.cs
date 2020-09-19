using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using APIFerreira.Controllers;
using APIFerreira.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPREPARCIAL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGet()
        { 
            //Arrange
            FerreirasController controlador = new FerreirasController();
            //Act
            var listaFerreira = controlador.GetFerreiras();

            //Assert
            Assert.IsNotNull(listaFerreira);
        }
        [TestMethod]
        public void TestPost()
        {
            //Arrange
            FerreirasController controlador = new FerreirasController();
            Ferreira prueba = new Ferreira()
            {
                FerreiraID = 5,
                FriendofFerreira = "Luciana",
                place = CategoryType.Cine,
                Email = "lucianaa@gmail.com",
                Birthdate = DateTime.Today
                
            };
            //Act
            var listaFerreira = controlador.PostFerreira(prueba);
            var resultadoCreado = listaFerreira as CreatedAtRouteNegotiatedContentResult<Ferreira>;

            //Assert
            Assert.IsNotNull(resultadoCreado);
            Assert.AreEqual("DefaultApi", resultadoCreado.RouteName);
            Assert.AreEqual(prueba.FerreiraID, resultadoCreado.Content.FerreiraID);
        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            FerreirasController controlador = new FerreirasController();
            Ferreira prueba = new Ferreira()
            {
                FerreiraID = 5,
                FriendofFerreira = "Luciana",
                place = CategoryType.Cine,
                Email = "luciana@gmail.com",
                Birthdate = DateTime.Today
               
            };
            //Act
            var listaFerreira = controlador.PostFerreira(prueba);
            var resultadoEliminado = controlador.DeleteFerreira(prueba.FerreiraID);

            //Assert
            Assert.IsInstanceOfType(resultadoEliminado, typeof(OkNegotiatedContentResult<Ferreira>));
        }

        [TestMethod]
        public void TestPut()
        {
            //Arrange
            FerreirasController controlador = new FerreirasController();
            Ferreira prueba = new Ferreira()
            {
                FerreiraID = 5,
                FriendofFerreira = "Luciana",
                place = CategoryType.Cine,
                Email = "cosa@gmail.com",
                Birthdate = DateTime.Today
                
            };
            //Act
            var listaFerreira = controlador.PostFerreira(prueba);
            prueba.FriendofFerreira = "Luciana";
            var resultadoCreado = controlador.PutFerreira(prueba.FerreiraID, prueba) as StatusCodeResult;

            //Assert
            Assert.IsNotNull(resultadoCreado);
            Assert.AreEqual(HttpStatusCode.NoContent, resultadoCreado.StatusCode);
            Assert.IsInstanceOfType(resultadoCreado, typeof(StatusCodeResult));
        }
    }
   
}
