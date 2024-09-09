using ImplementationJWT.Models;
using ImplementationJWT.Repositories.Interfaces;
using ImplementationJWT.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace ImplementationJWT.Repositories
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        public List<Maintenance> MaintenanceList { get; set; }

        public MaintenanceRepository()
        {
            MaintenanceList = new List<Maintenance>()
            {
                new Maintenance{ Id = Guid.NewGuid(), Name = "Computer Repair", Type = MaintenanceType.repair, Month = 1 },
                new Maintenance{ Id = Guid.NewGuid(), Name = "Air Conditioning Cleaning", Type = MaintenanceType.cleaning, Month = 3 },
                new Maintenance{ Id = Guid.NewGuid(), Name = "Software Update", Type = MaintenanceType.update, Month = 6 }
            };
        }

        public List<Maintenance> GetMaintenanceByName(string name)
        {
            return MaintenanceList.Where(e => e.Name.ToLower() == name.ToLower()).ToList();
        }

        public List<Maintenance> GetMaintenanceByType(MaintenanceType type)
        {
            return MaintenanceList.Where(e => e.Type == type).ToList();
        }

        public List<Maintenance> GetMaintenanceByMonth(int month)
        {
            return MaintenanceList.Where(e => e.Month == month).ToList();
        }

        public bool DeleteMaintenanceByName(string name)
        {
            var maintenance = MaintenanceList.FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
            if (maintenance != null)
            {
                MaintenanceList.Remove(maintenance);
                return true;
            }
            return false;
        }
    }
}
