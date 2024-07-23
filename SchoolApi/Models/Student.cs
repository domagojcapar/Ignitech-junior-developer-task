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
    }
}