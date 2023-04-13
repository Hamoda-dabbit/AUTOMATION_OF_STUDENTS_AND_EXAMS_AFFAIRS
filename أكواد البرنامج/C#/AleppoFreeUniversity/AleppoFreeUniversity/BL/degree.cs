using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace AleppoFreeUniversity.BL
{
    class degree
    {
        public void insert_degree(int std_num, int mat_id, int deg_pract, int deg_theo, int seas, DateTime year_ofDeg)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@std_num", SqlDbType.Int);
            param[0].Value = std_num;
            param[1] = new SqlParameter("@mat_id", SqlDbType.Int);
            param[1].Value = mat_id;
            param[2] = new SqlParameter("@deg_pract", SqlDbType.Int);
            param[2].Value = deg_pract;
            param[3] = new SqlParameter("@deg_theo", SqlDbType.Int);
            param[3].Value = deg_theo;
            param[4] = new SqlParameter("@seas", SqlDbType.Int);
            param[4].Value = seas;
            param[5] = new SqlParameter("@year_ofDeg", SqlDbType.Date);
            param[5].Value = year_ofDeg;

            DAL.ExecuteCommand("insert_degree", param);
            DAL.close();
        }
    }
}
