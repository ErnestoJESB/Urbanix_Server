﻿using Domain.DTOs.Categorias;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : Controller 
    {
        private readonly ICategoriasServices _categoriasServices;
        public CategoriasController(ICategoriasServices categoriasServices)
        {
            _categoriasServices = categoriasServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var response = await _categoriasServices.GetCategorias();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] CrearCategoriasDTO request)
        {
            var response = await _categoriasServices.CreateCategoria(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] CrearCategoriasDTO request)
        {
            var response = await _categoriasServices.UpdateCategoria(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var response = await _categoriasServices.DeleteCategoria(id);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _categoriasServices.GetByID(id);
            return Ok(response);
        }
    }
}
