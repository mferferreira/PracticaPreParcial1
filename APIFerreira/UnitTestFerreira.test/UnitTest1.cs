﻿using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using APIFerreira.Controllers;
using APIFerreira.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFerreira.test
{
    [TestClass]
    public class UnitTest1
    {
        //Get
        [TestMethod]
        public void TestMethodGet()
        {
            //Arrange
            FerreirasController controller = new FerreirasController();


            //Act
            var listaFerreira = controller.GetFerreiras();

            //Assert
            Assert.IsNotNull(listaFerreira);
        }

        //Post
        [TestMethod]
        public void TestMethodPost()
        {
            //Arrange
            FerreirasController controller = new FerreirasController();
            Ferreira esperado = new Ferreira()
            {
                FerreiraID = 1,
                FriendofFerreira = "Luciana",
                place = CategoryType.Cine,
                Email = "lucianaag@hotmail.com",
                Birthdate = DateTime.Today

            };


            //Act
            IHttpActionResult actionResult = controller.PostFerreira(esperado);
            var resultadoCreado = actionResult as CreatedAtRouteNegotiatedContentResult<Ferreira>;

            //Assert
            Assert.IsNotNull(resultadoCreado);
            Assert.AreEqual("DefaultApi", resultadoCreado.RouteName);
            Assert.AreEqual(esperado.FriendofFerreira, resultadoCreado.Content.FriendofFerreira);
        }


        //Delete
        [TestMethod]
        public void TestMethodDelete()
        {
            //Arrange
            FerreirasController controller = new FerreirasController();
            Ferreira esperado = new Ferreira()
            {
                FerreiraID = 1,
                FriendofFerreira = "Luciana",
                place = CategoryType.Cine, 
                Email = "Lucianaa@hotmail.com",
                Birthdate = DateTime.Today

            };


            //Act
            var ListaFerreira = controller.PostFerreira(esperado);
            var resultadoEliminado = controller.DeleteFerreira(esperado.FerreiraID);

            //Assert
            Assert.IsInstanceOfType(resultadoEliminado, typeof(OkNegotiatedContentResult<Ferreira>));

        }


        //Put
        [TestMethod]
        public void TestMethodPut()
        {
            //Arrange
            FerreirasController controlador = new FerreirasController();
            Ferreira prueba = new Ferreira()
            {
                FerreiraID = 1,
                FriendofFerreira = "Luciana",
                place = CategoryType.Cine,
                Email = "lucianaa@hotmail.com",
                Birthdate = DateTime.Today
            };
            //Act
            var ListaFerreira = controlador.PostFerreira(prueba);
            prueba.FriendofFerreira = "Marcela";
            var resultadoCreado = controlador.PutFerreira(prueba.FerreiraID, prueba) as StatusCodeResult;

            //Assert
            Assert.IsNotNull(resultadoCreado);
            Assert.AreEqual(HttpStatusCode.NoContent, resultadoCreado.StatusCode);
            Assert.IsInstanceOfType(resultadoCreado, typeof(StatusCodeResult));
        }


    }
}
