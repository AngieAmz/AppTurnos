using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Media;
using System.Threading;

namespace App_Turnos
{
    public partial class Pantalla : System.Web.UI.Page
    {
        DataTable dt;
        string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenarTabla();
                Response.Headers.Add("Refresh", "1");
                filaSeleccionada();
                Valor();
                
            }

        }


        public void llenarTabla()
        {
            cn = new SqlConnection(conectar);
            string consulta = "SELECT * FROM llamar_turno ORDER BY id ASC";
            cmd = new SqlCommand(consulta, cn);
            cmd.Connection.Open();
            dt = new DataTable();
            dr = cmd.ExecuteReader();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID", typeof(int)),
                new DataColumn("TURNO", typeof(string)),
                new DataColumn("CAJA", typeof(string))
            });
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    dt.Rows.Add(
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString()
                        );
                }

            }

            tablaLlamada.DataSource = dt;
            tablaLlamada.DataBind();
            cmd.Connection.Close();
        }

        protected void ocultarID(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
            }

            limpiar();

        }


        public void limpiar()
        {
            int cont = tablaLlamada.Rows.Count;
            if (cont > 5)
            {
                tablaLlamada.SelectedIndex = 0;
                GridViewRow row = tablaLlamada.SelectedRow;
                string id = row.Cells[0].Text;
                string query = "DELETE FROM llamar_turno where id = '" + id + "'";
                cn = new SqlConnection(conectar);
                cmd = new SqlCommand(query, cn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        void filaSeleccionada()
        {
            if(tablaLlamada.Rows.Count != 0)
            {
            tablaLlamada.Rows[tablaLlamada.Rows.Count - 1].BackColor = System.Drawing.Color.DarkGreen;
            tablaLlamada.Rows[tablaLlamada.Rows.Count - 1].ForeColor = System.Drawing.Color.White; 
            }
        }

        void Valor()
        {
            cn = new SqlConnection(conectar);
            string query = "SELECT * FROM llamar_turno where valor= 'true'";
            cmd = new SqlCommand(query, cn);
            cmd.Connection.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
               
                SoundPlayer sound = new SoundPlayer(@"\\DESKTOP-1RLVORE\Release\Sonidos\siguiente.wav");
                sound.LoadAsync();
                sound.Play();

                ValorFalse(); 
            }
            cmd.Connection.Close();
        }

        void ValorFalse()
        {
            cn = new SqlConnection(conectar);
            string query = "UPDATE llamar_turno SET valor='false' where valor='true'";
            cmd = new SqlCommand(query, cn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

    }

}
