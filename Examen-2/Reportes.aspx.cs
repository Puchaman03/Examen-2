using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_2
{
    public partial class Reportes : Page
    {
        protected int personasConMoto;
        protected int personasSinMoto;

        protected int personasConCarro;
        protected int personasSinCarro;

        protected int personasConBici;
        protected int personasSinBici;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Reemplaza "TuCadenaDeConexión" con tu cadena de conexión
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            // Consulta para contar las personas que tienen carro
            int personasConCarro = ContarPersonasConVehiculo(connectionString, "Tiene_Carros", "si");

            // Consulta para contar las personas que no tienen carro
            int personasSinCarro = ContarPersonasConVehiculo(connectionString, "Tiene_Carros", "no");

            // Consulta para contar las personas que tienen moto
            int personasConMoto = ContarPersonasConVehiculo(connectionString, "Tiene_Motocicletas", "si");

            // Consulta para contar las personas que no tienen moto
            int personasSinMoto = ContarPersonasConVehiculo(connectionString, "Tiene_Motocicletas", "no");

            // Consulta para contar las personas que tienen bicicleta
            int personasConBici = ContarPersonasConVehiculo(connectionString, "Tiene_Bicicletas", "si");

            // Consulta para contar las personas que no tienen bicicleta
            int personasSinBici = ContarPersonasConVehiculo(connectionString, "Tiene_Bicicletas", "no");

            // Mostrar resultados en la página
            Response.Write("Personas con carro: " + personasConCarro + "<br>");
            Response.Write("Personas sin carro: " + personasSinCarro + "<br>");
            Response.Write("Personas con moto: " + personasConMoto + "<br>");
            Response.Write("Personas sin moto: " + personasSinMoto + "<br>");
            Response.Write("Personas con bicicleta: " + personasConBici + "<br>");
            Response.Write("Personas sin bicicleta: " + personasSinBici + "<br>");
        }

        // Método para contar personas según si tienen o no el vehículo especificado
        private int ContarPersonasConVehiculo(string connectionString, string tabla, string tieneVehiculo)
        {
            string query = $"SELECT COUNT(*) FROM {tabla} WHERE Tiene_carro = @TieneVehiculo";

            // Crear una conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Crear un comando SQL con la consulta y la conexión
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agregar parámetro para evitar inyección SQL
                    command.Parameters.AddWithValue("@TieneVehiculo", tieneVehiculo);

                    // Ejecutar la consulta y obtener el resultado
                    int count = (int)command.ExecuteScalar();
                    return count;
                }
            }
        }

    }
}