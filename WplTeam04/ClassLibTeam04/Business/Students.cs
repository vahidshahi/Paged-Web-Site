using ClassLibTeam04.Data;
using ClassLibTeam04.Data.Framework;
using ClassLibTeam04.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam04.Business
{
    public static class Students
    {
        public static DataView GetStudents()
        {
            var dv = new DataView();
            try
            {
                var studentdata = new StudentsData();
                var result = studentdata.select();
                dv = result.DataTable.DefaultView;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
                throw;
            }
            return dv;
        }
        public static DataTable GetStudentsDataTable(string firstname)
        {
            var dt = new DataTable();
            try
            {
                var studentdata = new StudentsData();
                
                var result = studentdata.SelectQueryFirstName(firstname);
                dt = result.DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
                throw;
            }
            return dt;

        }
        public static InsertResult AddStudent(Student student)
        {
            var result = new InsertResult();
            try
            {
                //Business.Students.AddStudent
                //Data.StudentsData.Insert
                //Frmwrk.SqlCommands.InsertRecord
                var studentsData = new StudentsData();
                studentsData.Insert(student);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}

