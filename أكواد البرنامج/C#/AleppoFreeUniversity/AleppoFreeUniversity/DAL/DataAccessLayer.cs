using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace AleppoFreeUniversity.DAL
{
    class DataAccessLayer
    {
            SqlConnection sqlcon;
            public DataAccessLayer()//جديد
            {

            //   sqlcon = new SqlConnection(@"Server=.\SQLEXPRESS; Database=AleppoFreeUniversity; Integrated Security=True");
            // sqlcon = new SqlConnection(@"Server=.\SLIMAN; Database=AleppoFreeUniversity; Integrated Security=True");
           //  sqlcon = new SqlConnection(@"Server=.\ABOFAHED; Database=AleppoFreeUniversity; Integrated Security=True");
            // sqlcon = new SqlConnection(@"Server=.\AHSERVER; Database=AleppoFreeUniversity; Integrated Security=True");
            //------------------------ حساب شؤون الامتحانات

                string server, id, password;
                StreamReader sr = new StreamReader("c");
                server = sr.ReadLine();
                id = sr.ReadLine();
                password = sr.ReadLine();
                sr.Close();
                sqlcon = new SqlConnection(@"Server=" + server + "; Database=AleppoFreeUniversity;User ID=" + id + "; Password=" + password);

        }
        public void open()
            {
                if (sqlcon.State != ConnectionState.Open)
                    sqlcon.Open();
            }
            public void close()
            {
                if (sqlcon.State == ConnectionState.Open)
                    sqlcon.Close();
            }
            public DataTable SelectData(string Stored_Procedure, SqlParameter[] param)
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = Stored_Procedure;
                sqlcmd.Connection = sqlcon;
                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                        sqlcmd.Parameters.Add(param[i]);
                }
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void ExecuteCommand(string Stored_Procedure, SqlParameter[] param)
            {

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = Stored_Procedure;
                sqlcmd.Connection = sqlcon;
                if (param != null)
                {
                    sqlcmd.Parameters.AddRange(param);
                }
                sqlcmd.ExecuteNonQuery();
            }
        }
    }