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
    public partial class Encuesta : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aquí puedes agregar cualquier lógica necesaria cuando la página se cargue
        }

        protected void IdEnviar_Click(object sender, EventArgs e)
        {
            // Validar y guardar la encuesta
            GuardarEncuesta();


        }

        private void GuardarEncuesta()
        {
            // Validación de campos
            if (string.IsNullOrEmpty(TNombre.Text) || string.IsNullOrEmpty(Tapellido1.Text) || string.IsNullOrEmpty(Tedad.Text) || string.IsNullOrEmpty(TCedula.Text) || string.IsNullOrEmpty(TCorreo.Text) || Calendar1.SelectedDate == DateTime.MinValue || (!CarroSi.Checked && !CarroNo.Checked) || (!MotoSi.Checked && !MotoNo.Checked) || (!BiciSi.Checked && !BiciNo.Checked))
            {
                // Mensaje de error si algún campo obligatorio está vacío
                Response.Write("<script>alert('Todos los campos son obligatorios');</script>");
                return;
            }
            

                // Validar edad
                int edad;
            if (!int.TryParse(Tedad.Text, out edad) || edad < 18 || edad > 50)
            {
                // Mensaje de error si la edad no está en el rango permitido
                Response.Write("<script>alert('La edad debe estar entre 18 y 50 años');</script>");
                return;
            }

            // Crear una nueva instancia de la clase Encuesta y asignar valores
            Encuesta nuevaEncuesta = new Encuesta();
            nuevaEncuesta.Nombre = TNombre.Text;
            nuevaEncuesta.Apellido1 = Tapellido1.Text;
            nuevaEncuesta.Apellido2 = Tapellido2.Text;
            nuevaEncuesta.FechaNacimiento = Calendar1.SelectedDate;
            nuevaEncuesta.Edad = edad;
            nuevaEncuesta.Genero = TGenero.SelectedValue;
            nuevaEncuesta.Cedula = TCedula.Text;
            nuevaEncuesta.Correo = TCorreo.Text;
            nuevaEncuesta.TieneCarro = CarroSi.Checked;
            nuevaEncuesta.IdentificacionCarro = IdCarro.Text;
            nuevaEncuesta.TieneMoto = MotoSi.Checked;
            nuevaEncuesta.IdentificacionMoto = IdMoto.Text;
            nuevaEncuesta.TieneBici = BiciSi.Checked;
            nuevaEncuesta.IdentificacionBici = IdBici.Text;

            // Guardar la encuesta en la base de datos
            GuardarEnBaseDeDatos(nuevaEncuesta);

            // Mensaje de éxito
            Response.Write("<script>alert('Encuesta guardada exitosamente');</script>");

            // Limpiar campos después de guardar la encuesta
            LimpiarCampos();
        }

        private void GuardarEnBaseDeDatos(Encuesta encuesta)
        {
            // Conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Consulta SQL para insertar la encuesta
                string query = "INSERT INTO Usuarios (Nombre, Apellido#1, Apellido#2, Fecha, Edad, genero, Cedula, Correo) " +
                               "VALUES (@Nombre, @Apellido#1, @Apellido#2, @Fecha, @Edad, @Genero, @Cedula, @Correo)";

                // Comando para ejecutar la consulta SQL
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parámetros
                        command.Parameters.AddWithValue("@Nombre", encuesta.Nombre);
                        command.Parameters.AddWithValue("@Apellido#1", encuesta.Apellido1);
                        command.Parameters.AddWithValue("@Apellido#2", encuesta.Apellido2);
                        command.Parameters.AddWithValue("@Fecha", encuesta.FechaNacimiento);
                        command.Parameters.AddWithValue("@Edad", encuesta.Edad);
                        command.Parameters.AddWithValue("@Genero", encuesta.Genero);
                        command.Parameters.AddWithValue("@Cedula", encuesta.Cedula);
                        command.Parameters.AddWithValue("@Correo", encuesta.Correo);

                        // Parámetros para los vehículos
                        command.Parameters.AddWithValue("@Tiene_Carros",encuesta.TieneCarro ? "si" : "no");
                        command.Parameters.AddWithValue("@TieneMoto", encuesta.TieneMoto ? "si" : "no");
                        command.Parameters.AddWithValue("@TieneBici", encuesta.TieneBici ? "si" : "no");
                        // Abrir conexión y ejecutar el comando
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // Número de error para violación de clave única
                    {
                        // Verificar si la excepción se debe a la columna Cedula
                        if (ex.Message.Contains("Cedula"))
                        {
                            // Mostrar un mensaje de error indicando que la Cedula ya está en uso
                            Response.Write("<script>alert('La cedula ingresada ya está en uso');</script>");
                        }
                        // Verificar si la excepción se debe a la columna Correo
                        else if (ex.Message.Contains("Correo"))
                        {
                            // Mostrar un mensaje de error indicando que el Correo ya está en uso
                            Response.Write("<script>alert('El correo ingresado ya está en uso');</script>");
                        }
                        else
                        {
                            // En caso de que no se pueda determinar la columna específica, mostrar un mensaje de error genérico
                            Response.Write("<script>alert('Error al insertar el registro');</script>");
                        }
                    }
                    else
                    {
                        // Otras excepciones de SqlException no relacionadas con la violación de clave única
                        // Puedes manejarlas según sea necesario
                        Response.Write("<script>alert('Error al insertar el registro');</script>");
                    }
                }
                finally
                {
                    // Asegúrate de cerrar la conexión después de ejecutar la consulta, tanto si hay una excepción como si no
                    connection.Close();
                }
            }
        }

        private void LimpiarCampos()
        {
            // Limpiar todos los campos del formulario
            TNombre.Text = "";
            Tapellido1.Text = "";
            Tapellido2.Text = "";
            Calendar1.SelectedDate = DateTime.Now;
            Tedad.Text = "";
            TGenero.SelectedIndex = 0;
            TCedula.Text = "";
            TCorreo.Text = "";
            CarroSi.Checked = false;
            CarroNo.Checked = false;
            IdCarro.Text = "";
            MotoSi.Checked = false;
            MotoNo.Checked = false;
            IdMoto.Text = "";
            BiciSi.Checked = false;
            BiciNo.Checked = false;
            IdBici.Text = "";
        }
    }
}