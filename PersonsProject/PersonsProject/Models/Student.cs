namespace PersonsProject.Models
{
    /// <summary>
    /// Represents a student.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the student.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the grade of the student.
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets the value determining whether the student is in an exceptional state.
        /// </summary>
        public bool Exceptional { get; set; }

        /// <summary>
        /// Gets or sets the value determining whether the student is part of the honor roll.
        /// </summary>
        public bool HonorRoll { get; set; }

        /// <summary>
        /// Gets or sets the value determining whether the student passed the test.
        /// </summary>
        public bool Passed { get; set; }

    }
}
