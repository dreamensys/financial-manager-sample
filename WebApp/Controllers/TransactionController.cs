using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class TransactionController : Controller
    {
        WebTransactionService transactionService = new WebTransactionService();

        // GET: Transaction
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

        // GET: Transaction/Details/5
        public ActionResult Details(int id)
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

        // GET: Transaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
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

        // GET: Transaction/Edit/5
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

        // POST: Transaction/Edit/5
        [HttpPost]
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

        // GET: Transaction/Delete/5
        public ActionResult Delete(int id)
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

        // POST: Transaction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if(transactionService.DeleteTransaction(id))
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
    }
}
