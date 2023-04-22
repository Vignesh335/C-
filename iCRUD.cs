// interface for all CRUD operations

namespace NSiCRUD
{
    public interface iCRUD
    {
        void AddStudent();
        void ShowStudents();
        void UpdateStudent();
        void DeleteStudent();
        void Exit();
    }
}