using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Projekat.Account
{
    public partial class View : System.Web.UI.Page
    {
        List<Bend> bendovi = new List<Bend>();
        List<Pesma> pesme = new List<Pesma>();
        List<Album> albumi = new List<Album>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Projekat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                using (con)
                {
                    con.Open();
                    string upitB = "SELECT naziv,CAST(datum AS DATE) AS date,logoPutanja,sajt FROM Izvodjac";
                    string upitA = "SELECT a.naziv,i.naziv as band,CAST(a.datum AS DATE) AS date,a.slikaPutanja FROM Album a JOIN Izvodjac i ON a.sifraIzvodjaca = i.sifra";
                    string upitS = "SELECT p.naziv,a.naziv as album,a.slikaPutanja,i.naziv,p.link FROM Pesma p, Album a, Izvodjac i WHERE p.sifraAlbuma = a.sifra AND a.sifraIzvodjaca = i.sifra";

                    //ubacivanje bendova
                    SqlCommand cmd = new SqlCommand(upitB, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Bend b = new Bend(dr[0].ToString(), dr[1].ToString().Remove(10), dr[2].ToString(), dr[3].ToString(), "Click here");
                        bendovi.Add(b);
                    }
                    dr.Close();

                    //ubacivanje albuma
                    cmd = new SqlCommand(upitA, con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Album b = new Album(dr[0].ToString(), dr[1].ToString(), dr[2].ToString().Remove(10), dr[3].ToString());
                        albumi.Add(b);
                    }
                    dr.Close();

                    //ubacivanje pesama
                    cmd = new SqlCommand(upitS, con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Pesma b = new Pesma(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),dr[4].ToString(),"YouTube link");
                        pesme.Add(b);
                    }
                    dr.Close();

                    gvBand.DataSource = bendovi;
                    gvBand.DataBind();
                }
                    

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
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Projekat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                /*
                 Tri gridview-a, jer se ucitavaju podaci iz tri posebne tabele
                 Na pocetku se sve ciste
                 */
                gvBand.DataSource = null;
                gvBand.DataBind();
                gvAlbum.DataSource = null;
                gvAlbum.DataBind();
                gvSong.DataSource = null;
                gvSong.DataBind();

                gvBand.Visible = false;
                gvAlbum.Visible = false;
                gvSong.Visible = false;

                switch (ddlSearch.SelectedValue)
                {
                    case "b":
                        TraziBend();
                        gvBand.Visible = true;
                        break;
                    case "a":
                        TraziAlbum();
                        gvAlbum.Visible = true;
                        break;
                    case "s":
                        TraziPesmu();
                        gvSong.Visible = true;
                        break;
                    default:
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

        protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblName.Visible = true;
            tbName.Visible = true;

            if (ddlSearch.SelectedValue == "a") //za album trebaju textbox za naziv i textbox za bend
            {
                lblAlbum.Visible = false;
                tbAlbum.Visible = false;
                lblBand.Visible = true;
                tbBand.Visible = true;

                gvAlbum.DataSource = albumi;
                gvAlbum.DataBind();

                gvBand.DataSource = null;
                gvBand.DataBind();
                gvSong.DataSource = null;
                gvSong.DataBind();

                gvAlbum.Visible = true;
                gvBand.Visible = false;
                gvSong.Visible = false;
            }
            else if (ddlSearch.SelectedValue == "b") // za bend samo tb za naziv
            {
                lblAlbum.Visible = false;
                tbAlbum.Visible = false;
                lblBand.Visible = false;
                tbBand.Visible = false;

                gvBand.DataSource = bendovi;
                gvBand.DataBind();

                gvAlbum.DataSource = null;
                gvAlbum.DataBind();
                gvSong.DataSource = null;
                gvSong.DataBind();

                gvBand.Visible= true;
                gvAlbum.Visible = false;
                gvSong.Visible = false;
            }
            else if (ddlSearch.SelectedValue=="s") //za pesmu treba sve
            {
                lblBand.Visible = true;
                tbBand.Visible = true;
                lblAlbum.Visible = true;
                tbAlbum.Visible = true;

                gvSong.DataSource = pesme;
                gvSong.DataBind();

                gvBand.DataSource = null;
                gvBand.DataBind();
                gvAlbum.DataSource = null;
                gvAlbum.DataBind();

                gvSong.Visible = true;
                gvBand.Visible = false;
                gvAlbum.Visible = false;
            }


        }

        void TraziBend()
        {
            List<Bend> nova = new List<Bend>();
            string tekst = tbName.Text.ToLower();
            if (tekst != "")
            {
                foreach (Bend lol in bendovi)
                {
                    if (lol.name.ToLower().StartsWith(tekst))
                        nova.Add(lol);
                }
                gvBand.DataSource = nova;
                gvBand.DataBind();
            }
            else
            { 
                gvBand.DataSource = bendovi;
                gvBand.DataBind();
            }
        }

        void TraziAlbum()
        {
            List<Album> nova = new List<Album>();
            string naziv = tbName.Text.ToLower();
            string bend = tbBand.Text.ToLower();
            bool prolazi;
            foreach (Album lol in albumi)
            {
                prolazi = true;
                if (naziv != "")
                { 
                    if (!lol.name.ToLower().StartsWith(naziv))
                        prolazi = false;
                }
                if (bend != "")
                {
                    if (!lol.band.ToLower().StartsWith(bend))
                        prolazi = false;
                }
                if(prolazi)
                    nova.Add(lol);
            }
            if (nova.Count > 0)
            {
                gvAlbum.DataSource = nova;
                gvAlbum.DataBind();
            }
            else
            {
                gvAlbum.DataSource = null;
                gvAlbum.DataBind();
            }
            
        }

        void TraziPesmu()
        {
            List<Pesma> nova = new List<Pesma>();
            string naziv = tbName.Text.ToLower();
            string bend = tbBand.Text.ToLower();
            string album = tbAlbum.Text.ToLower();
            bool prolazi;
            foreach (Pesma lol in pesme)
            {
                prolazi = true;
                if (naziv != "")
                {
                    if (!lol.name.ToLower().StartsWith(naziv))
                        prolazi = false;
                }
                if (album != "")
                {
                    if (!lol.album.ToLower().StartsWith(album))
                        prolazi = false;
                }
                if (bend != "")
                {
                    if (!lol.band.ToLower().StartsWith(bend))
                        prolazi = false;
                }
                if (prolazi)
                    nova.Add(lol);
            }
            if (nova.Count > 0)
            {
                gvSong.DataSource = nova;
                gvSong.DataBind();
            }
            else
            {
                gvSong.DataSource = null;
                gvSong.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            tbAlbum.Text = "";
            tbBand.Text = "";
            tbName.Text = "";
        }
    }
}