using Microsoft.AspNetCore.Mvc;
using AdInfoSupplierVehicle.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AdInfoSupplierVehicle.API.DTO;
using AdInfoSupplierVehicle.Domain.Interfaces;
using AdInfoSupplierVehicle.Domain.Models;

namespace AdInfoSupplierVehicle.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleService _vehicleService;
        private readonly IRepository<Vehicle> _vehicleRepository;

        public VehicleController(VehicleService vehicleService,
            IRepository<Vehicle> vehicleRepository)
        {
            _vehicleService = vehicleService;
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Obter todos os usuários.
        /// </summary>
        /// <response code="200">A lista de veículos foi obtida com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao obter a lista de veículos.</response>
        [HttpGet("{id}")]
        public IActionResult GetVehicle(int id)
        {
            var vehicle = _vehicleRepository.GetById(id);
            var vehicleModel = new VehicleGetModel { Id = 0, Marca = "BMW", Modelo = "Quatro portas", Versao = "1.1", Ano = 2019, Quilometragem = 1000, Observacao = "Teste" };
            /*if (vehicle == null)
                return NotFound(new { message = $"Contato de id={id} não encontrado" });*/
            
            return Ok(vehicle);
        }

        [HttpGet("/Listar")]
        [ProducesResponseType(typeof(List<VehicleGetModel>), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetVehicles()
        {
            var veiculos = GetListVehicles();
            return Ok(veiculos);
        }

        private IEnumerable<VehicleGetModel> GetListVehicles()
        {
            throw new Exception("Não foi possível buscar os usuários na base.");

            var vehicles = _vehicleRepository.GetAll();
            var vehiclesModel = vehicles.Select(v => new VehicleGetModel { 
                Id = v.Id, Ano = v.Ano, Marca = v.Marca, Modelo = v.Modelo, 
                Quilometragem = v.Quilometragem, Versao = v.Versao, Observacao = v.Observacao});

            return new List<VehicleGetModel>
            {
                new VehicleGetModel { Id = 0, Marca = "BMW", Modelo = "Quatro portas", Versao = "1.1", Ano = 2019, Quilometragem = 1000, Observacao = "Teste" },
                new VehicleGetModel { Id = 1, Marca = "GOL", Modelo = "Quatro portas", Versao = "1.0", Ano = 2020, Quilometragem = 1001 },
                new VehicleGetModel { Id = 2, Marca = "Mercedes", Modelo = "Quatro portas", Versao = "1.0", Ano = 2017, Quilometragem = 1002 }
            };
        }
    }
}
