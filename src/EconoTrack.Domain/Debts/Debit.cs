using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using EconoTrack.Domain.Abstractions;
using EconoTrack.Domain.Debts.events;
using EconoTrack.Domain.Installments;

namespace EconoTrack.Domain.Debts
{
    public class Debit : Entity
    {
        private const int MIN_INSTALLMENTS = 1;
        private const int MONTH_INCREMENT = 1;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        protected Debit() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public Debit(string title, string description, Guid categoryId, Guid? id = null) : base(id ?? Guid.NewGuid())
        {
            Title = title;
            Description = description;
            CategoryId = categoryId;
            FrequencyRecurrence = FrequencyRecurrence.Once;
        }


        public string Title { get; private set; }
        public string Description { get; private set; }
        public Guid CategoryId { get; private set; }
        public bool IsRecurrent { get; private set; }
        public FrequencyRecurrence FrequencyRecurrence { get; private set; }
        public ICollection<Installment> Installments { get; private set; } = [];
        public int NumberOfInstallments => Installments.Count;
        public decimal TotalPrice { get; private set; }

        public void ComputedTotalPrice()
        {

            TotalPrice = Installments.Sum(i => i.InstallmentPrice);
        }

        public Result AddInstallments(int numberOfInstallments, Installment installment)
        {
            if (numberOfInstallments < 1)
            {

                Result.Failure(DebitError.numberOfInstallmentsError);
            }
            if (installment is null)
            {
                return Result.Failure(CustomError.NullValue);
            }

            if (IsRecurrent)
            {
                return Result.Failure(DebitError.IsRecurrentError);
            }

            var installments = new List<Installment>();

            for (int i = 0; i < numberOfInstallments - MIN_INSTALLMENTS; i++)
            {
                installments.Add(new Installment(Id, installment.InstallmentPrice, installment.DueDate.AddMonths(i + MONTH_INCREMENT)));
            }

            ComputedTotalPrice();
            RaiseDomainEvent(new CreateDebtDomainEvent(Id));

            return Result.Success();
        }

        public void MarkAsRecurrent(FrequencyRecurrence frequencyRecurrence)
        {
            IsRecurrent = true;
            FrequencyRecurrence = frequencyRecurrence;
        }

    }

}
