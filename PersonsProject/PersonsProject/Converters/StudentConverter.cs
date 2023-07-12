using PersonsProject.Models;

namespace PersonsProject.Converters
{
    /// <summary>
    /// Provides methods for converting and processing <see cref="Student"/> objects.
    /// </summary>
    public class StudentConverter
    {
        /// <summary>
        /// Processes a list of given <see cref="Student"/> objects and fills a new list with a new
        /// <see cref="Student"/> objects where 'Exceptional', 'HonorRoll' and 'Passed' values are set.
        /// </summary>
        /// <param name="students">The list of Student objects to process.</param>
        /// <returns>A list of  Student objects.</returns>
        public List<Student> ConvertStudents(List<Student> students)
        {
            return students.Select(student =>
            {
                var result = new Student
                {
                    Name = student.Name,
                    Age = student.Age,
                    Grade = student.Grade
                };

                if (student.Grade > 90)
                {
                    if (student.Age < 21)
                    {
                        result.Exceptional = true;
                    }

                    else
                    {
                        result.HonorRoll = true;
                    }
                }

                else if (student.Grade > 70)
                {
                    result.Passed = true;
                }
                else
                {
                    result.Passed = false;
                }

                return result;
            }).ToList();
        }
    }
}
