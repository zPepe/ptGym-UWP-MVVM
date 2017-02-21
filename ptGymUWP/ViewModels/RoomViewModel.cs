using ptGym_Dal_BL.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptGymUWP.ViewModels
{
    public class RoomViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Room> Rooms { get; set; }
        public Room Room { get; set; }

        public RoomViewModel()
        {
            Rooms = new ObservableCollection<Room>();
            Rooms = Room.GetAll();
            Room = new Room();
        }

        internal bool AddRoom()
        {
            bool res = false;
            if((Room.Name != ""))
            {
                if (Room.Create())
                {
                    Rooms.Add(Room);
                    res = true;
                }
            }
            return res;
        }

        internal void DeleteRoom()
        {
            if (Room.Delete())
            {
                Rooms.Remove(Room);
            }
        }

        internal bool UpdateRoom()
        {
            bool res = false;
            if (Room.Id == 0)
            {
                res = AddRoom();
            }
            else
            {
                res = Room.Update();
            }
            return res;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
