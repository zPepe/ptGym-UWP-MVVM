using ptGym_Dal_BL.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptGymUWP.ViewModels
{
    public class ClassViewModel
    {           
        public ObservableCollection<Class> Classes { get; set; }
        public Class Class { get; set; }


        public ClassViewModel()
        {
            Classes = new ObservableCollection<Class>();
            Classes = Class.GetAll();

            Class = new Class();
        }

        internal bool AddClass()
        {
            bool res = false;
            if((Class.Name != ""))
            {
                if (Class.Create())
                {
                    if (Class.GetById1())
                    {
                        Classes.Add(Class);
                        res = true;
                    }
                }
            }
            return res;
        }

        internal void DeleteClass()
        {
            if (Class.Delete())
            {
                Classes.Remove(Class);
            }
        }

        internal bool UpdateClass()
        {
            bool res = false;
            if (Class.Id == 0)
            {
                res = AddClass();
            }
            else
            {
                res = Class.Update();
            }
            return (res);     
        }
    }
}
