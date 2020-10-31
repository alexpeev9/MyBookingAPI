using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        ILocationRepository Location { get; }
        Task SaveAsync();
        void Save();
    }
}
