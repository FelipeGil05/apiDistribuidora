﻿using Application.Interfaces;
using Application.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController (IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole == "SysAdmin" || userRole == "Admin")
            {
                return Ok(_clientService.GetClients());
            }
            return Ok("Rol de usuario no calificado");
        }
        [HttpGet("[action]/{id}")]
        public IActionResult GetById(int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole == "SysAdmin")
            {
                return Ok(_clientService.GetClientById(id));
            }
            return Ok("Rol de usuario no calificado");
        }
        [HttpGet("[action]")]
        public IActionResult GetClient(string email, string password)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole == "SysAdmin")
            {
                return Ok(_clientService.GetClient(email, password));
            }
            return Ok("Rol de usuario no calificado");
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult AddClient([FromBody] ClientDto clientDto)
        {
            return Ok(_clientService.AddClient(clientDto));
        }
        [HttpPut("[action]/{id}")]
        public IActionResult UpdateClient(int id, [FromBody] ClientDto clientDto)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole == "SysAdmin")
            {
                _clientService.UpdateClient(id, clientDto);
                return Ok("Cliente actualizado");
            }
            return Ok("Rol de usuario no calificado");
        }
        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteClient(int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole == "SysAdmin")
            {
                _clientService.DeleteClient(id);
                return Ok("Cliente eliminado con exito");
            }
            return Ok("Rol de usuario no calificado");
        }
    }
}
