using RestAPI.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI
{
    public class DataLayer
    {
        private string connString = "Data Source=localhost;Persist Security Info=True;User ID=restapi; Password=Rest6040;";
        private SqlConnection conn;
        private SqlCommand command;
        private StringBuilder ErrorMessages = new StringBuilder();

        public string GetException()
        {
            return ErrorMessages.ToString();
        }


        public Benuzer GetUser(string Username, string Password)
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
                    SqlParameter password = new SqlParameter("@Password", Password);


                    command.Parameters.AddRange(new SqlParameter[] { username, password });
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        user.ID = Convert.ToInt16(reader[0]);
                        user.Benutzername = reader[1].ToString();
                        user.Kennwort = "********";
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

        public Benuzer GetUser(string Username)
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


        public void UpdateUser(Benuzer user)
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


        public List<Versicherungspolice> GetPolicies()
        {
            try
            {
                using (conn)
                {
                    List<Versicherungspolice> versicherungspolicen = new List<Versicherungspolice>();

                    conn = new SqlConnection(connString);

                    string sqlSelectString = "SELECT * FROM Versicherungspolice";
                    command = new SqlCommand(sqlSelectString, conn);
                    command.Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Versicherungspolice versicherungspolice = new Versicherungspolice();
                        versicherungspolice.ID = Convert.ToInt16(reader[0]);
                        versicherungspolice.Name = reader[1].ToString();
                        versicherungspolice.Beschreibung = reader[2].ToString();
                        versicherungspolice.Link = reader[3].ToString();
                        versicherungspolicen.Add(versicherungspolice);
                    }
                    command.Connection.Close();
                    return versicherungspolicen;
                }

            }
            catch (Exception ex)
            {
                ErrorMessages.Append(ex.Message.ToString());
                return null;
            }
        }

        public List<Versicherungspolice> GetPolicies(int UserID)
        {
            List<Versicherungspolice> Versicherungspolicen = GetPolicies();
            try
            {
                using (conn)
                {
                    List<Versicherungspolice> Result = new List<Versicherungspolice>();

                    conn = new SqlConnection(connString);

                    string Query = "Select * from Versicherungsvertrag Where Benutzer=@Benutzer";

                    conn = new SqlConnection(connString);

                    command = new SqlCommand();
                    command.Connection = conn;
                    command.Connection.Open();
                    command.CommandText = Query;

                    SqlParameter username = new SqlParameter("@Benutzer", UserID);


                    command.Parameters.AddRange(new SqlParameter[] { username });
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Versicherungsvertrag versicherungsvertrag = new Versicherungsvertrag();
                        versicherungsvertrag.ID = Convert.ToInt16(reader[0]);
                        versicherungsvertrag.Benutzer = Convert.ToInt16(reader[1]);
                        versicherungsvertrag.Versicherungspolice = Convert.ToInt16(reader[2]);

                        Versicherungsvertrag Versicherungspolice = new Versicherungsvertrag();
                        Result.Add(Versicherungspolicen.Where(w => w.ID==versicherungsvertrag.Versicherungspolice).First());
                    }
                    command.Connection.Close();
                    return Result;
                }

            }
            catch (Exception ex)
            {
                ErrorMessages.Append(ex.Message.ToString());
                return null;
            }
        }


    }
}
