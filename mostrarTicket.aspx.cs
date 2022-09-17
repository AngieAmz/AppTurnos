using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Timers;

namespace App_Turnos
{
    public partial class mostrarTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["code"] != null && Request.QueryString["desc"] != null)
            {
                lblTurno.Text = Request.QueryString["code"];
                lblDesc.Text = Request.QueryString["desc"];
            }
            else
            {
                Console.WriteLine("Error");
            }

            enviarTurnos(lblTurno.Text, lblDesc.Text);
        }
        
        public static void enviarTurnos(string turn, string desc)
        {
            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection cn = new SqlConnection(conectar);
            string consulta = "INSERT INTO Turnos (turno, descripcion, cajero) values (@turno, @descripcion, @cajero)";
            SqlCommand com = new SqlCommand(consulta, cn);
            com.Connection.Open();
            com.Parameters.Add("@turno", SqlDbType.VarChar, 50).Value = turn;
            com.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = desc;
            com.Parameters.Add("@cajero", SqlDbType.Int).Value = 0;
            com.ExecuteNonQuery();
        }


    }
}