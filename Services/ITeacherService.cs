using MyNotes.ViewModels;

namespace MyNotes.Services
{
    public interface ITeacherService
    {
        List<TeacherDepartmentViewModel> GetTeacherDepartmentFile();
        List<StudentLectureViewModel> GetStudentLectureInfo();
        List<KycFormViewModel> GetStateDistrictName();
    }
}
