using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreERP.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ConversionsController : Controller
    {
        // GET: Conversions
        public ActionResult Index()
        {
            return View();
        }



        // GET: Conversions/Details/5
        [HttpGet("conversion/{data}")]
        public ActionResult ConvertNumberTowords(int data)
        {
            return Ok(Helpers.ConvertNumbertoWords.Convert(data));
        }

        // GET: Conversions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conversions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Conversions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Conversions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Conversions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Conversions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}