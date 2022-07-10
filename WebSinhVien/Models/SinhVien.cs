using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebSinhVien.Models
{
    public class SinhVien
    {
        [Key]
        public int MASV { get; set; }
        [Required(ErrorMessage ="Vui Long Nhap Du Thong Tin")]
        [Display(Name =" Ho ten:")]
        public string TENSV { get; set; }
        [Required(ErrorMessage ="Vui Long Nhap Du Thong Tin")]
        [Display(Name="Lop:")]
        public string Lop { get; set; }
        public string Diem { get; set; }
        public string DiaChi { get; set; }
    }
    class ListStudent
    {
        DataConnection dbc;
        public ListStudent()
        {
            dbc = new DataConnection();
        }
        public List<SinhVien>getsv(string MASV)
        {
           
            string url;
            if(string.IsNullOrEmpty(MASV))
            
                url = "SELECT * FROM SINHVIEN";
            


            else
            
                url = "SELECT *FROM SINHVIEN WHERE MASV="+MASV ;
            
            List<SinhVien> dssinhvien = new List<SinhVien>();
            DataTable dt = new DataTable();
            SqlConnection con = dbc.getConnection();
            SqlDataAdapter da = new SqlDataAdapter(url, con);
             con.Open();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            SinhVien temp;
            for(int i=0;i<dt.Rows.Count;i++)
            {
                temp = new SinhVien();
                temp.MASV= Convert.ToInt32(dt.Rows[i]["MASV"].ToString());
                temp.TENSV= dt.Rows[i]["TENSV"].ToString();
                temp.Lop = dt.Rows[i]["LOP"].ToString();
                temp.Diem = dt.Rows[i]["DIEM"].ToString();
                temp.DiaChi = dt.Rows[i]["DIACHI"].ToString();
                dssinhvien.Add(temp);
            }
            return dssinhvien;
            
        }
        public void InsertStudent(SinhVien sv)
        {
            string url =
         "INSERT INTO SINHVIEN(MASV,TENSV,LOP,DIEM,DiaChi) VALUES ('" + sv.MASV + "','" + sv.TENSV + "','" + sv.Lop + "','" + sv.Diem + "','" + sv.DiaChi + "')";
            SqlConnection con = dbc.getConnection();
            SqlCommand cmd = new SqlCommand(url,con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        public void EditSinhVien(SinhVien sv)
        {
            string url = "Update SINHVIEN SET TENSV='" + sv.TENSV + "',LOP='" + sv.Lop + "',DIEM='" + sv.Diem + "',DIACHI='" + sv.DiaChi + "' where MASV="+sv.MASV;
            SqlConnection con = dbc.getConnection();
            SqlCommand cmd = new SqlCommand(url, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            
        }
        public void DeleteSinhVien(SinhVien sv)
        {
            string url = "Delete from SINHVIEN where MASV= " + sv.MASV;
            SqlConnection con = dbc.getConnection();
            SqlCommand cmd = new SqlCommand(url, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }


    }
}