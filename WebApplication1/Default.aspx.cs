using FITC.Web.Component;
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
        FITC_CDataBase db = new FITC_CDataBase(Static.GetConnect());
        CacHamChung ham = new CacHamChung();
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8
            };

            DataSet ds = db.GetDataSet("TrangWeb_SELECT");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];

                    DataSet ds1 = db.GetDataSet("XPath_DanhSachBaiViet_SELECT", row["id"].ToString());
                    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                        {
                            DataRow row1 = ds1.Tables[0].Rows[j];

                            int n = 1;
                            while (true)
                            {
                                HtmlDocument html = htmlWeb.Load(row["Url"].ToString() + row["ChuyenMuc_Url"].ToString() + row["ChuyenMucCon_Url"].ToString() + "?p=" + (n++));
                                var DanhSach = html.DocumentNode.SelectNodes(row1["DanhSach"].ToString()) != null ? html.DocumentNode.SelectNodes(row1["DanhSach"].ToString()).ToList() : null;
                                if (DanhSach == null)
                                    break;
                                foreach (var item in DanhSach)
                                {
                                    var TieuDe = item.SelectSingleNode(row1["TieuDe"].ToString());
                                    var TomTat = item.SelectSingleNode(row1["TomTat"].ToString());
                                    var BaiViet_Url = item.SelectSingleNode(row1["BaiViet_Url"].ToString()).Attributes["href"].Value;

                                    object[] obj = new object[5];
                                    obj[0] = 0;
                                    obj[1] = row1["TrangWeb_id"].ToString();
                                    obj[2] = TieuDe != null ? TieuDe.InnerText : "";
                                    obj[3] = TomTat != null ? TomTat.InnerText : "";
                                    obj[4] = BaiViet_Url != null ? BaiViet_Url : "";
                                    string sLoi = db.ExcuteSP("BaiViet_INSERT", obj);
                                }
                            }
                        }
                    }

                    DataSet ds2 = db.GetDataSet("XPath_ChiTietBaiViet_SELECT", row["id"].ToString());

                    DataSet ds3 = db.GetDataSet("BaiViet_SELECT");
                    if (ds3 != null && ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
                        {
                            DataRow row3 = ds3.Tables[0].Rows[j];

                            if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                            {
                                DataRow row2 = ds2.Tables[0].Rows[0];

                                HtmlDocument html = htmlWeb.Load(row3["BaiViet_Url"].ToString());
                                var TieuDePhu = html.DocumentNode.SelectSingleNode(row2["TieuDePhu"].ToString());
                                var NoiDung = html.DocumentNode.SelectSingleNode(row2["NoiDung"].ToString());
                                var ThoiGian = html.DocumentNode.SelectSingleNode(row2["ThoiGian"].ToString());
                                var TacGia = html.DocumentNode.SelectSingleNode(row2["TacGia"].ToString());

                                object[] obj = new object[6];
                                obj[0] = 0;
                                obj[1] = row3["id"].ToString();
                                obj[2] = TieuDePhu != null ? TieuDePhu.InnerText : "";
                                obj[3] = NoiDung != null ? NoiDung.InnerHtml : "";
                                obj[4] = TacGia != null ? TacGia.InnerText : "";
                                obj[5] = ThoiGian != null ? ThoiGian.InnerText : "";
                                string sLoi = db.ExcuteSP("BaiViet_UPDATE", obj);
                            }
                        }
                    }
                }
            }

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