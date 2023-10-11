using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyNotes.Models;
using MyNotes.ViewModels;
using System.Data;
using System.Security.Cryptography.Xml;

namespace MyNotes.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IConfiguration _configuration;

        public TeacherService(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public List<KycFormViewModel> GetStateDistrictName()
        {
            List<KycFormViewModel> list = new List<KycFormViewModel>();

            var con = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetStateNames", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        KycFormViewModel viewModel = new KycFormViewModel();
                        viewModel.ID = Convert.ToInt32(reader.GetValue(0));
                        viewModel.FullName = Convert.ToString(reader.GetValue(1));
                        viewModel.PhoneNumber = Convert.ToInt64(reader.GetValue(2));
                        viewModel.PermaMunicipality = Convert.ToString(reader.GetValue(5));
                        viewModel.PermaWard = Convert.ToInt16(reader.GetValue(6));
                        viewModel.PermaStreet = Convert.ToString(reader.GetValue(7));
                        viewModel.TempState = Convert.ToString(reader.GetValue(8));
                        viewModel.TempDistrict = Convert.ToString(reader.GetValue(9));
                        viewModel.TempMunicipality = Convert.ToString(reader.GetValue(10));
                        viewModel.TempWard = Convert.ToInt16(reader.GetValue(11));
                        viewModel.TempStreet = Convert.ToString(reader.GetValue(12));
                        viewModel.ProfileImage = Convert.ToString(reader.GetValue(13));
                        viewModel.PState = Convert.ToString(reader.GetValue(16));
                        viewModel.PDistrict = Convert.ToString(reader.GetValue(17));
                        viewModel.TState = Convert.ToString(reader.GetValue(18));
                        viewModel.TDistrict = Convert.ToString(reader.GetValue(19));
                        list.Add(viewModel);
                    }
                }
                cmd.Dispose();
            }
            return list;
        }











        public List<TeacherDepartmentViewModel> GetTeacherDepartmentFile()
        {
            List<TeacherDepartmentViewModel> list = new List<TeacherDepartmentViewModel>();
            var conn = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllMembers", connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TeacherDepartmentViewModel viewModel = new TeacherDepartmentViewModel();
                        viewModel.ID = Convert.ToInt16(reader.GetValue(0));
                        viewModel.TeacherID = Convert.ToInt16(reader.GetValue(1));
                        viewModel.DepartmentID = Convert.ToInt16(reader.GetValue(2));
                        viewModel.TeacherName = Convert.ToString(reader.GetValue(3));
                        viewModel.DepartmentName = Convert.ToString(reader.GetValue(4));
                        list.Add(viewModel);
                    }
                }
                command.Dispose();
            }
            return list;
        }




        //public List<TeacherDepartmentViewModel> GetTeacherDepartmentInfo()
        //{
        //    List<TeacherDepartmentViewModel> list = new List<TeacherDepartmentViewModel>();
        //    var conn = _configuration.GetConnectionString("DefaultConnection");
        //    using (SqlConnection connection = new SqlConnection(conn))
        //    {
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("GetAllMembers", connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                TeacherDepartmentViewModel viewModel = new TeacherDepartmentViewModel();
        //                viewModel.ID = Convert.ToInt32(reader.GetValue(0));
        //                viewModel.TeacherID = Convert.ToInt32(reader.GetValue(1));
        //                viewModel.DepartmentID = Convert.ToInt32(reader.GetValue(2));
        //                viewModel.TeacherName = Convert.ToString(reader.GetValue(3));
        //                viewModel.DepartmentName = Convert.ToString(reader.GetValue(4));
        //                list.Add(viewModel);
        //            }
        //        }
        //        command.Dispose();

        //    }
        //    return list;
        //}






        public List<StudentLectureViewModel> GetStudentLectureInfo()
        {
            List<StudentLectureViewModel> list = new List<StudentLectureViewModel>();
            var conn = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllLectures", connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StudentLectureViewModel viewModel = new StudentLectureViewModel();
                        viewModel.ID = (Convert.ToInt32(reader.GetValue(0)));
                        viewModel.StudentID = Convert.ToInt32(reader.GetValue(1));
                        viewModel.LectureID = Convert.ToInt32(reader.GetValue(2));
                        viewModel.StudentName = Convert.ToString(reader.GetValue(3));
                        viewModel.LectureName = Convert.ToString(reader.GetValue(4));
                        list.Add(viewModel);
                    }
                }
                command.Dispose();

            }
            return list;

        }
    }
}
