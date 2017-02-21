using ptGym_Dal_BL.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptGymUWP.ViewModels
{
    public class CoachViewModel
    {
        public ObservableCollection<Coach> Coaches { get; set; }
        public Coach Coach { get; set; }

        public CoachViewModel()
        {
            Coaches = new ObservableCollection<Coach>();
            Coaches = Coach.GetAll();
            Coach = new Coach();
        }

        internal bool AddCoach()
        {
            bool res = false;
            if((Coach.CC != 0))
            {
                if (Coach.Create())
                {
                    Coaches.Add(Coach);
                    res = true;
                }
            }
            return res;
        }

        internal void DeleteCoach()
        {
            if (Coach.Delete())
            {
                Coaches.Remove(Coach);
            }
        }

        internal bool UpdateCoach()
        {
            bool res = false;
            if (Coach.Id == 0)
            {
                res = AddCoach();
            }
            else
            {
                res = Coach.Update();
            }
            return res;
        }
    }
}
