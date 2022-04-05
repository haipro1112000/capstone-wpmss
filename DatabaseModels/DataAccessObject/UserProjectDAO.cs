using DatabaseWPMSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels.DataAccessObject
{
    public class UserProjectDAO
    {
        MyDatabase db = new MyDatabase();
        public ROLE_IN_PROJECT FindRoleByAccountIdAndProjectID(int accountId, int projectID)
        {
            return db.ROLE_IN_PROJECT.SingleOrDefault(x => x.Acc_ID == accountId && x.Project_id == projectID);
        }
        public PROJECT FindProjectByID(int id)
        {
            return db.PROJECTS.Find(id);
        }

        
    }
}
