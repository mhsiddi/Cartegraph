using Cartegraph.Core;
using Cartegraph.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartegraph.Data.Repository
{
    public interface IIssueRepository
    {
        IEnumerable<Issues> GetAllIssues(Issues request);

        IEnumerable<IssueTypes> GetAllIssueTypes();

        int CreateIssue(Issues request);
    }
    public class IssueRepository : IIssueRepository
    {
        public int CreateIssue(Issues request)
        {
            List<Tuple<string, object>> parameters = new List<Tuple<string, object>>();

            parameters.Add(new Tuple<string, object>("IssueType", request.IssueTypeID));
            parameters.Add(new Tuple<string, object>("Details", request.Details));
            parameters.Add(new Tuple<string, object>("Location", request.Location));
            parameters.Add(new Tuple<string, object>("ReportedBy", request.ReportedBy));

            parameters.Add(new Tuple<string, object>("CFirst", request.citizen.FirstName));
            parameters.Add(new Tuple<string, object>("CLast", request.citizen.LastName));
            parameters.Add(new Tuple<string, object>("CEmail", request.citizen.Email));
            parameters.Add(new Tuple<string, object>("CPhone", request.citizen.Phone));

            int result = SQLUtil.ExecuteNonQuery("CreateIssue", parameters);

            return result;
        }

        public IEnumerable<Issues> GetAllIssues(Issues request)
        {
            List<Issues> issuesList = new List<Issues>();
            List<Tuple<string, object>> parameters = new List<Tuple<string, object>>();

            DataTable result = SQLUtil.ExecuteStoredProcedure("GetAllIssues", parameters);

            issuesList = (from c in result.AsEnumerable()
                          select new Issues()
                          {
                              IssueID = c.Field<int>("IssueID"),
                              Details = c.Field<string>("Details"),
                              IssueType = c.Field<string>("IssueType"),
                              Location = c.Field<string>("Location"),
                              ReportedBy = c.Field<int>("ReportedBy"),
                              EmployeeName = c.Field<string>("EmployeeName"),
                              CitizenName = c.Field<string>("CitizenName"),
                              CitizenEmail = c.Field<string>("CEmail"),
                              CitizenPhone = c.Field<string>("CPhone")

                          }).ToList();

            return issuesList;

        }

        public IEnumerable<IssueTypes> GetAllIssueTypes()
        {
            List<IssueTypes> issueTypesList = new List<IssueTypes>();
            List<Tuple<string, object>> parameters = new List<Tuple<string, object>>();

            DataTable result = SQLUtil.ExecuteStoredProcedure("GetIssueTypes", parameters);

            issueTypesList = (
                                from c in result.AsEnumerable()
                                select new IssueTypes()
                                {
                                    IssueID = c.Field<int>("IssueTypeID"),
                                    IssueType = c.Field<string>("IssueType")
                                }).ToList();

            return issueTypesList;
        }
    }
}
