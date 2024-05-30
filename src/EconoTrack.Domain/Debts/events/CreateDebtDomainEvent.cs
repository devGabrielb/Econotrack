using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EconoTrack.Domain.Abstractions;

namespace EconoTrack.Domain.Debts.events
{
    public sealed record CreateDebtDomainEvent(Guid DebitId) : IDomainEvent;

}
