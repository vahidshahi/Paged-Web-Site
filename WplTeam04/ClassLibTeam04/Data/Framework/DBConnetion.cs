using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibTeam04.Entities;
using ClassLibTeam04.Settings;
namespace ClassLibTeam04.Data.Framework
{
    public class DBConnetion
    {
        

    //    private string tableName = "KlantenInfo";
    //    SqlConnection conn = new SqlConnection(Settings.Settings.Database.PagedDataConnString);
    //    SqlCommand cmd = null;
    //    //SqlDataAdapter adapter = null;
    //    DataTable dt = new DataTable();
        
    //    public string MaakAccount(Klant klant)
    //    {
    //        StringBuilder insertQuery = new StringBuilder();
    //        conn.Open();
    //        insertQuery.Append($"Insert INTO {tableName} ");
    //        insertQuery.Append($"(Voornaam, Achternaam, Emailadres, wachtwoord) VALUES ");
    //        insertQuery.Append($"(@Voornaam, @Achternaam, @Emailadres, @Wachtwoord);");
    //        cmd = new SqlCommand(insertQuery.ToString(), conn);
    //        cmd.Parameters.Add("@Voornaam", SqlDbType.VarChar).Value = klant.Voornaam;
    //        cmd.Parameters.Add("@Achternaam", SqlDbType.VarChar).Value = klant.Achternaam;
    //        cmd.Parameters.Add("@Emailadres", SqlDbType.VarChar).Value = klant.Emailadres;
    //        cmd.Parameters.Add("@Wachtwoord", SqlDbType.VarChar).Value = klant.Wachtwoord;

    //        int i = cmd.ExecuteNonQuery();
    //        if (i > 0)
    //            return "Je account is aangemaakt";
    //        else
    //            return "Je account is niet aangemaakt. Probeer opnieuw";
            
            
       // }
    }
}
