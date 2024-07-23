namespace SchoolApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string StudentCode { get; set; }

        public void GenerateStudentCode()
        {
            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
            {
                StudentCode = FirstName.Substring(0, Math.Min(2, FirstName.Length)) + LastName.Substring(0, Math.Min(2, LastName.Length));
            }
        }
    }
}