using ImplementationJWT.Models;
using System.Collections.Generic;

namespace ImplementationJWT.Repositories.Interfaces
{
    public interface IClientRepository
    {
        List<Client> GetClients(); // Cambiado a método de firma
    }
}
