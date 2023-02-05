using System.Linq;

namespace lab_6_odata
{
    public class StudentNotesModify : IStudentNotesModify
    {
        public void Insert(string name)
        {
            var context = new WsPINEntities();
            context.Students.Add(new Student() { Name = name });
            context.SaveChanges();
        }

        public void Update(int id, string name)
        {
            var context = new WsPINEntities();
            var student = context.Students.SingleOrDefault(x => x.Id == id);

            if (student != null)
            {
                student.Name = name;
                context.SaveChanges();
            }
        }
    }
}
