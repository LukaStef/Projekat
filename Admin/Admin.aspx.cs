using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projekat.Admin
{
    public partial class Admin : System.Web.UI.Page
    {
        string cs = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Projekat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            try
            {
                SqlConnection con = new SqlConnection(cs);

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
                lblError.Text = "";
                OcistiTextboxoveAlbum();
                OcistiTextboxoveBand();
                OcistitextboxoveSong();
                SqlConnection con = new SqlConnection(cs);
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
                        tbDate.Text = PromeniFormatZaDatum(row.Cells[4].Text); //sql puno zeza sa datumima
                        tbSite.Text = row.Cells[5].Text;

                        break;
                    case "a":

                        tbIdA.Text = row.Cells[1].Text;
                        tbNameA.Text = row.Cells[2].Text;
                        tbCover.Text = row.Cells[3].Text;
                        tbDateA.Text = PromeniFormatZaDatum(row.Cells[4].Text);
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
            tbNameA.Text = "";
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!Page.IsValid)
                return;
            try
            {
                string upit = "";
                SqlConnection con = new SqlConnection(cs);
                if (ddlSearch.SelectedValue == "b")
                {
                    AddBand(con);
                    upit = "SELECT * FROM Izvodjac";
                }
                if (ddlSearch.SelectedValue == "a")
                {
                    AddAlbum(con);
                    upit = "SELECT * FROM Album";
                }
                if (ddlSearch.SelectedValue == "s")
                {
                    AddSong(con);
                    upit = "SELECT * FROM Pesma";
                }
                con = new SqlConnection(cs);
                TraziBiloSta(con, upit);
            }
            catch (Exception x)
            {
                lblError.Text = "SERVER ERROR";
                System.Diagnostics.Debug.WriteLine(x.Message);
                System.Diagnostics.Debug.WriteLine(x.StackTrace);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!Page.IsValid)
                return;
            try
            {
                string upit = "";
                SqlConnection con = new SqlConnection(cs);
                if (ddlSearch.SelectedValue == "b")
                {
                    EditBand(con);
                    upit = "SELECT * FROM Izvodjac";
                }
                if (ddlSearch.SelectedValue == "a")
                {
                    EditAlbum(con);
                    upit = "SELECT * FROM Album";
                }
                if (ddlSearch.SelectedValue == "s")
                {
                    EditSong(con);
                    upit = "SELECT * FROM Pesma";
                }
                con = new SqlConnection(cs);
                TraziBiloSta(con, upit);
            }
            catch (Exception x)
            {
                lblError.Text = "SERVER ERROR";
                System.Diagnostics.Debug.WriteLine(x.Message);
                System.Diagnostics.Debug.WriteLine(x.StackTrace);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (!Page.IsValid)
                return;
            try
            {
                string upit = "";
                SqlConnection con = new SqlConnection(cs);
                if (ddlSearch.SelectedValue == "b")
                {
                    DeleteBand(con);
                    upit = "SELECT * FROM Izvodjac";
                }
                if (ddlSearch.SelectedValue == "a")
                {
                    DeleteAlbum(con);
                    upit = "SELECT * FROM Album";
                }
                if (ddlSearch.SelectedValue == "s")
                {
                    DeleteSong(con);
                    upit = "SELECT * FROM Pesma";
                }
                con = new SqlConnection(cs);
                TraziBiloSta(con, upit);
            }
            catch (Exception x)
            {
                lblError.Text = "SERVER ERROR";
                System.Diagnostics.Debug.WriteLine(x.Message);
                System.Diagnostics.Debug.WriteLine(x.StackTrace);
            }
        }

        void AddBand(SqlConnection con)
        {
            using (con)
            {
                con.Open();
                string name = tbName.Text;
                string logo = tbLogo.Text;
                string date = tbDate.Text;
                string site = tbSite.Text;
                string upit = "INSERT INTO Izvodjac(naziv,logoPutanja,datum,sajt) VALUES(@name,@logo,@date,@site)";
                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("name",name);
                cmd.Parameters.AddWithValue("logo",logo);
                cmd.Parameters.AddWithValue("date",date);
                cmd.Parameters.AddWithValue("site",site);
                cmd.ExecuteNonQuery();
            }
        }

        void EditBand(SqlConnection con)
        {
            using (con)
            {
                con.Open();
                string id = tbId.Text;
                string name = tbName.Text;
                string logo = tbLogo.Text;
                string date = tbDate.Text;
                string site = tbSite.Text;
                string upit = "UPDATE Izvodjac SET naziv=@name, logoPutanja=@logo, datum=@date, sajt=@site WHERE sifra=@id";
                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("logo", logo);
                cmd.Parameters.AddWithValue("date", date);
                cmd.Parameters.AddWithValue("site", site);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        void DeleteBand(SqlConnection con)
        {
            using (con)
            {
                con.Open();
                string id = tbId.Text;
                string upit = "DELETE FROM Izvodjac WHERE sifra=@id";
                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("id",id);
                cmd.ExecuteNonQuery();
            }
        }
        void AddAlbum(SqlConnection con)
        {
            using (con)
            {
                con.Open();
                string name = tbNameA.Text;
                string logo = tbCover.Text;
                string date = tbDateA.Text;
                string band = tbBand.Text;
                string upit = "INSERT INTO Album(naziv,slikaPutanja,datum,sifraIzvodjaca) VALUES(@name,@logo,@date,@band)";
                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("logo", logo);
                cmd.Parameters.AddWithValue("date", date);
                cmd.Parameters.AddWithValue("band", band);
                cmd.ExecuteNonQuery();
            }
        }
        void EditAlbum(SqlConnection con)
        {
            using (con)
            {
                con.Open();
                string id = tbIdA.Text;
                string name = tbNameA.Text;
                string cover = tbCover.Text;
                string date = tbDateA.Text;
                string band = tbBand.Text;
                string upit = "UPDATE Album SET naziv=@name, slikaPutanja=@cover, datum=@date, sifraIzvodjaca=@band WHERE sifra=@id";
                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("cover", cover);
                cmd.Parameters.AddWithValue("date", date);
                cmd.Parameters.AddWithValue("band", band);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        void DeleteAlbum(SqlConnection con)
        {
            using (con)
            {
                con.Open();
                string id = tbIdA.Text;
                string upit = "DELETE FROM Album WHERE sifra=@id";
                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        void AddSong(SqlConnection con)
        {
            using (con)
            {
                con.Open();
                string name = tbNameS.Text;
                string album = tbAlbum.Text;
                string link = tblink.Text;
                string upit = "INSERT INTO Pesma(naziv,sifraAlbuma,link) VALUES(@name,@album,@link)";
                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("album", album);
                cmd.Parameters.AddWithValue("link", link);
                cmd.ExecuteNonQuery();
            }
        }
        void EditSong(SqlConnection con)
        {
            using (con)
            {
                con.Open();
                string id = tbIdS.Text;
                string name = tbNameS.Text;
                string album = tbAlbum.Text;
                string link = tblink.Text;
                string upit = "UPDATE Pesma SET naziv=@name, sifraAlbuma=@album, link=@link WHERE sifra=@id";
                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("album", album);
                cmd.Parameters.AddWithValue("link", link);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
        void DeleteSong(SqlConnection con)
        {
            using (con)
            {
                con.Open();
                string id = tbIdS.Text;
                string upit = "DELETE FROM Pesma WHERE sifra=@id";
                SqlCommand cmd = new SqlCommand(upit, con);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        string PromeniFormatZaDatum(string datum)
        {
            datum = datum.Remove(10);
            string[] delovi = datum.Split('/');
            datum = $"{delovi[2]}-{delovi[1]}-{delovi[0]}";
            return datum;
        }
    }
}