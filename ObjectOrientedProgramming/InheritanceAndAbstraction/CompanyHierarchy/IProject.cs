using System;
namespace CompanyHierarchy
{
    public interface IProject
    {
        void CloseProject();
        string Name { get; set; }
        void OpenProject();
        DateTime StartDate { get; }
        ProjectState State { get; }
    }
}
