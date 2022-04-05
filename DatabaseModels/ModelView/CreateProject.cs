using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModels.ModelView
{
    public class CreateProject
    {
        public int Project_id { get; set; }
        public string Project_Name { get; set; }
        public string Project_Type { get; set; }
        public int Acc_ID { get; set; }
        public string Username { get; set; }
        public DateTime Estimated_Start { get; set; }
        public DateTime Estimated_End { get; set; }
        public string Project_Des { get; set; }
    }
}
