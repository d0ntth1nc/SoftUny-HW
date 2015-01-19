using System;

namespace HumanStudentWorker
{
    class Worker : Human
    {
        private double weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Week salary must be positive number!");
                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Working hours per day must be positive number!");
                this.workHoursPerDay = value;
            }
        }

        public double MoneyPerHour()
        {
            return WeekSalary / 5 / WorkHoursPerDay;
        }
    }
}