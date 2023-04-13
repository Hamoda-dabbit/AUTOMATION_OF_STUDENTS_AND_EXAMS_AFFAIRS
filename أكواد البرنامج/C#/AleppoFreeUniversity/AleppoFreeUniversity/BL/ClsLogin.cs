using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AleppoFreeUniversity.BL
{
    class ClsLogin
    {
        public DataTable LOGIN(string UserName, string Password)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            param[0].Value = UserName;
            param[1] = new SqlParameter("@Password", SqlDbType.VarChar, 50);
            param[1].Value = Password;
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Sp_Login", param);
            return dt;
        }
        public void add_user(string UName, string Pass, string name, string usertype)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@UName ", SqlDbType.NVarChar, 50);
            param[0].Value = UName;
            param[1] = new SqlParameter("@Pass", SqlDbType.NVarChar, 50);
            param[1].Value = Pass;
            param[2] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[2].Value = name;
            param[3] = new SqlParameter("@usertype", SqlDbType.NVarChar, 50);
            param[3].Value = usertype;
            DAL.ExecuteCommand("add_user", param);
            DAL.close();
        }
        public DataTable Get_All_Users()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Get_All_Users", null);
            DAL.close();
            return dt;
        }
        public void edit_user(string Unameold,string pass,string Unamenew , string name, string usertype)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Unameold ", SqlDbType.NVarChar, 50);
            param[0].Value = Unameold;
            param[1] = new SqlParameter("@pass", SqlDbType.NVarChar, 50);
            param[1].Value = pass;
            param[2] = new SqlParameter("@Unamenew", SqlDbType.NVarChar, 50);
            param[2].Value = Unamenew;
            param[3] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[3].Value = name;
            param[4] = new SqlParameter("@usertype", SqlDbType.NVarChar, 50);
            param[4].Value = usertype;
            DAL.ExecuteCommand("edit_user", param);
            DAL.close();
        }
        public void delete_user(string Uname)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Uname ", SqlDbType.NVarChar, 50);
            param[0].Value = Uname;
            DAL.ExecuteCommand("delete_user", param);
            DAL.close();
        }


        //public DataTable Backup_database(string path)
        //{
        //    DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
        //    DataTable dt = new DataTable();
        //    SqlParameter[] param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@path ", SqlDbType.NVarChar, 50);
        //    param[0].Value = path;
        //    dt = DAL.SelectData("Backup_database", param);
        //    DAL.close();
        //    return dt;
        //}
        public DataTable Backup_database(string path)
        {
            SqlConnection sqlcon;
            sqlcon = new SqlConnection(@"Server=.\SQLEXPRESS; Database=master; Integrated Security=True");
         //   DataTable dt = new DataTable();             
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@path ", SqlDbType.NVarChar, 50);
            param[0].Value = path;
            ////////
             SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Backup_database";
            sqlcmd.Connection = sqlcon;
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                    sqlcmd.Parameters.Add(param[i]);
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //////////
            if (sqlcon.State == ConnectionState.Open)
                sqlcon.Close();
            return dt;
        }
        public DataTable Restore_database(string path)
        {
            SqlConnection sqlcon;
            sqlcon = new SqlConnection(@"Server=.\SQLEXPRESS; Database=master; Integrated Security=True");
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@path ", SqlDbType.NVarChar, 50);
            param[0].Value = path;
            ////////
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "restore_db";
            sqlcmd.Connection = sqlcon;
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                    sqlcmd.Parameters.Add(param[i]);
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //////////
            if (sqlcon.State == ConnectionState.Open)
                sqlcon.Close();
            return dt;
        }
    }
}