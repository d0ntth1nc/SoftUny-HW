using System;

namespace CompanyHierarchy
{
    public class Project : IProject
    {
        private string name;
        public DateTime StartDate { get; private set; }
        public ProjectState State { get; private set; }

        public Project(string name, DateTime startDate)
        {
            this.Name = name;
            this.StartDate = startDate;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Cannot be null or empty!");
                this.name = value;
            }
        }

        public void OpenProject()
        {
            this.State = ProjectState.Open;
        }

        public void CloseProject()
        {
            this.State = ProjectState.Closed;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Start date: {1}, Current state: {2}", this.Name, this.StartDate, this.State);
        }
    }
}
