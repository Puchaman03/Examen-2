using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_2
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Obtener el valor de la columna Encuestas de la tabla Usuarios
                    int concursanteNumero = ObtenerNumeroConcursante();

                    // Asignar el valor al Label Concursante
                    Concursante.Text = concursanteNumero.ToString();
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                    Console.WriteLine("Error al obtener el número de concursante: " + ex.Message);
                }
            }
        }
        private int ObtenerNumeroConcursante()
        {
            int concursanteNumero = 0+1;

            // Definir la cadena de conexión a la base de datos
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            // Consulta SQL para obtener el valor de la columna Encuestas
            string query = "SELECT MAX(Encuestas) FROM Usuarios";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Crear el comando SQL
                SqlCommand command = new SqlCommand(query, connection);

                // Abrir la conexión
                connection.Open();

                // Ejecutar la consulta y obtener el valor de la columna Encuestas
                object result = command.ExecuteScalar();

                // Verificar si se obtuvo un valor válido
                if (result != DBNull.Value)
                {
                    concursanteNumero = Convert.ToInt32(result);
                }
            }

            return concursanteNumero;
        }

    }

}