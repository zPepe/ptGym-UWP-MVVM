using ptGym_Dal_BL.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptGymUWP.ViewModels
{
    public class RegistrationViewModel
    {
        public ObservableCollection<Registration> Registrations { get; set; }
        public Registration Registration { get; set; }

        //Aqui são as Funcionalidades
        public ObservableCollection<Registration> clienteRegistado { get; set; }

        public RegistrationViewModel()
        {
            Registrations = new ObservableCollection<Registration>();
            Registrations = Registration.GetAll();
            Registration = new Registration();

            //Aqui são as Funcionalidades
            clienteRegistado = Registration.ClienteRegistado();
        }

        internal bool AddRegistration()
        {
            bool res = false;
            if((Registration.Ref != 0))
            {
                if (Registration.Create())
                {
                    if (Registration.GetById())
                    {
                        Registrations.Add(Registration);
                        res = true;
                    } 
                }
            }
            return res;
        }

        internal void DeleteRegistration()
        {
            if (Registration.Delete())
            {
                Registrations.Remove(Registration);
            }
        }

        internal bool UpdateRegistration()
        {
            bool res = false;
            if (Registration.Id == 0)
            {
                res = AddRegistration();
            }
            else
            {
                res = Registration.Update();
            }
            return res;
        }
    }
}
