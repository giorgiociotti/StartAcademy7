using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.DataModels
{
    public class Weekwork
    {
        public int Id { get; set; }
        public string EnrollementFather { get; set; }
        public DateTime WorkDate { get; set; }
        public string Activity { get; set; }


        public Weekwork() { }
        public Weekwork(int id, DateTime activitydate, string activity,string enrollment)
        {
            Id = id;
            WorkDate = activitydate;
            Activity = activity;
            EnrollementFather = enrollment;
        }
    }
}
