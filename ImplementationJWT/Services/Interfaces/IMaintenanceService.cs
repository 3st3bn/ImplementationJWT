using ImplementationJWT.Models;
using ImplementationJWT.Utilities;
using System.Collections.Generic;

namespace ImplementationJWT.Services.Interfaces
{
    public interface IMaintenanceService
    {
        List<Maintenance> GetMaintenanceByName(string name);
        List<Maintenance> GetMaintenanceByType(MaintenanceType type);
        List<Maintenance> GetMaintenanceByMonth(int month);
        bool DeleteMaintenanceByName(string name);
    }
}
