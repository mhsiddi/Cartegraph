using Cartegraph.Business;
using Cartegraph.Models;
using Cartegraph.Models.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cartegraph.Controllers
{
    public class IssuesController : Controller
    {
        private IIssueService issueService;

        public IssuesController(IIssueService _issueService)
        {

            issueService = _issueService;
        }

        public IssuesController()
        {
            issueService = new IssuesService();
        }
        // GET: Issues
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OpenPopUp()
        {

            return PartialView("AddIssue");
        }

        public ActionResult GetIssueTypes()
        {
            List<IssueTypes> issuesList = new List<IssueTypes>();

            issuesList = issueService.GetAllIssueTypes().data.Select(w => new IssueTypes()
            {
                IssueID = w.IssueID,
                IssueType = w.IssueType
            }).ToList();

            return Json(issuesList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetViewIssues()
        {

            return View("ViewIssues");
        }

        public ActionResult GetCreateView()
        {
            return View("CreateIssues");
        }



        public ActionResult CreateIssue(int IssueType, string Details, string Location, int ReportedBy, string CFirst, string CLast, string CEmail, string CPhone)
        {
            IssueInsertResponse response = new IssueInsertResponse();
            Issues request = new Issues();

            request.IssueTypeID = IssueType;
            request.Details = Details;
            request.Location = Location;
            request.ReportedBy = ReportedBy;
            request.citizen.FirstName = CFirst;
            request.citizen.LastName = CLast;
            request.citizen.Email = CEmail;
            request.citizen.Phone = CPhone;

            try
            {
                response = issueService.CreateIssue(request);
            }
            catch (Exception ex)
            {

            }

            return Json(response.data);
        }

        public ActionResult GetAllIssues()
        {
            List<Issues> issuesList = new List<Issues>();
            Issues request = new Issues();

            try
            {
                issuesList = issueService.GetAllIssues(request).data.Select(w => new Issues()
                {
                    IssueID = w.IssueID,
                    IssueType = w.IssueType,
                    Details = w.Details,
                    Location = w.Location,
                    ReportedBy = w.ReportedBy,
                    EmployeeName = w.EmployeeName,
                    CitizenName = w.CitizenName,
                    CitizenEmail = w.CitizenEmail,
                    CitizenPhone = w.CitizenPhone
                    
                }).ToList();
            }
            catch (Exception ex)
            {

            }

            return Json(issuesList, JsonRequestBehavior.AllowGet);
        }
    }
}