using ptGym_Dal_BL.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptGym_Dal_BL.BL
{
    /// <summary>
    /// Implements the INotifyPropertyChanged interface
    /// </summary>
    public class Coach : INotifyPropertyChanged
    {
        public long Id { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private long age;
        public long Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                NotifyPropertyChanged("Age");
            }
        }

        private long cc;
        public long CC
        {
            get
            {
                return cc;
            }
            set
            {
                cc = value;
                NotifyPropertyChanged("CC");
            }
        }

        public Coach(string name, long age, long cc)
        {
            this.Name = name;
            this.Age = age;
            this.CC = cc;
        }

        public Coach()
        {
        }

        /// <summary>
        ///  This method is called by the Set accessor of each property.
        ///  The CallerMemberName attribute that is applied to the optional propertyName.
        ///  parameter causes the property name of the caller to be substituted as an argument.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool Create()
        {
            bool res = false;
            if (!CoachDAL.GetByCC(this))
            {
                res = CoachDAL.Create(this);
            }
            return res;
        }

        public bool Delete()
        {
            bool res = false;
            res = CoachDAL.Delete(this);
            return (res);
        }

        public bool Update()
        {
            return CoachDAL.Update(this);
        }

        public bool GetByCC()
        {
            bool res = false;
            res = CoachDAL.GetByCC(this);
            return res;
        }

        public static ObservableCollection<Coach> GetAll()
        {
            return (CoachDAL.GetAll());
        }

        public static ObservableCollection<Coach> GetByCC1(long CC)
        {
            return (CoachDAL.GetByCC1(CC));
        }

        public bool CheckClass(long id)
        {
            bool res = CoachDAL.CheckClass(id);
            return res;
        }
    }
}
