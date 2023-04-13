using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace AleppoFreeUniversity.BL
{
    class Cls_degree
    {
        public void insert_degree(string std_num, string mat_id, int deg_pract, int deg_theo, int seas, DateTime year_ofDeg, int teach_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@std_num", SqlDbType.NVarChar,20);
            param[0].Value = std_num;
            param[1] = new SqlParameter("@mat_id", SqlDbType.NVarChar,20);
            param[1].Value = mat_id;
            param[2] = new SqlParameter("@deg_pract", SqlDbType.Int);
            param[2].Value = deg_pract;
            param[3] = new SqlParameter("@deg_theo", SqlDbType.Int);
            param[3].Value = deg_theo;
            param[4] = new SqlParameter("@seas", SqlDbType.Int);
            param[4].Value = seas;
            param[5] = new SqlParameter("@year_ofDeg", SqlDbType.Date);
            param[5].Value = year_ofDeg;
            param[6] = new SqlParameter("@teach_id", SqlDbType.Int);
            param[6].Value = teach_id;

            DAL.ExecuteCommand("insert_degree", param);
            DAL.close();
        }

        public DataTable GET_DEGREE(string id,int year,bool seson)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar,20);
            param[0].Value = id;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            param[2] = new SqlParameter("@seson", SqlDbType.Bit);
            param[2].Value=seson;
            Dt = dal.SelectData("DEGREE_SCORE", param);           
            dal.close();
            return Dt;
        }
        public DataTable get_degreesWithSeson(string id, int year, bool seson)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 20);
            param[0].Value = id;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            param[2] = new SqlParameter("@seson", SqlDbType.Bit);
            param[2].Value = seson;
            Dt = dal.SelectData("get_degreesWithSeson", param);
            dal.close();
            return Dt;
        }

        public DataTable GET_All_DEGREE()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = dal.SelectData("Get_All_Degree", null);
            dal.close();
            return Dt;
        }
        public void edit_degree(string student_id, string material_id, int degree_practical, int degree_theoretical, int season, DateTime year_ofDegree, int teach_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@std_id", SqlDbType.NVarChar,20);
            param[0].Value = student_id;
            param[1] = new SqlParameter("@mat_id", SqlDbType.NVarChar ,20);
            param[1].Value = material_id;
            param[2] = new SqlParameter("@deg_prac", SqlDbType.Int);
            param[2].Value = degree_practical;
            param[3] = new SqlParameter("@deg_theo", SqlDbType.Int);
            param[3].Value = degree_theoretical;
            param[4] = new SqlParameter("@season", SqlDbType.Int);
            param[4].Value = season;
            param[5] = new SqlParameter("@year_deg", SqlDbType.Date);
            param[5].Value = year_ofDegree;
            param[6] = new SqlParameter("@teach_id", SqlDbType.Int);
            param[6].Value = teach_id;
            DAL.ExecuteCommand("edit_degree", param);
            DAL.close();
        }

        public void delete_degree(string student_id , string material_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar,20);
            param[0].Value = student_id;
            param[1] = new SqlParameter("@mat_id", SqlDbType.NVarChar,20);
            param[1].Value = material_id;
            DAL.ExecuteCommand("delete_degree", param);
            DAL.close();
        }

        public DataTable Search_Degree(string std_id,string mat_id)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@std_id", SqlDbType.NVarChar,20);
            param[0].Value = std_id;
            param[1] = new SqlParameter("@mat_id", SqlDbType.NVarChar,20);
            param[1].Value = mat_id;
            Dt = dal.SelectData("Search_Degree", param);
            dal.close();
            return Dt;
        }

        public DataTable GET_AVG_STUDENT(string id, int year)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar,20);
            param[0].Value = id;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            Dt = dal.SelectData("GET_AVG_DEGREE", param);
            dal.close();
            return Dt;
        }


        public DataTable Get_All_Material(int faculty, int year,bool seson)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@faculty", SqlDbType.Int);
            param[0].Value = faculty;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            param[2] = new SqlParameter("@seson", SqlDbType.Bit);
            param[2].Value = seson;
            Dt = dal.SelectData("Get_All_Material", param);
            dal.close();
            return Dt;
        }
        public DataTable Get_Top10(int year, int fucty)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@year", SqlDbType.Int);
            param[0].Value = year;
            param[1] = new SqlParameter("@fucty", SqlDbType.Int);
            param[1].Value = fucty;
            Dt = dal.SelectData("get_top10", param);
            dal.close();
            return Dt;
        }

        public DataTable null_matirial(int student_id)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@std", SqlDbType.Int);
            param[0].Value = student_id;
            Dt = dal.SelectData("null_matirial", param);
            dal.close();
            return Dt;
        }
        public DataTable fail_degree(int student_id)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@std", SqlDbType.Int);
            param[0].Value = student_id;
            Dt = dal.SelectData("fail_degree", param);
            dal.close();
            return Dt;
        }
        public DataTable get_all_name_in_year(int faculty, int year)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@faculty", SqlDbType.Int);
            param[0].Value = faculty;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            Dt = dal.SelectData("get_all_name_in_year", param);
            dal.close();
            return Dt;
        }

        public DataTable get_mat_year1(string mat, int year)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@mat", SqlDbType.NVarChar,10);
            param[0].Value = mat;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            Dt = dal.SelectData("get_mat_year", param);
            dal.close();
            return Dt;
        }
        public DataTable get_mat_year2(string mat, int year)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@mat", SqlDbType.NVarChar, 10);
            param[0].Value = mat;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            Dt = dal.SelectData("get_mat_year2", param);
            dal.close();
            return Dt;
        }
        public DataTable get_mat_year3(string mat, int year)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@mat", SqlDbType.NVarChar, 10);
            param[0].Value = mat;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            Dt = dal.SelectData("get_mat_year3", param);
            dal.close();
            return Dt;
        }

        public DataTable exam_record(int year_m, int year_d)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@year_mat", SqlDbType.Int);
            param[0].Value = year_m;
            param[1] = new SqlParameter("@year_deg", SqlDbType.Int);
            param[1].Value = year_d;
            Dt = dal.SelectData("exam_record", param);
            dal.close();
            return Dt;
        }

        public DataTable exam_record_p(int fac, int year_m, int year_d)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@faculty", SqlDbType.Int);
            param[0].Value = fac;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year_m;
            param[2] = new SqlParameter("@year_deg", SqlDbType.Int);
            param[2].Value = year_d;
            Dt = dal.SelectData("exam_record_by_mat_p", param);
            dal.close();
            return Dt;
        }


        public DataTable exam_record_t(int fac, int year_m, int year_d)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@faculty", SqlDbType.Int);
            param[0].Value = fac;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year_m;
            param[2] = new SqlParameter("@year_deg", SqlDbType.Int);
            param[2].Value = year_d;
            Dt = dal.SelectData("exam_record_by_mat_t", param);
            dal.close();
            return Dt;
        }

        public DataTable exam_record_f(int fac, int year_m, int year_d)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@faculty", SqlDbType.Int);
            param[0].Value = fac;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year_m;
            param[2] = new SqlParameter("@year_deg", SqlDbType.Int);
            param[2].Value = year_d;
            Dt = dal.SelectData("exam_record_by_mat_f", param);
            dal.close();
            return Dt;
        }

        public DataTable exam_record_by_mat(int faculty, int year, int year_deg)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@faculty", SqlDbType.Int);
            param[0].Value = faculty;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            param[2] = new SqlParameter("@year_deg", SqlDbType.Int);
            param[2].Value = year_deg;
            Dt = dal.SelectData("exam_record_by_mat", param);
            dal.close();
            return Dt;
        }

        public DataTable backup_degree()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = dal.SelectData("backup_degree", null);
            dal.close();
            return Dt;
        }
        public DataTable all_mat(int faculty)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@faculty", SqlDbType.Int);
            param[0].Value = faculty;          
            Dt = dal.SelectData("all_mat", param);
            dal.close();
            return Dt;
        }
        public DataTable all_degree_with_student(int faculty)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@faculty", SqlDbType.Int);
            param[0].Value = faculty;
            Dt = dal.SelectData("all_degree_with_student", param);
            dal.close();
            return Dt;
        }

        public DataTable exam_takers(string material,int year)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@mat", SqlDbType.NVarChar,10);
            param[0].Value = material;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            Dt = dal.SelectData("exam_takers", param);
            dal.close();
            return Dt;
        }


        public DataTable exam_statistics(string material, int year)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@mat", SqlDbType.NVarChar, 10);
            param[0].Value = material;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            Dt = dal.SelectData("exam_statistics", param);
            dal.close();
            return Dt;
        }




        public DataTable success_num(string material, int year)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@mat", SqlDbType.NVarChar, 10);
            param[0].Value = material;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            Dt = dal.SelectData("success_num", param);
            dal.close();
            return Dt;
        }

        public DataTable fail_num(string material, int year)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@mat", SqlDbType.NVarChar, 10);
            param[0].Value = material;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            Dt = dal.SelectData("fail_num", param);
            dal.close();
            return Dt;
        }

        public DataTable replace_fail_degree(string s_id, string m_id)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@s_id", SqlDbType.NVarChar, 10);
            param[0].Value = s_id;
            param[1] = new SqlParameter("@m_id", SqlDbType.NVarChar, 10);
            param[1].Value = m_id;
            Dt = dal.SelectData("replace_fail_degree", param);
            dal.close();
            return Dt;
        }
        public void edit_degree_prac(string student_id, string material_id,  int degree_theoretical, int season, DateTime year_ofDegree, int teach_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@std_id", SqlDbType.NVarChar, 20);
            param[0].Value = student_id;
            param[1] = new SqlParameter("@mat_id", SqlDbType.NVarChar, 20);
            param[1].Value = material_id;
            param[2] = new SqlParameter("@deg_theo", SqlDbType.Int);
            param[2].Value = degree_theoretical;
            param[3] = new SqlParameter("@season", SqlDbType.Int);
            param[3].Value = season;
            param[4] = new SqlParameter("@year_deg", SqlDbType.Date);
            param[4].Value = year_ofDegree;
            param[5] = new SqlParameter("@teach_id", SqlDbType.Int);
            param[5].Value = teach_id;
            DAL.ExecuteCommand("edit_degree_prac", param);
            DAL.close();
        }
        public DataTable get_techer_name_id(string serch)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@serch", SqlDbType.NVarChar, 15);
            param[0].Value = serch;
           Dt = dal.SelectData("get_techer_name_id", param);
            dal.close();
            return Dt;
        }
    }
} 