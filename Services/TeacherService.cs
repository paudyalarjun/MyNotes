using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyNotes.Models;
using MyNotes.ViewModels;
using System.Data;

namespace MyNotes.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IConfiguration _configuration;

        public TeacherService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public List<TeacherDepartmentViewModel> GetTeacherDepartmentInfo()
        {
            List<TeacherDepartmentViewModel> list = new List<TeacherDepartmentViewModel>();
            var conn = _configuration.GetConnectionString("DefaultConnection") ;
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
                        viewModel.ID = Convert.ToInt32(reader.GetValue(0));
                        viewModel.TeacherID = Convert.ToInt32(reader.GetValue(1));
                        viewModel.DepartmentID = Convert.ToInt32(reader.GetValue(2));
                        viewModel.TeacherName = Convert.ToString(reader.GetValue(3));
                        viewModel.DepartmentName = Convert.ToString(reader.GetValue(4));
                        list.Add(viewModel);
                    }
                }
                command.Dispose();

            }
            return list;
        }

    }
}
