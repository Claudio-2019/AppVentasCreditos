using AppVentas.Backend.Interfaces;
using AppVentas.Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace AppVentas.Backend.Services
{
    class ServiceRegistration : IRegistration
    {
        public void CreateUser(DTOUser newUser)
        {


            using (SqlConnection sqlConnection = new
                SqlConnection(@"Data Source=DESKTOP-E9988JL\SQLEXPRESS;Initial Catalog=GolloVentasDB-test;Integrated Security=True"))
            {
                SqlCommand sqlCommand = new SqlCommand(@"INSERT INTO usuario (cedula, nombre, apellidos, 
                                                            email, telefono, residencia, rolId,contrasena) VALUES 
                                                            (@cedula, @nombre, @apellidos, 
                                                            @email, @telefono, @residencia, @rolId,@contrasena)", sqlConnection);

                sqlCommand.Parameters.AddWithValue("@cedula", newUser.cedula);
                sqlCommand.Parameters.AddWithValue("@nombre", newUser.nombre);
                sqlCommand.Parameters.AddWithValue("@apellidos", newUser.apellidos);
                sqlCommand.Parameters.AddWithValue("@email", newUser.email);
                sqlCommand.Parameters.AddWithValue("@telefono", newUser.telefono);
                sqlCommand.Parameters.AddWithValue("@residencia", newUser.residencia);
                sqlCommand.Parameters.AddWithValue("@rolId", 1);
                sqlCommand.Parameters.AddWithValue("@contrasena", newUser.contraseña);

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                }
            }

            
        }







    }


}

 
