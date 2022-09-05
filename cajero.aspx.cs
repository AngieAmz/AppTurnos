using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Media;
using System.Web.UI;

namespace App_Turnos
{
    public partial class cajero : System.Web.UI.Page
    {
        string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataReader dr;
        SqlDataAdapter sda = new SqlDataAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tablaTurnos.DataSource = DataShow();
                tablaTurnos.DataBind();
                cmd.Connection.Close();
                Select();

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('Numero de caja sin especificar.')", true);
                

            }

        }

        public void Select()
        {
            cn = new SqlConnection(conectar);
            string consulta = "SELECT * FROM tipo_ticket";
            cmd = new SqlCommand(consulta, cn);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int cont = 1;

            while (dr.Read())
            {

                ListItem it;
                it = new ListItem(dr[2].ToString(), cont.ToString());
                slcTurno.Items.Add(it);
                cont++;
            }

        }

        public string DataShow()
        {
            cn = new SqlConnection(conectar);
            string consulta = "SELECT * FROM Turnos";
            cmd = new SqlCommand(consulta, cn);
            cmd.Connection.Open();
            dt = new DataTable();
            dr = cmd.ExecuteReader();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Turno", typeof(string)),
                new DataColumn("Descripcion", typeof(string))
            });
            if (dr.HasRows)
            {
                while (dr.Read()) {

                    dt.Rows.Add(
                        dr[1].ToString(),
                        dr[2].ToString()
                        );
                }

            }

            DataView dv = new DataView(dt);
            return dt.ToString();

        }

        protected void slcTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consulta;
            cn = new SqlConnection(conectar);
            consulta = "SELECT * FROM Turnos where descripcion = '" + slcTurno.SelectedItem.Text + "'";
            cmd = new SqlCommand(consulta, cn);
            cmd.Connection.Open();
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            tablaTurnos.DataSource = dt;
            tablaTurnos.DataBind();
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
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            slcTurno_SelectedIndexChanged(sender, e);
        }


        public void btnSiguiente_Click(object sender, EventArgs e)
        {

                tablaTurnos.SelectedIndex = 0;
                GridViewRow row = tablaTurnos.SelectedRow;
                string turno = row.Cells[1].Text;
                cn = new SqlConnection(conectar);
                string consulta = "insert into llamar_turno (turno, caja) values (@turno, @caja)";
                cmd = new SqlCommand(consulta, cn);
                cmd.Connection.Open();
                cmd.Parameters.Add("@turno", SqlDbType.VarChar, 50).Value = turno;
                cmd.Parameters.Add("@caja", SqlDbType.Int).Value = Application["pc"];
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                slcTurno_SelectedIndexChanged(sender, e);


            SoundPlayer sound = new SoundPlayer(@"C:\Users\ADMINISTRACION\source\repos\App_Turnos\App_Turnos\sound\siguiente.wav");
            sound.Play();
        }




        protected void btnActualizarPc_Click(object sender, EventArgs e)
        {
            string select = listaPc.SelectedItem.Text;
            if (select != "-")
            {
                Application["pc"] = select;
                txtModulo.Text = Convert.ToString(Application["pc"]);
            }
            
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            
            string consulta = "DELETE FROM llamar_turno";
            cn = new SqlConnection(conectar);
            cmd = new SqlCommand(consulta, cn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        protected void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            tablaTurnos.SelectedIndex = 0;
            GridViewRow row = tablaTurnos.SelectedRow;
            string turno = row.Cells[0].Text;
            string consulta = "DELETE FROM Turnos where id = '"+ turno +"'";
            cn = new SqlConnection(conectar);
            cmd = new SqlCommand(consulta, cn);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            slcTurno_SelectedIndexChanged(sender, e);
            
        }
    }
}