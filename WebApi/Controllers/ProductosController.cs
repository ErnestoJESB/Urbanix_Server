﻿using Domain.DTOs.Productos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : Controller
    {
        private readonly IProductosServices _productosServices;
        public ProductosController(IProductosServices productosServices)
        {
            _productosServices = productosServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var response = await _productosServices.GetProductos();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] CrearProductoDTO request)
        {
            var response = await _productosServices.CreateProducto(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, [FromBody] CrearProductoDTO request)
        {
            var response = await _productosServices.UpdateProducto(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var response = await _productosServices.DeleteProducto(id);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductoById(int id)
        {
            var response = await _productosServices.GetProductoById(id);
            return Ok(response);
        }

    }
}
