using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;


namespace App_Turnos
{
    public partial class admin : System.Web.UI.Page
    {
        string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataShow();
            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(conectar);
            string query = "Insert into tipo_ticket (codigo,descripcion)values('"+txtAbreviatura.Text.ToString()+"','"+txtTipoticket.Text.ToString()+"')";
            cmd = new SqlCommand(query, cn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            DataShow();
            cmd.Connection.Close();
        }

        public void DataShow()
        {
            cn = new SqlConnection(conectar);
            string consulta = "SELECT * FROM tipo_ticket";
            cmd = new SqlCommand(consulta, cn);
            cmd.Connection.Open();
            DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("CODIGO", typeof(string)),
                new DataColumn("DESCRIPCION", typeof(string))
            });
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    dt.Rows.Add(
                        dr[1].ToString(),
                        dr[2].ToString()
                        );
                }

            }

            tablaTickets.DataSource = dt;
            tablaTickets.DataBind();
            cmd.Connection.Close();

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            
            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection cn = new SqlConnection(conectar);
            string query = "DELETE FROM tipo_ticket where codigo='" + txtAbreviatura.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            DataShow();
            cmd.Connection.Close();
        }

        
    }
}