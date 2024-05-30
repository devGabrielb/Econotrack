using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EconoTrack.Domain.Abstractions;

namespace EconoTrack.Domain.Installments
{
    public class Installment : Entity
    {
        protected Installment() { }
        public Installment(Guid debitId, decimal installmentPrice, DateTime dueDate, bool isPaid = false)
        {
            DebitId = debitId;
            InstallmentPrice = installmentPrice;
            DueDate = dueDate;
            IsPaid = isPaid;
        }
        public Guid DebitId { get; private set; }
        public decimal InstallmentPrice { get; private set; }
        public DateTime DueDate { get; private set; }
        public bool IsPaid { get; private set; }

        public void MarkAsPaid()
        {
            IsPaid = true;
        }
    }
}
