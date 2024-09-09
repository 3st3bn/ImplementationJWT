using ImplementationJWT.Models;
using ImplementationJWT.Repositories.Interfaces;
using System.Collections.Generic;

namespace ImplementationJWT.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public List<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    Id = "1",
                    Email = "google@gmail.com",
                    Age = "19",
                    Name = "Bernardo Peña"
                },
                new Client
                {
                    Id = "2",
                    Email = "miguelgoogle@gmail.com",
                    Age = "23",
                    Name = "Miguel Mantilla"
                }
            };
        }
    }
}
