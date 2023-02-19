using APIEventos.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIEventos.Infra.Data.Repository
{
    public class CityEventRepository : ICityEventRepository
    {
        private string _stringConnection;
        public CityEventRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }
    }
}
