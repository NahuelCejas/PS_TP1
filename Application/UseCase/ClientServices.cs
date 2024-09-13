using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class ClientServices : IClientServices
    {
        private readonly IClientCommand _clientCommand;
        private readonly IClientQuery _clientQuery;        
        private readonly IValidatorHandler<ClientsRequest> _clientValidator;

        public ClientServices(IClientQuery query, IClientCommand command, IValidatorHandler<ClientsRequest> clientValidator)
        {
            _clientQuery = query;
            _clientCommand = command;            
            _clientValidator = clientValidator;
        }

        public async Task<Clients> CreateClient(ClientsRequest request)
        {          
                await _clientValidator.Validate(request);

                var client = new Client
                {
                    Name = request.Name,
                    Email = request.Email,
                    Company = request.Company,
                    Phone = request.Phone,
                    Address = request.Address,
                    CreateDate = DateTime.Now
                };

                await _clientCommand.InsertClient(client);

                return new Clients
                {
                    Id = client.ClientID,
                    Name = client.Name,
                    Email = client.Email,
                    Company = client.Company,
                    Phone = client.Phone,
                    Address = client.Address
                };           
           
        }

        public async Task<List<Clients>> GetAll()
        {
            var clients =  await _clientQuery.GetListClients();

            var result = clients.Select(x => new Clients
            {
                Id = x.ClientID,
                Name = x.Name,
                Email = x.Email,
                Company = x.Company,
                Phone = x.Phone,
                Address = x.Address

            }).ToList();

            return result;
        }
    }
}
