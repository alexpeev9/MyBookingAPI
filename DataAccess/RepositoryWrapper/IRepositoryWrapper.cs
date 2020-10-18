using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.RepositoryWrapper
{
    public interface IRepositoryWrapper
    {
        ILocationRepository Location { get; }
        void Save();
    }
}
