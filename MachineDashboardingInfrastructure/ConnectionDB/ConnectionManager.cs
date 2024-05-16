using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MachineDashboardingInfrastructure.ConnectionDB
{
    internal class ConnectionManager
    {
        private static ConnectionManager _instance;
        private MySqlConnection _con;

        private ConnectionManager(String connectionString)
        {
            Con = new MySqlConnection(connectionString);
            Con.Open();
        }

        public MySqlConnection Con { get => _con; set => _con = value; }

        public static ConnectionManager GetInstance(String connectionString)
        {
            if (_instance == null)
            {
                _instance = new ConnectionManager(connectionString);

            }

            return _instance;
        }

        

    }
}
