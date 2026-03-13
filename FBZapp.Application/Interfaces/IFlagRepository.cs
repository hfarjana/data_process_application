using System.Collections.Generic;
using FBZapp.Domain.Entities;

namespace FBZapp.Application.Interfaces
{
    public interface IFlagRepository
    {
        void AddFlag(FlaggedRecord record);
        List<FlaggedRecord> GetAllFlags();
    }
}
