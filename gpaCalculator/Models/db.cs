using System.Data.SqlClient;
using gpaCalculator.Models;
using System.Data;
using Microsoft.VisualBasic;

namespace gpaCalculator.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-THJI1RU;Database=gpaCalculatorDb;TrustServerCertificate=True;Integrated Security=True");

        public DataSet SubjectOpt(Subject subject, out String msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("Sp_Subject", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID", subject.id);
                com.Parameters.AddWithValue("@Subject_code", subject.subject_code);
                com.Parameters.AddWithValue("@Subject_name", subject.subject_name);
                com.Parameters.AddWithValue("@Credit", subject.credit);

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "Success";
                return ds;
            }
            catch (Exception ex)
            {

                msg = ex.Message;
            }
            
            return ds;
        }
    }
}
