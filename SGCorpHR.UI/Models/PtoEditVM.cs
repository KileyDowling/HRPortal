using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorpHR.BLL;
using SGCorpHR.Models;

namespace SGCorpHR.UI.Models
{
    public class PtoEditVM
    {
        public PaidTimeOff PtoRequestToEdit { get; set; }
        public string FullName { get; set; }
        public List<SelectListItem> Managers { get; set; }

        public void GenerateManagersList(List<Managers> managers)
        {
             Managers = new List<SelectListItem>();

            foreach (var m in managers)
            {
                Managers.Add(new SelectListItem() { Text = m.ManagerName , Value = m.EmpId.ToString() });
            }
        }

        public void GetSingleRequest(int ptoId)
        {
            var ops = OperationsFactory.CreatePaidTimeOffOperations();
            var ptoList = ops.ViewAllPtoRequests();
            var selectedPto = ptoList.Data.FirstOrDefault(p => p.PtoRequestID == ptoId);
            PtoRequestToEdit = selectedPto;


        }
    }
}