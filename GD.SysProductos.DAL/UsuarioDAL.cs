using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GD.SysProductos.DAL
{
    public class UsuarioDAL
    {
        readonly SysProductosDBContext _dbContext;

        public UsuarioDAL(SysProductosDBContext context)
        {
            _dbContext = context;

            string password = "admin123";
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            Console.WriteLine(hashedPassword);

        }
    }
}

