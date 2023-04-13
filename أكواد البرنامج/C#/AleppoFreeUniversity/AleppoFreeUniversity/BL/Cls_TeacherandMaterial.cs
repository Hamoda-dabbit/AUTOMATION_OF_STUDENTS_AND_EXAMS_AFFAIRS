using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace AleppoFreeUniversity.BL
{
    class Cls_TeacherandMaterial
    {
        public DataTable Get_all_teacher()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = dal.SelectData("Get_all_teacher", null);
            dal.close();
            return Dt;
        }
        public void add_teacher(int id, string teacher_name, int scientific_rank, int @num_of_material)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@teach_name", SqlDbType.NVarChar, 20);
            param[1].Value = teacher_name;
            param[2] = new SqlParameter("@scien_ran", SqlDbType.Int);
            param[2].Value = scientific_rank;
            param[3] = new SqlParameter("@num_of_mat", SqlDbType.Int);
            param[3].Value = num_of_material;
            DAL.ExecuteCommand("add_teacher", param);
            DAL.close();
        }

        public void edit_teacher(int id, string teacher_name, int scientific_rank, int @num_of_material)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@teach_name", SqlDbType.NVarChar, 20);
            param[1].Value = teacher_name;
            param[2] = new SqlParameter("@scien_ran", SqlDbType.Int);
            param[2].Value = scientific_rank;
            param[3] = new SqlParameter("@num_of_mat", SqlDbType.Int);
            param[3].Value = num_of_material;
            DAL.ExecuteCommand("edit_teacher", param);
            DAL.close();
        }

        public void delete_teacher(int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            DAL.ExecuteCommand("delete_teacher", param);
            DAL.close();
        }

        public DataTable search_teacher_by_id(int id)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            Dt = dal.SelectData("search_teacher_by_id", param);
            dal.close();
            return Dt;
        }

        public DataTable search_teacher_by_name(string teacher_name)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@teach_name", SqlDbType.NVarChar, 20);
            param[0].Value = teacher_name;
            Dt = dal.SelectData("search_teacher_by_name", param);
            dal.close();
            return Dt;
        }


        public DataTable Get_material()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = dal.SelectData("Get_Material", null);
            dal.close();
            return Dt;
        }

        public void add_material(string id, string mat_name, int fac, int @year, bool seas_mat)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar,12);
            param[0].Value = id;
            param[1] = new SqlParameter("@mat_name", SqlDbType.NVarChar, 30);
            param[1].Value = mat_name;
            param[2] = new SqlParameter("@fac", SqlDbType.Int);
            param[2].Value = fac;
            param[3] = new SqlParameter("@year", SqlDbType.Int);
            param[3].Value = year;
            param[4] = new SqlParameter("@seas_mat", SqlDbType.Bit);
            param[4].Value = seas_mat;
            DAL.ExecuteCommand("add_material", param);
            DAL.close();
        }

        public void edit_material(string id,string mat_name, int fac, int @year, bool seas_mat)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@mat_id", SqlDbType.NVarChar, 12);
            param[0].Value = id;
            param[1] = new SqlParameter("@mat_name", SqlDbType.NVarChar, 30);
            param[1].Value = mat_name;
            param[2] = new SqlParameter("@fac", SqlDbType.Int);
            param[2].Value = fac;
            param[3] = new SqlParameter("@year", SqlDbType.Int);
            param[3].Value = year;
            param[4] = new SqlParameter("@seas_mat", SqlDbType.Bit);
            param[4].Value = seas_mat;
            DAL.ExecuteCommand("edit_material", param);
            DAL.close();
        }

        public void delete_material(string id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar,12);
            param[0].Value = id;
            DAL.ExecuteCommand("delete_material", param);
            DAL.close();
        }

        public DataTable search_material_by_id(string id)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar,12);
            param[0].Value = id;
            Dt = dal.SelectData("search_material_by_id", param);
            dal.close();
            return Dt;
        }

        public DataTable search_material_by_name(string material_name)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@mat_name", SqlDbType.NVarChar, 30);
            param[0].Value = material_name;
            Dt = dal.SelectData("search_material_by_name", param);
            dal.close();
            return Dt;
        }


    }
}