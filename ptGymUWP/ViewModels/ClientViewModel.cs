using ptGym_Dal_BL.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptGymUWP.ViewModels
{
    public class ClientViewModel
    {
        public ObservableCollection<Client> Clients { get; set; }
        public Client Client { get; set; }

        public ObservableCollection<Client> ClientLocalidade { get; set; }

        public ClientViewModel()
        {
            Clients = new ObservableCollection<Client>();
            Clients = Client.GetAll();
            Client = new Client();

            ClientLocalidade = Client.ClientLocalidade();
        }

        internal bool AddClient()
        {
            bool res = false;
            if((Client.CC != 0))
            {
                if (Client.Create())
                {
                    Clients.Add(Client);
                    res = true;
                }
            }
            return res;
        }

        internal void DeleteClient()
        {
            if (Client.Delete())
            {
                Clients.Remove(Client);
            }
        }

        internal bool UpdateClient()
        {
            bool res = false;
            if(Client.Id == 0)
            {
                res = AddClient();
            }
            else
            {
                res = Client.Update();
            }
            return res;
        }
    }
}
