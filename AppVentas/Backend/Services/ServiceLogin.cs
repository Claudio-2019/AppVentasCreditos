using AppVentas.Backend.Interfaces;
using AppVentas.Backend.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AppVentas.Backend.Services
{
    class ServiceLogin : ILogin
    {
        private readonly ArrayList CurrentUsers = new ArrayList();
        private List<string> RoleActual = new List<string>();
        private DTOUser DBUsers;

        public string authentication(DTOUser credentials)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-E9988JL\SQLEXPRESS;Initial Catalog=GolloVentasDB-test;Integrated Security=True"))
            {
                SqlCommand sqlCommand = new SqlCommand(@"SELECT cedula, nombre, apellidos, email, telefono, residencia, rolid, contrasena 
                FROM ususario Where email = @email and contrasena = @contrasena ", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@email", credentials.email);
                sqlCommand.Parameters.AddWithValue("@contrasena", credentials.contrasena);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    //credentials.cedula = sqlDataReader.GetString(0);
                    //credentials.nombre = sqlDataReader.GetString(1);
                    //credentials.apellidos = sqlDataReader.GetString(2);
                    //credentials.email = sqlDataReader.GetString(3);
                    //credentials.telefono = sqlDataReader.GetString(4);
                    //credentials.residencia = sqlDataReader.GetString(5);
                    //credentials.rolId = sqlDataReader.GetInt32(6);
                    //credentials.contraseña = sqlDataReader.GetString(7);

                    DBUsers = new DTOUser
                    {
                        cedula = sqlDataReader.GetString(0),
                        nombre = sqlDataReader.GetString(1),
                        apellidos = sqlDataReader.GetString(2),
                        email = sqlDataReader.GetString(3),
                        telefono = sqlDataReader.GetString(4),
                        residencia = sqlDataReader.GetString(5),
                        rolId = sqlDataReader.GetInt32(6),
                        contrasena = sqlDataReader.GetString(7)
                    };
                    CurrentUsers.Add(DBUsers);
                }

                if (CurrentUsers.Contains(credentials.email)&&CurrentUsers.Contains(credentials.contrasena))
                {
                    if (CurrentUsers.Contains(1))
                    {
                        RoleActual.Add("Admin");
                        return RoleActual[0];
                    }
                    else if (CurrentUsers.Contains(2))
                    {
                        RoleActual.Add("Cliente");
                        return RoleActual[0];
                    }
                }
                else
                {
                    return "Usuario no encontrado!";
                }
                return "";
                sqlConnection.Close();
            }
        }
    }
}