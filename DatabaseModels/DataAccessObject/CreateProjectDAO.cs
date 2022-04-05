using DatabaseWPMSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels.DataAccessObject
{
    public class CreateProjectDAO
    {
        MyDatabase mydb = new MyDatabase();

        public void DeleteObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Remove(obj);
        }

        public void Save()
        {
            mydb.SaveChanges();
        }

        public void AddObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Add(obj);
        }

        public int CreateProject(PROJECT a)
        {
            mydb.PROJECTS.Add(a);
            return a.Project_id;
        }

        // lấy ra list project
        public List<PROJECT> FindAll()
        {
            return mydb.PROJECTS.ToList();
        }
    }
}
