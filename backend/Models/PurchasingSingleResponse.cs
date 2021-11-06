using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class PurchasingSingleResponse
    {
        public string ManagerCode { get; set; };
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierBankAccount { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierTaxCode { get; set; }
        public virtual ICollection<SupplierPhoneNumber> SupplierPhoneNumbers { get; set; }
    }
}
