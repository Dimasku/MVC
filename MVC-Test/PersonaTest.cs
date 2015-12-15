using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Controllers;
using MVC.Models;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;

namespace MVC_Test

{

    
    [TestClass]
    public class PersonaTest
    {
        PersonContext context = new PersonContext();
        PersonasController PC = new PersonasController();
        [TestMethod]
        public void AddPersonTest()
        {
            Persona Resultado = new Persona();
            int idNuevo = 1;
            Persona Aux = new Persona { Name = "Diego", LastName = "Rodriguez", Mail = "Diego@Rodriguez", Telefono = "094032023" };
            if (context.Personas.FirstOrDefault() != null)
            {
                idNuevo = context.Personas.Max(x => x.id);
                PC.Create(Aux);
                Resultado = context.Personas.Where(c => c.id == idNuevo + 1).FirstOrDefault();
            }
            else {
                PC.Create(Aux);
                Resultado = context.Personas.Where(c => c.id == idNuevo).FirstOrDefault();
            }
          
            
          
            Assert.AreEqual<int>(Resultado.id, Aux.id);
            Assert.AreEqual<string>(Resultado.Name, Aux.Name);
            Assert.AreEqual<string>(Resultado.LastName, Aux.LastName);
       

        }
    

    [TestMethod]
    public void PersonaEditTest()
    {
            Persona Aux = context.Personas.Find(3);
            Aux.Name = "Mauricio";
            PC.Edit(Aux);
            Persona Resultado = context.Personas.Find(3);
            Assert.AreEqual<int>(Aux.id, Resultado.id);
            Assert.AreEqual<string>(Aux.Name, Resultado.Name);
            Assert.AreEqual<string>(Aux.LastName, Resultado.LastName);
    }
        [TestMethod]//[ExpectedException(typeof(NullReferenceException))]
        public void PersonaDeleteTest()
        {
            if(context.Personas.Find(1) != null)
            {
                PC.DeleteConfirmed(1);
            }

            Assert.AreEqual<Object>(context.Personas.Find(1), null);
        }
        
       
    }
}
