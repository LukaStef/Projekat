using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekat.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Projekat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                string upit = "SELECT * FROM Izvodjac";
                TraziBiloSta(con, upit);
            }
            catch (Exception x)
            {
                lblError.Text = "SERVER ERROR";
                System.Diagnostics.Debug.WriteLine(x.Message);
                System.Diagnostics.Debug.WriteLine(x.StackTrace);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
        void TraziBiloSta(SqlConnection con,string upit)
        {
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(upit, con);
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
            }
        }
        protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OcistiTextboxoveAlbum();
                OcistiTextboxoveBand();
                OcistitextboxoveSong();
                SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Projekat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                string upit = "";
                switch (ddlSearch.SelectedValue)
                {
                    case "b":
                        upit = "SELECT * FROM Izvodjac";
                        panelBand.Visible = true;
                        panelAlbum.Visible = false;
                        panelSong.Visible = false;
                        break;
                    case "a":
                        upit = "SELECT * FROM Album";
                        panelBand.Visible = false;
                        panelAlbum.Visible = true;
                        panelSong.Visible = false;
                        break;
                    case "s":
                        upit = "SELECT * FROM Pesma";
                        panelBand.Visible = false;
                        panelAlbum.Visible = false;
                        panelSong.Visible = true;
                        break;
                }
                TraziBiloSta(con, upit);
            }
            catch (Exception x)
            {
                lblError.Text = "SERVER ERROR";
                System.Diagnostics.Debug.WriteLine(x.Message);
                System.Diagnostics.Debug.WriteLine(x.StackTrace);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.SelectedRow;
                switch (ddlSearch.SelectedValue)
                {
                    case "b":
                        
                        tbId.Text = row.Cells[1].Text;
                        tbName.Text = row.Cells[2].Text;
                        tbLogo.Text = row.Cells[3].Text;
                        tbDate.Text = row.Cells[4].Text;
                        tbSite.Text = row.Cells[5].Text;

                        break;
                    case "a":

                        tbIdA.Text = row.Cells[1].Text;
                        tbnameA.Text = row.Cells[2].Text;
                        tbCover.Text = row.Cells[3].Text;
                        tbDateA.Text = row.Cells[4].Text;
                        tbBand.Text = row.Cells[5].Text;

                        break;
                    case "s":

                        tbIdS.Text = row.Cells[1].Text;
                        tbNameS.Text = row.Cells[2].Text;
                        tbAlbum.Text = row.Cells[3].Text;
                        tblink.Text = row.Cells[4].Text;

                        break;
                }
            }
            catch (Exception x)
            {
                lblError.Text = "SERVER ERROR";
                System.Diagnostics.Debug.WriteLine(x.Message);
                System.Diagnostics.Debug.WriteLine(x.StackTrace);
            }
        }

        void OcistiTextboxoveBand()
        {
            tbId.Text = "";
            tbName.Text = "";
            tbLogo.Text = "";
            tbDate.Text = "";
            tbSite.Text = "";
        }

        void OcistiTextboxoveAlbum()
        {
            tbIdA.Text = "";
            tbnameA.Text = "";
            tbCover.Text = "";
            tbDateA.Text = "";
            tbBand.Text = "";
        }

        void OcistitextboxoveSong()
        {
            tbIdS.Text = "";
            tbNameS.Text = "";
            tbAlbum.Text = "";
            tblink.Text = "";
        }
    }
}