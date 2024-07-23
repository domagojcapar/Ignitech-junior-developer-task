namespace SchoolApi.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int SubjectId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Subject Subject { get; set; }
    }
}