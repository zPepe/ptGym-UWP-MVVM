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
    public class Client : INotifyPropertyChanged
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
        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                NotifyPropertyChanged("Phone");
            }
        }

        private string homeaddress;
        public string HomeAddress
        {
            get
            {
                return homeaddress;
            }
            set
            {
                homeaddress = value;
                NotifyPropertyChanged("HomeAddress");
            }
        }

        private string locality;
        public string Locality
        {
            get
            {
                return locality;
            }
            set
            {
                locality = value;
                NotifyPropertyChanged("Locality");
            }
        }
        
        
        public Client(string clientName, long clientCC, string phone, string homeAddress, string locality)
        {
            this.Name = clientName;
            this.CC = clientCC;
            this.Phone = phone;
            this.HomeAddress = homeAddress;
            this.Locality = locality;
        }

       

        public Client()
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
            if (!ClientDAL.GetByCC(this))
            {
                res = ClientDAL.Create(this);
            }
            return res;
        }

        public bool Delete()
        {
            bool res = false;
            res = ClientDAL.Delete(this);
            return (res);
        }

        public bool Update()
        {
            return ClientDAL.Update(this);           
        }

        public bool GetByCC()
        {
            bool res = false;
            res = ClientDAL.GetByCC(this);
            return res;
        }

        public static ObservableCollection<Client> GetAll()
        {
            return (ClientDAL.GetAll());
        }

        public bool CheckRegistration(long id)
        {
            bool res = ClientDAL.CheckRegistration(id);
            return res;
        }


        public static ObservableCollection<Registration> ClienteRegistado()
        {
            return (ClientDAL.ClienteRegistado());
        }

        public static ObservableCollection<Client> ClientLocalidade()
        {
            return (ClientDAL.ClientLocalidade());
        }
    }
}
