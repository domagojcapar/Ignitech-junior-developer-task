namespace SchoolApi.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeacherCode { get; set; }

        public void GenerateTeacherCode()
        {
            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
            {
                TeacherCode = FirstName.Substring(0, Math.Min(2, FirstName.Length)) + LastName.Substring(0, Math.Min(2, LastName.Length));
            }
        }
    }
}