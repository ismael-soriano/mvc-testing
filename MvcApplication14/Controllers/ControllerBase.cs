using Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication14.Controllers
{
    public class ControllerBase : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        public ControllerBase(IUnitOfWork unitOfWork)
        {
            if (null == unitOfWork)
            {
                throw new ArgumentNullException("repository");

            }
            _unitOfWork = unitOfWork;
        }
        protected int Save()
        {
            return _unitOfWork.SaveChanges();
        }
        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}