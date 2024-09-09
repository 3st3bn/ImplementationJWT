using ImplementationJWT.Models;
using System.Collections.Generic;

namespace ImplementationJWT.Services.Interfaces
{
    public interface IClientService
    {
        List<Client> GetClients();
        List<Client> GetClientByName(string Name);
        List<Client> GetClientByEmail(string Email);
        bool DeleteClientByName(string Name); // Agregado método para eliminar cliente
    }
}
