using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineDashboarding.Istructure;
using MachineDashboardingInfrastructure.ConnectionDB;
using MachineDashboardingInfrastructure.DAOImp;
using MySqlConnector;

namespace MachineDashboardingInfrastructure.DAOImp
{
    public class DAOImpMachine : IDAOMachine
    {

        private MySqlConnection _con;
        private string _connectionString = "server=localhost;port=3306;user=root;database=machine;Uid=root;";

        public DAOImpMachine()
        {
            _con = ConnectionManager.GetInstance(_connectionString).Con;
        }

        float IDAOMachine.getTemperature(int id)
        {
            String query = "select temperature from machine where id = @id and time = (select max(time) from machine where id=@id) ";
            MySqlCommand cmd = new MySqlCommand(query, _con);
            cmd.Parameters.AddWithValue("@id", id);
            
            MySqlDataReader reader = cmd.ExecuteReader();
            float temp = 0;
            if (reader.Read())
            {
                temp = (float) reader["temperature"];
            }
            reader.Close();
            return temp;


        }
    }
}
