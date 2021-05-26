using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8
            };

            string sqlconnectStr = "Data Source=.;Initial Catalog=DuLieu;Persist Security Info=True;User ID=sa;Password=123";
            SqlConnection connection = new SqlConnection(sqlconnectStr);

            connection.Open();                      // Mở kết nối - hoặc  connection.OpenAsync(); nếu dùng async

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select * from TrangWeb";
            var rd = cmd.ExecuteReader();
            DataTable dsWeb = new DataTable();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    dsWeb.Load(rd);
                }
            }
            //if (dsWeb != null && dsWeb.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dsWeb.Rows.Count; i++)
            //    {
            //        DataRow row = dsWeb.Rows[i];

            //        connection.Open();
            //        SqlCommand cmd1 = new SqlCommand();
            //        cmd1.Connection = connection;
            //        cmd1.CommandText = "select * from XPath_DanhSachBaiViet where TrangWeb_id=@TrangWeb_id";
            //        cmd1.Parameters.AddWithValue("@TrangWeb_id", row["id"].ToString());
            //        var rd1 = cmd1.ExecuteReader();
            //        DataTable dsXPath_DS = new DataTable();
            //        if (rd1.HasRows)
            //        {
            //            while (rd1.Read())
            //            {
            //                dsXPath_DS.Load(rd1);
            //            }
            //        }
            //        connection.Close();
            //        if (dsXPath_DS != null && dsXPath_DS.Rows.Count > 0)
            //        {
            //            for (int j = 0; j < dsXPath_DS.Rows.Count; j++)
            //            {
            //                DataRow row1 = dsXPath_DS.Rows[j];
            //                HtmlDocument html = htmlWeb.Load(row["Url"].ToString() + row["ChuyenMuc_Url"].ToString() + row["ChuyenMucCon_Url"].ToString());
            //                var ds = html.DocumentNode.SelectNodes(row1["DanhSach"].ToString());
            //                foreach (var item in ds)
            //                {
            //                    var TieuDe = item.SelectSingleNode(row1["TieuDe"].ToString());
            //                    var TieuDePhu = item.SelectSingleNode(row1["TieuDePhu"].ToString());
            //                    var TomTat = item.SelectSingleNode(row1["TomTat"].ToString());
            //                    var BaiViet_Url = item.SelectSingleNode(row1["BaiViet_Url"].ToString()).Attributes["href"].Value;

            //                    SqlCommand cmd3 = new SqlCommand();
            //                    cmd3.Connection = connection;
            //                    cmd3.CommandText = "insert into BaiViet(TieuDe, TomTat, BaiViet_Url) values(@TieuDe, @TomTat, @BaiViet_Url)";
            //                    cmd3.Parameters.AddWithValue("@TieuDe", TieuDe.InnerText);
            //                    cmd3.Parameters.AddWithValue("@TomTat", TomTat.InnerText);
            //                    cmd3.Parameters.AddWithValue("@BaiViet_Url", BaiViet_Url);
            //                    cmd3.ExecuteNonQuery();
            //                }
            //            }
            //        }

            //        connection.Open();
            //        SqlCommand cmd2 = new SqlCommand();
            //        cmd2.Connection = connection;
            //        cmd2.CommandText = "select * from XPath_ChiTietBaiViet where TrangWeb_id=@TrangWeb_id";
            //        cmd2.Parameters.AddWithValue("@TrangWeb_id", row["id"].ToString());
            //        var rd2 = cmd2.ExecuteReader();
            //        DataTable dsXPath_ChiTiet = new DataTable();
            //        if (rd2.HasRows)
            //        {
            //            while (rd2.Read())
            //            {
            //                dsXPath_ChiTiet.Load(rd2);
            //            }
            //        }
            //        connection.Close();
            //    }
            //}
            
            try
            {
                HtmlDocument html = htmlWeb.Load("https://baothuathienhue.vn/sen-trang-hue-hoi-sinh-o-ho-tinh-tam-a100343.html");
                var tieude = html.DocumentNode.SelectSingleNode("//*[@id='colcate1']/h1");
                string stieude = tieude.InnerText;
                var thoigian = html.DocumentNode.SelectSingleNode("//*[@id='clear']/span");
                string sthoigian = thoigian.InnerText;
                var tomtat = html.DocumentNode.SelectSingleNode("//*[@id='colcate1']/p");
                string stomtat = tomtat.InnerText;
                var noidung = html.DocumentNode.SelectSingleNode("//*[@id='newscontents']");
                string snoidung = noidung.InnerHtml;
                var tacgia = html.DocumentNode.SelectSingleNode("//*[@id='newscontents']/p[30]/strong");
                string stacgia = tacgia.InnerText;
                main.InnerHtml = snoidung;
            }
            catch (Exception ex)
            {
                main.InnerText = "Lỗi: " + ex ;
            }
        }
    }
}