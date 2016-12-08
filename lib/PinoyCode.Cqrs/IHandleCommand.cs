using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PinoyCode.Cqrs
{
    public interface IHandleCommand<TCommand> 
    {
        IEnumerable Handle(TCommand c);
    }
}
