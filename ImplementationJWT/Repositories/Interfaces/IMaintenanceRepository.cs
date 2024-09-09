using ImplementationJWT.Models;
using ImplementationJWT.Utilities;
using System.Collections.Generic;

namespace ImplementationJWT.Repositories.Interfaces
{
    public interface IMaintenanceRepository
    {
        List<Maintenance> GetMaintenanceByName(string name);
        List<Maintenance> GetMaintenanceByType(MaintenanceType type);
        List<Maintenance> GetMaintenanceByMonth(int month);
        bool DeleteMaintenanceByName(string name);
    }
}
