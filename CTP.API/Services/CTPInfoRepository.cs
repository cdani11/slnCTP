using CTP.API.Contexts;
using CTP.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTP.API.Services
{
    public class CTPInfoRepository : ICTPInfoRepository
    {
        private readonly CTPInfoContext _context;

        public CTPInfoRepository(CTPInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool ExisteCorreo(string correo)
        {
            return _context.Usuarios.Any(u => u.Correo == correo);
        }

        public bool ExisteTelefono(string telefono)
        {
            return _context.Clientes.Any(c => c.Telefono == telefono);
        }

        public bool ExisteUsuario(string nombreUsuario)
        {
            return _context.Usuarios.Any(u => u.NombreUsuario == nombreUsuario);
        }

        public Cliente GetCliente(int id)
        {
            return _context.Clientes.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes.OrderBy(c => c.Nombre).ToList();
        }

        public Usuario GetUsuario(int id)
        {
            return _context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _context.Usuarios.OrderBy(u => u.Nombre).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
