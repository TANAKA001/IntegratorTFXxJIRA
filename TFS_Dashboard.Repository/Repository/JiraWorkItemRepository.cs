
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TFS_Dashboard.Repository.Context;
using TFS_Dashboard.Repository.Model;

namespace TFS_Dashboard.Repository.Repository
{  
    public class JiraWorkItemRepository
    {
        DashboardDatabase db = new DashboardDatabase();

        public void Incluir(List<Jira_WorkItem> dados)
        {
            try
            {
                foreach (Jira_WorkItem JIRA in dados)
                {
                    db.Jira_WorkItem.Add(JIRA);
                }

                if (db.Jira_WorkItem.Count() > 0)
                {
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> ListKeyJira()
        {
            List<string> _jira_WorkItem = db.Jira_WorkItem.Select(s => s.Key_Issue).ToList();

            return _jira_WorkItem;
        }
    }
}