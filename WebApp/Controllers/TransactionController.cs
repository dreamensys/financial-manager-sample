using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApp.Attributes;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        WebTransactionService transactionService = new WebTransactionService();

        
        public ViewResult Index(string sortOrder, string currentFilter, string searchString)
        {
            List<TransactionViewModel> list = GetTransactions();
            bool IsFraud = !String.IsNullOrEmpty(Request.Params["IsFraud"]) && Request.Params["IsFraud"].Contains("true");
            list = list.Where(r => r.IsFraud == IsFraud).ToList();
            if (!String.IsNullOrEmpty(Request.Params["NameDest"]))
            {
                list = list.Where(n => n.NameDest == Request.Params["NameDest"]).ToList();
            }

            return View(list);
        }


        private List<TransactionViewModel> GetTransactions()
        {
            return transactionService.GetTransactions().ToList();
        }
        

        [AuthorizeManager(Roles = RoleTypes.Administrator + "," +  RoleTypes.Assistant)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
        [AuthorizeManager(Roles = RoleTypes.Administrator + "," + RoleTypes.Assistant)]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                TransactionViewModel trn = GetModelData(collection);
                if (transactionService.CreateNewTransaction(trn))
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        [AuthorizeManager(Roles = RoleTypes.Administrator + "," + RoleTypes.Superintendent)]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionViewModel transaction = transactionService.GetTransactionById(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        
        [HttpPost]
        [AuthorizeManager(Roles = RoleTypes.Administrator + "," + RoleTypes.Superintendent)]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                TransactionViewModel trn = GetModelData(collection);
                trn.Id = Convert.ToInt32(collection["Id"]);
                if (transactionService.UpdateTransaction(trn))
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private TransactionViewModel GetModelData(FormCollection collection)
        {
            TransactionViewModel trn = new TransactionViewModel()
            {
                Step = Convert.ToInt32(collection["Step"]),
                Type = collection["Type"],
                Amount = Convert.ToDouble(collection["Amount"]),
                NameOrigin = collection["NameOrigin"],
                OldBalanceOrg = Convert.ToInt32(collection["OldBalanceOrg"]),
                NewBalanceOrg = Convert.ToInt32(collection["NewBalanceOrg"]),
                NameDest = collection["NameDest"],
                OldBalanceDest = Convert.ToInt32(collection["OldBalanceDest"]),
                NewBalanceDest = Convert.ToInt32(collection["NewBalanceDest"]),
                IsFraud = collection["IsFraud"].Contains("true")
            };
            return trn;
        }

      
    }
}
