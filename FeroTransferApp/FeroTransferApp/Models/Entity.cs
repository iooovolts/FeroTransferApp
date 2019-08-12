using System;
using System.Collections.Generic;
using System.Text;

namespace FeroTransferApp.Models
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }

    public class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}
