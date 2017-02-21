using DataAbstractionLayerSQLite;
using ptGym_Dal_BL.BL;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptGym_Dal_BL.DAL
{
    class ClientDAL
    {
        private static string file = "ptGym.db";

        public static bool CreateTable()
        {
            bool res = false;
            string query = @"CREATE TABLE IF NOT EXISTS ""Client""(
                          ""idClient"" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                          ""clientName"" VARCHAR(45) NOT NULL,
                          ""clientCC"" INTEGER  NOT NULL,
                          ""phone"" VARCHAR(45) NOT NULL,
                          ""homeAddress"" VARCHAR(45) NOT NULL,
                          ""locality"" VARCHAR(45) NOT NULL,
                          CONSTRAINT ""idClient_UNIQUE""
                            UNIQUE(""idClient""),
                          CONSTRAINT ""clientCC_UNIQUE""
                            UNIQUE(""clientCC"")
                        );";
            DB db = DB.getDB(file);
            db.NonQuery(query);
            return (res);
        }

        public static bool Create(Client e)
        {
            DB db = DB.getDB(file);
            string query = @"INSERT INTO Client (clientName, clientCC, phone, homeAddress, locality) 
                            VALUES (@clientName, @clientCC, @phone, @homeAddress, @locality)";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@clientName", e.Name);
            parms.Add("@clientCC", e.CC);
            parms.Add("@phone", e.Phone);
            parms.Add("@homeAddress", e.HomeAddress);
            parms.Add("@locality", e.Locality);
            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return res;
        }

        public static bool Delete(Client e)
        {
            DB db = DB.getDB(file);
            string query = @"DELETE FROM Client WHERE clientCC = @clientCC";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@clientCC", e.CC);
            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static bool Update(Client e)
        {
            DB db = DB.getDB(file);
            string query = @"UPDATE Client SET clientName = @clientName, clientCC = @clientCC, phone = @phone,
                            homeAddress = @homeAddress, locality = @locality
                            WHERE idClient = @idClient"; 
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@idClient", e.Id);
            parms.Add("@clientName", e.Name);
            parms.Add("@clientCC", e.CC);
            parms.Add("@phone", e.Phone);
            parms.Add("@homeAddress", e.HomeAddress);
            parms.Add("@locality", e.Locality);
            bool res = db.NonQuery(query, parms);
            
            return (res);
        }

        public static bool GetByCC(Client e)
        {
            bool res = false;
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Client WHERE clientCC = @clientCC";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@clientCC", e.CC);
            using (ISQLiteStatement statement = db.Query(query, parms))
            {
                if (statement.Step() == SQLiteResult.ROW)
                {
                    MappingDB200(statement, e);
                    res =  true;
                }
            }
            return res;
        }

        public static ObservableCollection<Client> GetAll()
        {
            ObservableCollection<Client> res = new ObservableCollection<Client>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Client";
            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    long id = (long)statement["idClient"];

                    Client u = new Client();
                    MappingDB200(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }
        public static ObservableCollection<Registration> ClienteRegistado()
        {
            ObservableCollection<Registration> res = new ObservableCollection<Registration>();
            DB db = DB.getDB(file);
            string query = @"SELECT distinct * FROM Client c JOIN Registration r 
                            ON r.Client_idClient = c.idClient 
                            JOIN Class cl ON r.Class_idClass = cl.idClass";
            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    Registration u = new Registration();
                    RegistrationDAL.MappingDB200Func1(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }

        public static ObservableCollection<Client> ClientLocalidade()
        {
            ObservableCollection<Client> res = new ObservableCollection<Client>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Client";
            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    Client u = new Client();
                    ClientDAL.MappingDB200(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }


        private static void MappingDB200(ISQLiteStatement statement, Client e)
        {
            e.Id = (long)statement["idClient"];
            e.Name = (string)statement["clientName"];
            e.CC = (long)statement["clientCC"];
            e.Phone = (string)statement["phone"];
            e.HomeAddress = (string)statement["homeAddress"];
            e.Locality = (string)statement["locality"];

        }


        public static bool CheckRegistration(long id)
        {
            bool res = false;
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Registration r WHERE r.Client_idClient = ?";
            using (ISQLiteStatement statement = db.Query(query))
            {
                statement.Bind(1, id);
                while (statement.Step() == SQLiteResult.ROW)
                {
                    res = true;
                }
            }
            return res;
        }

       

    }
}
