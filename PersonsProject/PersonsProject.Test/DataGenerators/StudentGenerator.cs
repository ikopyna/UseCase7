using Bogus;
using PersonsProject.Converters;
using PersonsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsProject.Test.DataGenerators
{
    /// <summary>
    /// Provides methods for creating fake data related to <see cref="Student"/> objects.
    /// </summary>
    public class StudentGenerator
    {
        private readonly Faker<Student> _studentFaker;

        /// <summary>
        /// Constructor for <see cref="StudentGenerator"/>.
        /// </summary>
        public StudentGenerator() {
            var studentFaker = new Faker<Student>()
                .RuleFor(t => t.Name, f => f.Person.FullName)
                .RuleFor(t => t.Age, f => f.Random.Number(1, 60))
                .RuleFor(t => t.Grade, f => f.Random.Number(1, 100));

            _studentFaker = studentFaker;
        }

        /// <summary>
        /// Generates a fake <see cref="Student"/> object.
        /// </summary>
        /// <returns>A fake Student object.</returns>
        public Student CreateStudent()
        {
            return _studentFaker.Generate();
        }

        /// <summary>
        /// Generates a list of fake <see cref="Student"/> objects.
        /// </summary>
        /// <param name="count">The number of Student objects to generate.</param>
        /// <returns>A list of fake Title objects.</returns>
        public List<Student> CreateStudents(int count)
        {
            return _studentFaker.Generate(count);
        }
    }
}
