using CTP.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTP.API.Services
{
    public interface ICTPInfoRepository
    {
        IEnumerable<Usuario> GetUsuarios();
        
        Usuario GetUsuario(int id);
        
        IEnumerable<Cliente> GetClientes();
        
        Cliente GetCliente(int id);
        
        bool ExisteUsuario(string nombreUsuario);
            
        bool ExisteCorreo(string correo);

        bool ExisteTelefono(string telefono);
        
        bool Save();
    }
}
