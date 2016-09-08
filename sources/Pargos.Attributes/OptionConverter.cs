using Pargos.Core;
using System.Collections.Generic;

namespace Pargos.Attributes
{
    public interface OptionConverter
    {
        object Convert(IEnumerable<Argument> arguments);
    }
}