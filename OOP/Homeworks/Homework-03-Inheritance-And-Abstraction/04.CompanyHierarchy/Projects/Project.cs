namespace _04.CompanyHierarchy.Projects
{
    using System;
    using Contracts;

    class Project : IProject
    {
        private string projectName;

        public Project(string projectName, DateTime projectStartDate, ProjectState projectState, string details = null)
        {
            this.ProjectName = projectName;
            this.ProjectStartDate = projectStartDate;
            this.ProjectState = projectState;
            this.Details = details;
        }

        public Project(string projectName, DateTime projectStartDate, string details = null)
            : this(projectName, projectStartDate, ProjectState.Open, details)
        {
        }

        public Project(string projectName, ProjectState projectState, string details = null)
            : this(projectName, DateTime.Now, projectState, details)
        {
        }

        public Project(string projectName, string details = null)
            : this(projectName, DateTime.Now, ProjectState.Open, details)
        {
        }

        public string ProjectName
        {
            get
            {
                return this.projectName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("projectName", "Project name cannot be empty.");
                }

                this.projectName = value;
            }
        }

        public DateTime ProjectStartDate { get; set; }

        public string Details { get; set; }

        public ProjectState ProjectState { get; private set; }

        public void CloseProject()
        {
            this.ProjectState = ProjectState.Closed;
        }

        public override string ToString()
        {
            return string.Format(
                "Project: {0} (started: {1}, status: {3}) - {2}",
                this.ProjectName,
                this.ProjectStartDate.Date,
                this.Details,
                this.ProjectState);
        }
    }
}
