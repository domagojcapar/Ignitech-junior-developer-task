using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApi.Data;
using SchoolApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolContext _context;

        public SchoolController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllTeachers")]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetAllTeachersAsync()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return Ok(teachers);
        }


        [HttpGet("GetStudentsForTeacher/{teacherCode}")]
        public async Task<ActionResult<IEnumerable<object>>> GetStudentsForTeacherByCode(string teacherCode)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.TeacherCode == teacherCode);
            if (teacher == null)
            {
                return NotFound($"Teacher with code {teacherCode} not found.");
            }

            var studentNames = await _context.Students
                                              .Where(s => s.TeacherId == teacher.Id)
                                              .Select(s => new { s.FirstName, s.LastName })
                                              .ToListAsync();

            if (studentNames == null || !studentNames.Any())
            {
                return NotFound($"No students found for teacher with code {teacherCode}.");
            }

            return Ok(studentNames);
        }


        [HttpGet("GetSubjectsForTeacher/{teacherCode}")]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjectsForTeacherByCode(string teacherCode)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.TeacherCode == teacherCode);
            if (teacher == null)
            {
                return NotFound($"Teacher with code {teacherCode} not found.");
            }

            var subjectNames = await _context.Subjects
                                          .Where(s => s.TeacherId == teacher.Id)
                                          .Select(s => s.Name)
                                          .Distinct()
                                          .ToListAsync();

            if (subjectNames == null || !subjectNames.Any())
            {
                return NotFound($"No subjects found for teacher with code {teacherCode}.");
            }

            return Ok(subjectNames);
        }

        [HttpGet("GetSubjectsForStudent/{studentCode}")]
        public async Task<ActionResult<IEnumerable<string>>> GetSubjectsForStudentByCode(string studentCode)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentCode == studentCode);
            if (student == null)
            {
                return NotFound($"Student with code {studentCode} not found.");
            }

            var subjectNames = await _context.Subjects
                                          .Where(s => s.StudentId == student.Id)
                                          .Select(s => s.Name)
                                          .Distinct()
                                          .ToListAsync();

            if (subjectNames == null || !subjectNames.Any())
            {
                return NotFound($"No subjects found for student with code {studentCode}.");
            }

            return Ok(subjectNames);
        }

        [HttpGet("GetTeacherForStudentSubject")]
        public async Task<ActionResult<string>> GetTeacherForStudentSubject([FromQuery] string studentCode, [FromQuery] string subjectName)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentCode == studentCode);
            if (student == null)
            {
                return NotFound($"Student with code {studentCode} not found.");
            }

            var subject = await _context.Subjects
                                        .Include(s => s.Teacher)
                                        .FirstOrDefaultAsync(s => s.StudentId == student.Id && s.Name == subjectName);
            if (subject == null)
            {
                return NotFound($"Subject {subjectName} for student with code {studentCode} not found.");
            }

            var teacherFullName = $"{subject.Teacher.FirstName} {subject.Teacher.LastName}";

            return Ok(teacherFullName);
        }

        [HttpGet("GetGradesForStudentSubject")]
        public async Task<ActionResult<IEnumerable<int>>> GetGradesForStudentSubject([FromQuery] string studentCode, [FromQuery] string subjectName)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentCode == studentCode);
            if (student == null)
            {
                return NotFound($"Student with code {studentCode} not found.");
            }

            var subject = await _context.Subjects
                                        .FirstOrDefaultAsync(s => s.StudentId == student.Id && s.Name == subjectName);
            if (subject == null)
            {
                return NotFound($"Subject {subjectName} for student with code {studentCode} not found.");
            }

            var grades = await _context.Grades
                                       .Where(g => g.SubjectId == subject.Id)
                                       .Select(g => g.Value)
                                       .ToListAsync();

            if (grades == null || !grades.Any())
            {
                return NotFound($"No grades found for student with code {studentCode} and subject {subjectName}.");
            }

            return Ok(grades);
        }

        [HttpGet("GetAverageGradeForStudentSubject")]
        public async Task<ActionResult<double>> GetAverageGradeForStudentSubject([FromQuery] string studentCode, [FromQuery] string subjectName)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentCode == studentCode);
            if (student == null)
            {
                return NotFound($"Student with code {studentCode} not found.");
            }

            var subject = await _context.Subjects
                                        .FirstOrDefaultAsync(s => s.StudentId == student.Id && s.Name == subjectName);
            if (subject == null)
            {
                return NotFound($"Subject {subjectName} for student with code {studentCode} not found.");
            }

            var grades = await _context.Grades
                                       .Where(g => g.SubjectId == subject.Id)
                                       .Select(g => g.Value)
                                       .ToListAsync();

            if (grades == null || !grades.Any())
            {
                return NotFound($"No grades found for student with code {studentCode} and subject {subjectName}.");
            }

            double average = grades.Average();

            return Ok(average);
        }
    }
}