using MatriculasAPI.Helpers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using BackEnd.Entities;
using Syncfusion.Pdf;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf.Tables;

using Syncfusion.Drawing;
using System.Data;

namespace MatriculasAPI.Controllers
{
    public class PlanDeEstudioController : Controller
    {

     
        // GET: CategoryController
        public ActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/planestudio/");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<Models.PlanEstudioViewModel> planestudio = JsonConvert.DeserializeObject<List<Models.PlanEstudioViewModel>>(content);


                ViewBag.Title = "Planes de Estudio";
                return View(planestudio);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: CategoryController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/planestudio/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.PlanEstudioViewModel planestudioViewModel = response.Content.ReadAsAsync<Models.PlanEstudioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(planestudioViewModel);
        }



        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.PlanEstudioViewModel planestudio, List<IFormFile> upload)
        {
            try
            {
              
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/planestudio", planestudio);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (HttpRequestException
          )
            {
                return RedirectToAction("Error", "Home");
            }

            catch (Exception
            )
            {

                throw;
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/planestudio/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.PlanEstudioViewModel planestudioViewModel = response.Content.ReadAsAsync<Models.PlanEstudioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(planestudioViewModel);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.PlanEstudioViewModel planestudio, List<IFormFile> upload)
        {
         
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/planestudio", planestudio);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {


            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/planestudio/" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.PlanEstudioViewModel planestudioViewModel = response.Content.ReadAsAsync<Models.PlanEstudioViewModel>().Result;
            //ViewBag.Title = "All Products";
            return View(planestudioViewModel);
        }


        [HttpPost]
        public ActionResult Delete(Models.PlanEstudioViewModel planestudio)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/planestudio/" + planestudio.IdPlanEstudio.ToString());
            response.EnsureSuccessStatusCode();
            bool Eliminado = response.Content.ReadAsAsync<bool>().Result;

            if (Eliminado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception();
            }
        }

        public ActionResult Print2Pdf() {

            //Create a new PDF document.

            PdfDocument doc = new PdfDocument();

            //Add a page.

            PdfPage page = doc.Pages.Add();

            // Create a PdfLightTable.

            PdfLightTable pdfLightTable = new PdfLightTable();

            //Add values to list

            List<object> data = new List<object>();

            object row = new { Nombre_Curso = "Id del plan de estudios", Carrera = "Nombre de la Carrera" };


            data.Add(row);
            row = new { Nombre_Curso = "1", Carrera = "Ingeniería en Sistemas" };
            data.Add(row);
            //Add list to IEnumerable

            IEnumerable<object> table = data;

            //Assign data source.

            pdfLightTable.DataSource = table;

            //Draw PdfLightTable.

            pdfLightTable.Draw(page, new Syncfusion.Drawing.PointF(0, 0));

            //Creating the stream object

            MemoryStream stream = new MemoryStream();

            //Save the PDF document to stream.

            doc.Save(stream);

            //If the position is not set to '0' then the PDF will be empty.

            stream.Position = 0;

            //Close the document.

            doc.Close(true);

            //Defining the ContentType for pdf file.

            string contentType = "application/pdf";

            //Define the file name.

            string fileName = "Output.pdf";

            //Creates a FileContentResult object by using the file contents, content type, and file name.

            return File(stream, contentType, fileName);



            return View();
        
        }


    }
}
