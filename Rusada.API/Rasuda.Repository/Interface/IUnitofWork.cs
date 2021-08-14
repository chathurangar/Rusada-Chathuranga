using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Repository.Interface
{
    public interface IUnitofWork
    {
        ISightRepository SightRepository { get; }
        Task<bool> Complete();
    }
}
