using Cartegraph.Data.Repository;
using Cartegraph.Models;
using Cartegraph.Models.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartegraph.Business
{
    public interface IIssueService
    {
        IssueTypeData GetAllIssueTypes();

        IssueData GetAllIssues(Issues request);
        IssueInsertResponse CreateIssue(Issues request);
    }
    public class IssuesService : IIssueService
    {
        private IIssueRepository issueRepo;
        public IssuesService(IIssueRepository _issueRepo)
        {
            issueRepo = _issueRepo;
        }

        public IssuesService()
        {
            issueRepo = new IssueRepository();
        }
        public IssueTypeData GetAllIssueTypes()
        {
            IssueTypeData response = new IssueTypeData();
            try
            {
                response.data = issueRepo.GetAllIssueTypes();
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public IssueInsertResponse CreateIssue(Issues request)
        {
            IssueInsertResponse response = new IssueInsertResponse();
            try
            {
                response.data = issueRepo.CreateIssue(request);
            }
            catch(Exception ex)
            {

            }
            return response;
        }

        public IssueData GetAllIssues(Issues request)
        {
            IssueData response = new IssueData();
            try
            {
                response.data = issueRepo.GetAllIssues(request);
            }
            catch (Exception)
            {

            }
            return response;
        }
    }
}
