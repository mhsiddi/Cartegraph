using Cartegraph.Models;

namespace Cartegraph.Models
{
    public class Issues
    {
        public int IssueID { get; set; }

        public int IssueTypeID { get; set; }
        public string IssueType { get; set; }

        public string Details { get; set; }

        public string Location { get; set; }

        public int ReportedBy { get; set; }

        public string EmployeeName { get; set; }

        public Citizens citizen { get; set; }

        public string CitizenName { get; set; }

        public string CitizenEmail { get; set; }

        public string CitizenPhone { get; set; }

        public Issues()
        {
            citizen = new Citizens();
        }
    }
}