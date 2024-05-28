using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EconoTrack.Domain.Abstractions
{
    public record CustomError(string Code, string Name)
    {
        public static readonly CustomError None = new(string.Empty, string.Empty);

        public static readonly CustomError NullValue = new("Error.NullValue", "Null value was provided");
    }
}
