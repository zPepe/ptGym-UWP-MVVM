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
    public class Registration : INotifyPropertyChanged
    {
        public long Id { get; set; }

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
        private double value1;
        public double Value
        {
            get
            {
                return value1;
            }
            set
            {
                value1 = value;
                NotifyPropertyChanged("Value");
            }
        }
        private long ref1;
        public long Ref
        {
            get
            {
                return ref1;
            }
            set
            {
                ref1 = value;
                NotifyPropertyChanged("Ref");
            }
        }

        private long idclient;
        public long IdClient
        {
            get
            {
                return idclient;
            }
            set
            {
                idclient = value;
                NotifyPropertyChanged("IdClient");
            }
        }

        private Client client;
        public Client Client
        {
            get
            {
                return client;
            }
            set
            {
                client = value;
                NotifyPropertyChanged("Client");
            }
        }

        private long idclass;
        public long IdClass
        {
            get
            {
                return idclass;
            }
            set
            {
                idclass = value;
                NotifyPropertyChanged("IdClass");
            }
        }

        private Class class1;
        public Class Class
        {
            get
            {
                return class1;
            }
            set
            {
                class1 = value;
                NotifyPropertyChanged("Class");
            }
        }

        public Registration(DateTime registrationDate, double registrationValue, long registrationRef, Client client, Class class1)
        {
            this.Date = registrationDate;
            this.Value = registrationValue;
            this.Ref = registrationRef;
            this.Client = client;
            this.Class = class1;
        }

        public Registration()
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
            if (!RegistrationDAL.GetByRef(this))
            {
                res = RegistrationDAL.Create(this);
            }
            return res;
        }

        public bool Delete()
        {
            bool res = false;
            res = RegistrationDAL.Delete(this);
            return (res);
        }

        public bool Update()
        {
            return RegistrationDAL.Update(this);
        }

        public bool GetByRef()
        {
            bool res = false;
            res = RegistrationDAL.GetByRef(this);
            return res;
        }

        public bool GetById()
        {
            bool res = false;
            res = RegistrationDAL.GetById(this);
            return res;
        }


        public static ObservableCollection<Registration> GetAll()
        {
            return (RegistrationDAL.GetAll());
        }

        public static ObservableCollection<Registration> ClienteRegistado()
        {
            return (RegistrationDAL.ClienteRegistado());
        }
    }
}
