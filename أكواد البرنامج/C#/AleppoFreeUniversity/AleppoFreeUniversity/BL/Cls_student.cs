using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AleppoFreeUniversity.BL
{
    class Cls_student
    {
        public void add_student(string id, string first_name, string last_name, string father, string mother, bool gender, string birth_city, DateTime birth_date, string box_Number, int faculty, int year, string tel, int Certificate_Sec, string Certifcate_Source, DateTime Certificate_date, DateTime yearOfAdmission, bool typeOfAdmission, string Department)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 20);
            param[0].Value = id;
            param[1] = new SqlParameter("@first_name", SqlDbType.NVarChar, 20);
            param[1].Value = first_name;
            param[2] = new SqlParameter("@last_name", SqlDbType.NVarChar, 20);
            param[2].Value = last_name;
            param[3] = new SqlParameter("@father", SqlDbType.NVarChar, 20);
            param[3].Value = father;
            param[4] = new SqlParameter("@mother", SqlDbType.NVarChar, 20);
            param[4].Value = mother;
            param[5] = new SqlParameter("@gender", SqlDbType.Bit);
            param[5].Value = gender;
            param[6] = new SqlParameter("@birth_city", SqlDbType.NVarChar, 20);
            param[6].Value = birth_city;
            param[7] = new SqlParameter("@birth_date", SqlDbType.Date);
            param[7].Value = birth_date;
            param[8] = new SqlParameter("@box_Number", SqlDbType.NVarChar, 20);
            param[8].Value = box_Number;
            param[9] = new SqlParameter("@faculty", SqlDbType.Int);
            param[9].Value = faculty;
            param[10] = new SqlParameter("@year", SqlDbType.Int);
            param[10].Value = year;
            param[11] = new SqlParameter("@tel", SqlDbType.NVarChar, 20);
            param[11].Value = tel;
            param[12] = new SqlParameter("@Certificate_Sec", SqlDbType.Int);
            param[12].Value = Certificate_Sec;
            param[13] = new SqlParameter("@Certifcate_Source", SqlDbType.NVarChar, 50);
            param[13].Value = Certifcate_Source;
            param[14] = new SqlParameter("@Certificate_date", SqlDbType.Date);
            param[14].Value = Certificate_date;
            param[15] = new SqlParameter("@yearOfAdmission", SqlDbType.Date);
            param[15].Value = yearOfAdmission;
            param[16] = new SqlParameter("@typeOfAdmission", SqlDbType.Bit);
            param[16].Value = typeOfAdmission;
            param[17] = new SqlParameter("@Department", SqlDbType.NVarChar, 50);
            param[17].Value = Department;
            DAL.ExecuteCommand("add_student", param);
            DAL.close();
        }
        public void add_student_detile(string id, byte[] pictur, int section
          , string second_language, bool Matrial_status, string personal_ID, string husband_name, string husband_work, int Children_Number, string Children_age, bool migration,
            DateTime migration_date, string father_work, string Health_status, string personal_notes, string email, string address_original, string address_current, string Certifcate_state, string Certifcate_id,
            int Certifcate_total, byte[] Certifcate_total_document, string old_universirt, string old_faculty, string old_Department, DateTime old_yearOfAdmission, DateTime date_ofStop, int old_yearStudy,
            string Old_documents_note, byte[] Old_documents, string old_Institute, string old_Institute_department, DateTime old_Institute_date, int old_Institute_seson, string old_Institute_total, string old_Institute_rating)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[36];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 15);
            param[0].Value = id;
            param[1] = new SqlParameter("@pictur", SqlDbType.Image);
            if (pictur != null)
            { param[1].Value = pictur; }
            else { param[1].Value = DBNull.Value; }
            param[2] = new SqlParameter("@section", SqlDbType.Int);
            param[2].Value = section;
            param[3] = new SqlParameter("@second_language", SqlDbType.NVarChar, 15);
            param[3].Value = second_language;
            param[4] = new SqlParameter("@Matrial_status", SqlDbType.Bit);
            param[4].Value = Matrial_status;
            param[5] = new SqlParameter("@personal_ID", SqlDbType.NVarChar, 15);
            param[5].Value = personal_ID;
            param[6] = new SqlParameter("@husband_name", SqlDbType.NVarChar, 15);
            param[6].Value = husband_name;
            param[7] = new SqlParameter("@husband_work", SqlDbType.NVarChar, 15);
            param[7].Value = husband_work;
            param[8] = new SqlParameter("@Children_Number", SqlDbType.Int);
            param[8].Value = Children_Number;
            param[9] = new SqlParameter("@Children_age", SqlDbType.NVarChar, 15);
            param[9].Value = Children_age;
            param[10] = new SqlParameter("@migration", SqlDbType.Bit);
            param[10].Value = migration;
            param[11] = new SqlParameter("@migration_date", SqlDbType.Date);
            param[11].Value = migration_date;
            param[12] = new SqlParameter("@father_work", SqlDbType.NVarChar, 15);
            param[12].Value = father_work;
            param[13] = new SqlParameter("@Health_status", SqlDbType.NVarChar, 50);
            param[13].Value = Health_status;
            param[14] = new SqlParameter("@personal_notes", SqlDbType.NVarChar, 50);
            param[14].Value = personal_notes;
            param[15] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            param[15].Value = email;
            param[16] = new SqlParameter("@address_original", SqlDbType.NVarChar, 50);
            param[16].Value = address_original;
            param[17] = new SqlParameter("@address_current", SqlDbType.NVarChar, 50);
            param[17].Value = address_current;

            param[18] = new SqlParameter("@Certifcate_state", SqlDbType.NVarChar, 15);
            param[18].Value = Certifcate_state;
            param[19] = new SqlParameter("@Certifcate_id", SqlDbType.NVarChar, 50);
            param[19].Value = Certifcate_id;
            param[20] = new SqlParameter("@Certifcate_total", SqlDbType.Int);
            param[20].Value = Certifcate_total;
            param[21] = new SqlParameter("@Certifcate_total_document", SqlDbType.VarBinary);
            if (Certifcate_total_document != null)
            { param[21].Value = Certifcate_total_document; }
            else { param[21].Value = DBNull.Value; }
            param[22] = new SqlParameter("@old_universirt", SqlDbType.NVarChar, 25);
            param[22].Value = old_universirt;
            param[23] = new SqlParameter("@old_faculty", SqlDbType.NVarChar, 25);
            param[23].Value = old_faculty;
            param[24] = new SqlParameter("@old_Department", SqlDbType.NVarChar, 25);
            param[24].Value = old_Department;
            param[25] = new SqlParameter("@old_yearOfAdmission", SqlDbType.Date);
            param[25].Value = old_yearOfAdmission;
            param[26] = new SqlParameter("@date_ofStop", SqlDbType.Date);
            param[26].Value = date_ofStop;
            param[27] = new SqlParameter("@old_yearStudy", SqlDbType.Int);
            param[27].Value = old_yearStudy;
            param[28] = new SqlParameter("@Old_documents_note", SqlDbType.NVarChar, 50);
            param[28].Value = Old_documents_note;
            param[29] = new SqlParameter("@Old_documents", SqlDbType.VarBinary);
            if (Old_documents != null)
            { param[29].Value = Old_documents; }
            else { param[29].Value = DBNull.Value; }
            param[30] = new SqlParameter("@old_Institute", SqlDbType.NVarChar, 25);
            param[30].Value = old_Institute;
            param[31] = new SqlParameter("@old_Institute_department", SqlDbType.NVarChar, 15);
            param[31].Value = old_Institute_department;
            param[32] = new SqlParameter("@old_Institute_date", SqlDbType.Date);
            param[32].Value = old_Institute_date;
            param[33] = new SqlParameter("@old_Institute_seson", SqlDbType.Int);
            param[33].Value = old_Institute_seson;
            param[34] = new SqlParameter("@old_Institute_total", SqlDbType.Int);
            param[34].Value = old_Institute_total;
            param[35] = new SqlParameter("@old_Institute_rating", SqlDbType.NVarChar, 15);
            param[35].Value = old_Institute_rating;

            DAL.ExecuteCommand("add_student_detile", param);
            DAL.close();
        }
        public void edit_student(string id, string first_name, string last_name, string father, string mother, bool gender, string birth_city,
            DateTime birth_date, string box_Number, int faculty, int year, string tel, int Certificate_Sec, string Certifcate_Source,
            DateTime Certificate_date, DateTime yearOfAdmission, bool typeOfAdmission, string Department,
            byte[] pictur, int section
        , string second_language, bool Matrial_status, string personal_ID, string husband_name, string husband_work, int Children_Number, string Children_age, bool migration,
          DateTime migration_date, string father_work, string Health_status, string personal_notes, string email, string address_original, string address_current, string Certifcate_state, string Certifcate_id,
            int Certifcate_total/*,byte[] Certifcate_total_document*/, string old_universirt, string old_faculty, string old_Department, DateTime old_yearOfAdmission, DateTime date_ofStop, int old_yearStudy,
            string Old_documents_note/*,byte[] Old_documents*/, string old_Institute, string old_Institute_department, DateTime old_Institute_date, int old_Institute_seson, int old_Institute_total, string old_Institute_rating)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[51];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 20);
            param[0].Value = id;
            param[1] = new SqlParameter("@first_name", SqlDbType.NVarChar, 20);
            param[1].Value = first_name;
            param[2] = new SqlParameter("@last_name", SqlDbType.NVarChar, 20);
            param[2].Value = last_name;
            param[3] = new SqlParameter("@father", SqlDbType.NVarChar, 20);
            param[3].Value = father;
            param[4] = new SqlParameter("@mother", SqlDbType.NVarChar, 20);
            param[4].Value = mother;
            param[5] = new SqlParameter("@gender", SqlDbType.Bit);
            param[5].Value = gender;
            param[6] = new SqlParameter("@birth_city", SqlDbType.NVarChar, 20);
            param[6].Value = birth_city;
            param[7] = new SqlParameter("@birth_date", SqlDbType.Date);
            param[7].Value = birth_date;
            param[8] = new SqlParameter("@box_Number", SqlDbType.NVarChar, 20);
            param[8].Value = box_Number;
            param[9] = new SqlParameter("@faculty", SqlDbType.Int);
            param[9].Value = faculty;
            param[10] = new SqlParameter("@year", SqlDbType.Int);
            param[10].Value = year;
            param[11] = new SqlParameter("@tel", SqlDbType.NVarChar, 20);
            param[11].Value = tel;
            param[12] = new SqlParameter("@Certificate_Sec", SqlDbType.Int);
            param[12].Value = Certificate_Sec;
            param[13] = new SqlParameter("@Certifcate_Source", SqlDbType.NVarChar, 50);
            param[13].Value = Certifcate_Source;
            param[14] = new SqlParameter("@Certificate_date", SqlDbType.Date);
            param[14].Value = Certificate_date;
            param[15] = new SqlParameter("@yearOfAdmission", SqlDbType.Date);
            param[15].Value = yearOfAdmission;
            param[16] = new SqlParameter("@typeOfAdmission", SqlDbType.Bit);
            param[16].Value = typeOfAdmission;
            param[17] = new SqlParameter("@Department", SqlDbType.NVarChar, 50);
            param[17].Value = Department;

            param[18] = new SqlParameter("@pictur", SqlDbType.Image);
            if (pictur != null)
            { param[18].Value = pictur; }
            else { param[18].Value = DBNull.Value; }
            param[19] = new SqlParameter("@section", SqlDbType.Int);
            param[19].Value = section;
            param[20] = new SqlParameter("@second_language", SqlDbType.NVarChar, 15);
            param[20].Value = second_language;
            param[21] = new SqlParameter("@Matrial_status", SqlDbType.Bit);
            param[21].Value = Matrial_status;
            param[22] = new SqlParameter("@personal_ID", SqlDbType.NVarChar, 15);
            param[22].Value = personal_ID;
            param[23] = new SqlParameter("@husband_name", SqlDbType.NVarChar, 15);
            param[23].Value = husband_name;
            param[24] = new SqlParameter("@husband_work", SqlDbType.NVarChar, 15);
            param[24].Value = husband_work;
            param[25] = new SqlParameter("@Children_Number", SqlDbType.Int);
            param[25].Value = Children_Number;
            param[26] = new SqlParameter("@Children_age", SqlDbType.NVarChar, 15);
            param[26].Value = Children_age;
            param[27] = new SqlParameter("@migration", SqlDbType.Bit);
            param[27].Value = migration;
            param[28] = new SqlParameter("@migration_date", SqlDbType.Date);
            param[28].Value = migration_date;
            param[29] = new SqlParameter("@father_work", SqlDbType.NVarChar, 15);
            param[29].Value = father_work;
            param[30] = new SqlParameter("@Health_status", SqlDbType.NVarChar, 50);
            param[30].Value = Health_status;
            param[31] = new SqlParameter("@personal_notes", SqlDbType.NVarChar, 50);
            param[31].Value = personal_notes;
            param[32] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
            param[32].Value = email;
            param[33] = new SqlParameter("@address_original", SqlDbType.NVarChar, 50);
            param[33].Value = address_original;
            param[34] = new SqlParameter("@address_current", SqlDbType.NVarChar, 50);
            param[34].Value = address_current;

            param[35] = new SqlParameter("@Certifcate_state", SqlDbType.NVarChar, 15);
            param[35].Value = Certifcate_state;
            param[36] = new SqlParameter("@Certifcate_id", SqlDbType.NVarChar, 50);
            param[36].Value = Certifcate_id;
            param[37] = new SqlParameter("@Certifcate_total", SqlDbType.Int);
            param[37].Value = Certifcate_total;
            //      param[21] = new SqlParameter("@Certifcate_total_document", SqlDbType.VarBinary);
            //     param[21].Value = Certifcate_total_document;
            param[38] = new SqlParameter("@old_universirt", SqlDbType.NVarChar, 25);
            param[38].Value = old_universirt;
            param[39] = new SqlParameter("@old_faculty", SqlDbType.NVarChar, 25);
            param[39].Value = old_faculty;
            param[40] = new SqlParameter("@old_Department", SqlDbType.NVarChar, 25);
            param[40].Value = old_Department;
            param[41] = new SqlParameter("@old_yearOfAdmission", SqlDbType.Date);
            param[41].Value = old_yearOfAdmission;
            param[42] = new SqlParameter("@date_ofStop", SqlDbType.Date);
            param[42].Value = date_ofStop;
            param[43] = new SqlParameter("@old_yearStudy", SqlDbType.Int);
            param[43].Value = old_yearStudy;
            param[44] = new SqlParameter("@Old_documents_note", SqlDbType.NVarChar, 50);
            param[44].Value = Old_documents_note;
            //      param[45] = new SqlParameter("@Old_documents", SqlDbType.VarBinary);
            //     param[55].Value = Old_documents;
            param[45] = new SqlParameter("@old_Institute", SqlDbType.NVarChar, 25);
            param[45].Value = old_Institute;
            param[46] = new SqlParameter("@old_Institute_department", SqlDbType.NVarChar, 15);
            param[46].Value = old_Institute_department;
            param[47] = new SqlParameter("@old_Institute_date", SqlDbType.Date);
            param[47].Value = old_Institute_date;
            param[48] = new SqlParameter("@old_Institute_seson", SqlDbType.Int);
            param[48].Value = old_Institute_seson;
            param[49] = new SqlParameter("@old_Institute_total", SqlDbType.Int);
            param[49].Value = old_Institute_total;
            param[50] = new SqlParameter("@old_Institute_rating", SqlDbType.NVarChar, 15);
            param[50].Value = old_Institute_rating;

            DAL.ExecuteCommand("edit_student", param);
            DAL.close();
        }
        public DataTable chek_student_detile(string id)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 20);
            param[0].Value = id;

            Dt = dal.SelectData("chek_student_detile", param);
            dal.close();
            return Dt;
        }

        public void delet_student(string id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 20);
            param[0].Value = id;
            DAL.ExecuteCommand("delete_student", param);
            DAL.close();
        }
        public DataTable GET_All_Student()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = dal.SelectData("Get_All_student", null);
            dal.close();
            return Dt;
        }
        public DataTable Get_All_student_inYear(int fuclty ,int year)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@fuclty", SqlDbType.Int);
            param[0].Value = fuclty;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = year;
            Dt = DAL.SelectData("Get_All_student_inYear", param);
            DAL.close();
            return Dt;
        }

        public DataTable Search_Student_name(string fname)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@first_name", SqlDbType.NVarChar, 50);
            param[0].Value = fname;
            Dt = dal.SelectData("Search_Student_name", param);
            dal.close();
            return Dt;
        }
        public DataTable GET_DETILE_STUD(string id)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 20);
            param[0].Value = id;

            Dt = dal.SelectData("Student_detiles", param);
            dal.close();
            return Dt;
        }

        public DataTable GET_stdnum(string name)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;
            Dt = dal.SelectData("Get_stdnum", param);
            dal.close();
            return Dt;
        }

        public DataTable GET_stdname(string stdnum)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@stdnum", SqlDbType.NVarChar, 20);
            param[0].Value = stdnum;
            Dt = dal.SelectData("Get_stdname", param);
            dal.close();
            return Dt;
        }

        public DataTable Search_by3id(string id, string facluty)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 20);
            param[0].Value = id;
            param[1] = new SqlParameter("@facluty", SqlDbType.NVarChar, 20);
            param[1].Value = facluty;
            Dt = dal.SelectData("Search_by3id", param);
            dal.close();
            return Dt;
        }

        public DataTable get_all_fees()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = dal.SelectData("get_all_fees", null);
            dal.close();
            return Dt;
        }

        public void add_fees(string student_id, int full_year_fees, float fees_paid, bool @does_paid, float discount_rate,
            float @amount_of_discount, float @year_fees_after_discount, string reason_for_discount, float old_fees_unpaid, int academic_year,
            string stady_year, string voucher_number, DateTime date_paid, string notes)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@student_id", SqlDbType.NVarChar, 15);
            param[0].Value = student_id;
            param[1] = new SqlParameter("@full_year_fees", SqlDbType.Int);
            param[1].Value = full_year_fees;
            param[2] = new SqlParameter("@fees_paid", SqlDbType.Float);
            param[2].Value = fees_paid;
            param[3] = new SqlParameter("@does_paid", SqlDbType.Bit);
            param[3].Value = does_paid;
            param[4] = new SqlParameter("@discount_rate", SqlDbType.Float);
            param[4].Value = discount_rate;
            param[5] = new SqlParameter("@amount_of_discount", SqlDbType.Float);
            param[5].Value = amount_of_discount;
            param[6] = new SqlParameter("@year_fees_after_discount", SqlDbType.Float);
            param[6].Value = year_fees_after_discount;
            param[7] = new SqlParameter("@reason_for_discount", SqlDbType.NVarChar, 20);
            param[7].Value = reason_for_discount;
            param[8] = new SqlParameter("@old_fees_unpaid", SqlDbType.Float);
            param[8].Value = old_fees_unpaid;
            param[9] = new SqlParameter("@academic_year", SqlDbType.Int);
            param[9].Value = academic_year;
            param[10] = new SqlParameter("@stady_year", SqlDbType.NVarChar, 20);
            param[10].Value = stady_year;
            param[11] = new SqlParameter("@voucher_number", SqlDbType.NVarChar, 20);
            param[11].Value = voucher_number;
            param[12] = new SqlParameter("@date_paid", SqlDbType.Date);
            param[12].Value = date_paid;
            param[13] = new SqlParameter("@notes", SqlDbType.NVarChar, 50);
            param[13].Value = notes;
            DAL.ExecuteCommand("add_fees", param);
            DAL.close();
        }

        public void edit_fees(string student_id, int full_year_fees, float fees_paid, bool @does_paid, float discount_rate,
    float @amount_of_discount, float @year_fees_after_discount, string reason_for_discount, float old_fees_unpaid, int academic_year,
    string stady_year, string voucher_number, DateTime date_paid, string notes)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@student_id", SqlDbType.NVarChar, 15);
            param[0].Value = student_id;
            param[1] = new SqlParameter("@full_year_fees", SqlDbType.Int);
            param[1].Value = full_year_fees;
            param[2] = new SqlParameter("@fees_paid", SqlDbType.Float);
            param[2].Value = fees_paid;
            param[3] = new SqlParameter("@does_paid", SqlDbType.Bit);
            param[3].Value = does_paid;
            param[4] = new SqlParameter("@discount_rate", SqlDbType.Float);
            param[4].Value = discount_rate;
            param[5] = new SqlParameter("@amount_of_discount", SqlDbType.Float);
            param[5].Value = amount_of_discount;
            param[6] = new SqlParameter("@year_fees_after_discount", SqlDbType.Float);
            param[6].Value = year_fees_after_discount;
            param[7] = new SqlParameter("@reason_for_discount", SqlDbType.NVarChar, 20);
            param[7].Value = reason_for_discount;
            param[8] = new SqlParameter("@old_fees_unpaid", SqlDbType.Float);
            param[8].Value = old_fees_unpaid;
            param[9] = new SqlParameter("@academic_year", SqlDbType.Int);
            param[9].Value = academic_year;
            param[10] = new SqlParameter("@stady_year", SqlDbType.NVarChar, 20);
            param[10].Value = stady_year;
            param[11] = new SqlParameter("@voucher_number", SqlDbType.NVarChar, 20);
            param[11].Value = voucher_number;
            param[12] = new SqlParameter("@date_paid", SqlDbType.Date);
            param[12].Value = date_paid;
            param[13] = new SqlParameter("@notes", SqlDbType.NVarChar, 50);
            param[13].Value = notes;
            DAL.ExecuteCommand("edit_fess", param);
            DAL.close();
        }


        public void delete_fees(string student_id, int academic_year, string stady_year)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@student_id", SqlDbType.NVarChar,15);
            param[0].Value = student_id;
            param[1] = new SqlParameter("@academic_year", SqlDbType.Int);
            param[1].Value = academic_year;
            param[2] = new SqlParameter("@stady_year", SqlDbType.NVarChar, 20);
            param[2].Value = stady_year;

            DAL.ExecuteCommand("delete_fees", param);
            DAL.close();
        }

        public DataTable get_std_fees(string id_std)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_std", SqlDbType.NVarChar, 50);
            param[0].Value = id_std;
            Dt = dal.SelectData("get_std_fees", param);
            dal.close();
            return Dt;
        }

        public DataTable success_year( int n_of_mat,int year , int fuclty)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@year", SqlDbType.Int);
            param[0].Value = year;
            param[1] = new SqlParameter("@n_of_mat", SqlDbType.Int);
            param[1].Value = n_of_mat;
            param[2] = new SqlParameter("@fuclty", SqlDbType.Int);
            param[2].Value = fuclty;


            Dt = dal.SelectData("success_year", param);
            dal.close();
            return Dt;
        }
        public DataTable not_success_year(int n_of_mat, int year ,int fuclty)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3 ];
            param[0] = new SqlParameter("@year", SqlDbType.Int);
            param[0].Value = year;
            param[1] = new SqlParameter("@n_of_mat", SqlDbType.Int);
            param[1].Value = n_of_mat;
            param[2] = new SqlParameter("@fuclty", SqlDbType.Int);
            param[2].Value = fuclty;

            Dt = dal.SelectData("not_success_year", param);
            dal.close();
            return Dt;
        }

        public DataTable success_year_ok(int n_of_mat, int year, int fuclty)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@year", SqlDbType.Int);
            param[0].Value = year;
            param[1] = new SqlParameter("@n_of_mat", SqlDbType.Int);
            param[1].Value = n_of_mat;
            param[2] = new SqlParameter("@fuclty", SqlDbType.Int);
            param[2].Value = fuclty;
            Dt = dal.SelectData("success_year_ok", param);
            dal.close();
            return Dt;
        }
        public DataTable all_fees_with_student(int fuculty, int year)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@fuculty", SqlDbType.Int);
            param[0].Value = fuculty;
            param[1] = new SqlParameter("@year", SqlDbType.Int);
            param[1].Value = @year;
            Dt = dal.SelectData("all_fees_with_student", param);
            dal.close();
            return Dt;
        }
    }
}