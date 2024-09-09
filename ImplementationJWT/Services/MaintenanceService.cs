using ImplementationJWT.Models;
using ImplementationJWT.Repositories.Interfaces;
using ImplementationJWT.Services.Interfaces;
using ImplementationJWT.Utilities;
using System.Collections.Generic;


namespace ImplementationJWT.Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IMaintenanceRepository _maintenanceRepository;

        public MaintenanceService(IMaintenanceRepository maintenanceRepository)
        {
            _maintenanceRepository = maintenanceRepository;
        }

        public List<Maintenance> GetMaintenanceByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return new List<Maintenance>();
            }
            return _maintenanceRepository.GetMaintenanceByName(name);
        }

        public List<Maintenance> GetMaintenanceByType(MaintenanceType type)
        {
            return _maintenanceRepository.GetMaintenanceByType(type);
        }

        public List<Maintenance> GetMaintenanceByMonth(int month)
        {
            if (month < 1 || month > 12)
            {
                return new List<Maintenance>();
            }
            return _maintenanceRepository.GetMaintenanceByMonth(month);
        }

        public bool DeleteMaintenanceByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            return _maintenanceRepository.DeleteMaintenanceByName(name);
        }
    }
}
