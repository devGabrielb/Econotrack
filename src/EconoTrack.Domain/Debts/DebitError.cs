using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EconoTrack.Domain.Abstractions;

namespace EconoTrack.Domain.Debts
{
    public static class DebitError
    {
        public static readonly CustomError IsRecurrentError = new(
        "Debt.IsRecurrentError",
        "Debt is recurrent, can't add installments");

        public static readonly CustomError numberOfInstallmentsError = new(
       "Debt.numberOfInstallments",
       "Number of installments must be greater than 0");

    }
}
