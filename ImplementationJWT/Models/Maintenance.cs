using ImplementationJWT.Utilities;

namespace ImplementationJWT.Models
{
    public class Maintenance
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public MaintenanceType Type { get; set; }
        public int Month {  get; set; }

    }
}
