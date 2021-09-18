using System;
using System.Collections.Generic;
using System.Text;

namespace MS.CQRS.Demo.Domain.Interface
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
