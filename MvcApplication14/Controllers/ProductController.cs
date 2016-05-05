using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication14.Models;
using Infraestructura;
using Domain.Products;

namespace MvcApplication14.Controllers
{
   
    public class ProductController : ControllerBase
    {

        readonly IRepositoryProduct _repository;
       
        public ProductController(IRepositoryProduct repository,IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            if(null==repository)
            {
                throw new ArgumentNullException("repository");
            }
         
            _repository = repository;
            
        }
       

        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View(_repository.GetAll().ToList());
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = _repository.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(product);
                Save();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = _repository.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(product);
                Save();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = _repository.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = _repository.Get(id);
            _repository.Delete(product);
            Save();
            return RedirectToAction("Index");
        }

       
    }
}