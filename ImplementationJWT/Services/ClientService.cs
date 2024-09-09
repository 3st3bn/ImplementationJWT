using ImplementationJWT.Models;
using ImplementationJWT.Repositories.Interfaces;
using ImplementationJWT.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ImplementationJWT.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<Client> GetClients()
        {
            return _clientRepository.GetClients();
        }

        public List<Client> GetClientByName(string Name)
        {
            var clients = _clientRepository.GetClients();
            return clients.Where(c => c.Name.ToLower() == Name.ToLower()).ToList();
        }

        public List<Client> GetClientByEmail(string Email)
        {
            var clients = _clientRepository.GetClients();
            return clients.Where(c => c.Email.ToLower() == Email.ToLower()).ToList();
        }

        public bool DeleteClientByName(string Name)
        {
            var clients = _clientRepository.GetClients();
            var client = clients.FirstOrDefault(c => c.Name.ToLower() == Name.ToLower());

            if (client != null)
            {
                clients.Remove(client);
                return true;
            }
            return false;
        }
    }
}
