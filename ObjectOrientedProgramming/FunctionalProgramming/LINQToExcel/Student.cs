
namespace LINQToExcel
{
    class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string StudentType { get; set; }
        public int ExamResult { get; set; }
        public int HomeworkSent { get; set; }
        public int HomeworkEvaluated { get; set; }
        public double Teamwork { get; set; }
        public int Attendances { get; set; }
        public double Bonus { get; set; }
        public double Result { get; set; }

        public Student() { }

        public double CalculateResult()
        {
            this.Result = (this.ExamResult + this.HomeworkSent + this.HomeworkEvaluated +
                    this.Teamwork + this.Attendances + this.Bonus) / 5;
            return this.Result;
        }
    }
}
