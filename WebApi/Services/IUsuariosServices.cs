﻿using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Services
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> GetUsuarios();

        public Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request);

        public Task<Response<UsuariosResponse>> ActualizarUsuario(int id, UsuariosResponse request);

        public Task<Response<bool>> EliminarUsuario(int id);

        public Task<Response<Usuario>> GetByID(int id);
        public Task<Response<string>> LoginUser(LoginUser request);
    }
}
