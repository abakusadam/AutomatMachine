using System;
using System.Collections.Generic;
using System.Text;

namespace Automat.Application.Port.Outgoing.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
