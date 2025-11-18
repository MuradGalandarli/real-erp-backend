
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealERP.Application.Abstraction.Service;
using RealERP.Application.Configurations;
using RealERP.Application.Repositories.Endpoint;
using RealERP.Application.Repositories.Menu;
using RealERP.Domain.Entities;
using RealERP.Domain.Entities.Identity;
using System.Runtime.CompilerServices;

namespace RealERP.Persistence.Service
{
    public class AuthorizationEndpointService : IAuthorizationEndpointService
    {
        private readonly IApplicationService _applicationService;
        private readonly IReadEndpointRepository _readEndpointRepository;
        private readonly IReadMenuRepository _readMenuRepository;
        private readonly IWriteMenuRepository _writeMenuRepository;
        private readonly IWriteEndpointRepository _writeEndpointRepository;
        private readonly RoleManager<AppRole> _roleManager;

        public AuthorizationEndpointService(IReadEndpointRepository readEndpointRepository, IWriteMenuRepository writeMenuRepository, IApplicationService applicationService, IReadMenuRepository readMenuRepository, IWriteEndpointRepository writeEndpointRepository, RoleManager<AppRole> roleManager)
        {
            _readEndpointRepository = readEndpointRepository;
            _writeMenuRepository = writeMenuRepository;
            _applicationService = applicationService;
            _readMenuRepository = readMenuRepository;
            _writeEndpointRepository = writeEndpointRepository;
            _roleManager = roleManager;
        }



        public async Task AssignRoleEndpointAsync(string[] roles, string menu, string code, Type type)
        {
          Menu _menu = await _readMenuRepository.GetSingleAsync(m => m.Name == menu);
            if (_menu == null)
            {
               await _writeMenuRepository.AddAsync(new()
                {
                   Name = menu,
                });
            await _writeMenuRepository.SaveAsync();
            }

          Endpoint? endpoint = await _readEndpointRepository.Table.Include(e=>e.Menu).
                FirstOrDefaultAsync(x => x.Code == code && x.Menu.Name == menu);
            if(endpoint == null)
            {
              var action = _applicationService.GetAuthorizeDefinitionEndpoint(type)
                    .FirstOrDefault(x=>x.Name == menu)?.Actions.FirstOrDefault(e=>e.Code == code);
                endpoint = new()
                {
                    Code = code,
                    ActionType = action.ActionType,
                    Definition = action.Definition,
                    HttpType = action.HttpType,
                };
                await _writeEndpointRepository.AddAsync(endpoint);
                await _writeEndpointRepository.SaveAsync();
            }

            var appRoles = _roleManager.Roles.Where(r => roles.Contains(r.Name));

            foreach (var role in appRoles) {
                endpoint.Roles.Add(role);
            }
            await _writeEndpointRepository.SaveAsync(); 
        }
    }
}
