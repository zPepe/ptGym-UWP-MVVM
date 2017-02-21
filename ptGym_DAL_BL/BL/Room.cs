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
    public class Room : INotifyPropertyChanged
    {
        public long Id { get; set; }

        private long capacity;
        public long Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
                NotifyPropertyChanged("Capacity");
            }
        }
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

        public Room(long capacity, string roomName)
        {
            this.Capacity = capacity;
            this.Name = roomName;
        }

        public Room()
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
            if (!RoomDAL.GetByName(this))
            {
                res = RoomDAL.Create(this);
            }
            return res;
        }

        public bool Delete()
        {
            bool res = false;
            res =RoomDAL.Delete(this);
            return (res);
        }

        public bool Update()
        {
            return RoomDAL.Update(this);
        }

        public bool GetByName()
        {
            bool res = false;
            res = RoomDAL.GetByName(this);
            return res;
        }

        public static ObservableCollection<Room> GetAll()
        {
            return (RoomDAL.GetAll());
        }

        public static ObservableCollection<Room> GetByName1(string roomName)
        {
            return (RoomDAL.GetByName1(roomName));
        }


        public bool CheckClass(long id)
        {
            bool res = RoomDAL.CheckClass(id);
            return res;
        }
    }
}
