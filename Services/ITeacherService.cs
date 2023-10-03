using MyNotes.ViewModels;

namespace MyNotes.Services
{
    public interface ITeacherService
    {
        List<TeacherDepartmentViewModel> GetTeacherDepartmentInfo();
        List<StudentLectureViewModel> GetStudentLectureInfo();
    }
}
