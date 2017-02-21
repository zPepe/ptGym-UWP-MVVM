using ptGym_Dal_BL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptGym_Dal_BL.BL
{
    public class Database
    {
        public static void CreateTables()
        {
            ClassDAL.CreateTable();
            ClientDAL.CreateTable();
            CoachDAL.CreateTable();
            RegistrationDAL.CreateTable();
            RoomDAL.CreateTable();
        }
    }

    
}
