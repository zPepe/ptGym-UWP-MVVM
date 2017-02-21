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
    public class Class : INotifyPropertyChanged
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

        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
                NotifyPropertyChanged("Type");
            }
        }

        private DateTime dt;
        public DateTime Date
        {
            get
            {
                return dt;
            }
            set
            {
                dt = value;
                NotifyPropertyChanged("Date");
            }
        }

        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                NotifyPropertyChanged("Price");
            }
        }

        private long idroom;
        public long IdRoom
        {
            get
            {
                return idroom;
            }
            set
            {
                idroom = value;
                NotifyPropertyChanged("IdRoom");
            }
        }
        private Room room;
        public Room Room
        {
            get
            {
                return room;
            }
            set
            {
                room = value;
                NotifyPropertyChanged("Room");
            }
        }

        private long idcoach;
        public long IdCoach
        {
            get
            {
                return idcoach;
            }
            set
            {
                idcoach = value;
                NotifyPropertyChanged("IdCoach");
            }
        }

        private Coach coach;
        public Coach Coach
        {
            get
            {
                return coach;
            }
            set
            {
                coach = value;
                NotifyPropertyChanged("Coach");
            }
        }




        public Class(string className, string classType, DateTime classDate, double price, Room room, Coach coach)
        {
            this.Name = className;
            this.Type = classType;
            this.Date = classDate;
            this.Price = price;
            this.Room = room;
            this.Coach = coach;
        }

        public Class()
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
            if (!ClassDAL.GetByID(this))
            {
                res = ClassDAL.Create(this);
            }
            return res;            
        }
        

        public bool Delete()
        {
            bool res = false;
            res = ClassDAL.Delete(this);
            return (res);       
        }

        public bool Update()
        {
            return ClassDAL.Update(this);
        }


        public bool GetByName()
        {
            bool res = false;
            res = ClassDAL.GetByName(this);
            return res;
        }

        public bool GetById()
        {
            bool res = false;
            res = ClassDAL.GetByID(this);
            return res;
        }

        public bool GetById1()
        {
            bool res = false;
            res = ClassDAL.GetByID1(this);
            return res;
        }

        public static ObservableCollection<Class> GetAll()
        {
            return (ClassDAL.GetAll());
        }

        //public static ObservableCollection<Class> GetAllId(long idClass)
        //{
        //    return (ClassDAL.GetAllId(idClass));
        //}

        public bool CheckRegistration(long id)
        {
            bool res = ClassDAL.CheckRegistration(id);
            return res;
        }        
    }
}   
