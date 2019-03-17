using RestAPI.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI
{
    public static class DataLayer
    {
        private static string connString = "Data Source=localhost;Persist Security Info=True;User ID=restapi; Password=Rest6040;";
        private static SqlConnection conn;
        private static SqlCommand command;
        private static List<Benuzer> Users;
        private static StringBuilder ErrorMessages = new StringBuilder();

        public static string GetException()
        {
            return ErrorMessages.ToString();
        }


        public static Benuzer GetUser(string Username, string Password)
        {
            Benuzer user = new Benuzer();

            try
            {

                using (conn)
                {
                    string Query = "Select * from Benutzer Where Benutzername=@Username";

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = Query;

                    SqlParameter username = new SqlParameter("@Username", Username);
                    SqlParameter password = new SqlParameter("@Password", Password);


                    command.Parameters.AddRange(new SqlParameter[] { username, password });
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        user.ID = Convert.ToInt16(reader[0]);
                        user.Benutzername = reader[1].ToString();
                        user.Vorname = reader[3].ToString();
                        user.Nachname = reader[4].ToString();
                        user.Telefonnummer = reader[5].ToString();
                        user.Adresse = reader[6].ToString();
                    }

                    command.Connection.Close();
                    return user;

                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Append(ex.Message.ToString());
                return user;
            }


        }


        public static Benuzer GetUser(string Username)
        {
            Benuzer user = new Benuzer();

            try
            {

                using (conn)
                {
                    string Query = "Select * from Benutzer Where Benutzername=@Username And  Kennwort=@Password;";

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = Query;

                    SqlParameter username = new SqlParameter("@Username", Username);


                    command.Parameters.AddRange(new SqlParameter[] { username });
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        user.ID = Convert.ToInt16(reader[0]);
                        user.Benutzername = reader[1].ToString();
                        user.Vorname = reader[3].ToString();
                        user.Nachname = reader[4].ToString();
                        user.Telefonnummer = reader[5].ToString();
                        user.Adresse = reader[6].ToString();
                    }

                    command.Connection.Close();
                    return user;

                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Append(ex.Message.ToString());
                return user;
            }


        }


        public static void UpdateUser(Benuzer user)
        {
            try
            {
                using (conn)
                {
                    string Query = "UPDATE Users SET Vorname=@Vorname, Nachname=@Nachname, Telefonnummer=@Telefonnummer, Adresse=@Adresse WHERE ID=@ID ";

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = Query;


                    SqlParameter Vorname = new SqlParameter("@Vorname", user.Vorname);
                    SqlParameter Nachname = new SqlParameter("@Nachname", user.Nachname);
                    SqlParameter Telefonnummer = new SqlParameter("@Telefonnummer", user.Telefonnummer);
                    SqlParameter Adresse = new SqlParameter("@Adresse", user.Adresse);

                    command.Parameters.AddRange(new SqlParameter[] { Vorname, Nachname, Telefonnummer, Adresse });
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorMessages.Append(ex.Message.ToString());
            }
        }



    }
}
