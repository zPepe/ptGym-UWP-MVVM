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
    class RegistrationDAL
    {
        private static string file = "ptGym.db";

        public static bool CreateTable()
        {
            bool res = false;
            string query = @"CREATE TABLE IF NOT EXISTS ""Registration""(
                             ""idRegistration"" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                              ""registrationDate"" DATETIME NOT NULL,
                              ""registrationValue"" DOUBLE NOT NULL,
                              ""registrationRef"" INTEGER NOT NULL,                                
                              ""Client_idClient"" INTEGER,
                              ""Class_idClass"" INTEGER,
                              CONSTRAINT ""idRegistration_UNIQUE""
                                UNIQUE(""idRegistration""),
                              CONSTRAINT ""registrationRef_UNIQUE""
                                UNIQUE(""registrationRef""),
                              CONSTRAINT ""fk_Registration_Client1""
                                FOREIGN KEY(""Client_idClient"")
                                REFERENCES ""Client""(""idClient"") ON DELETE SET NULL,
                              CONSTRAINT ""fk_Registration_Class1""
                                FOREIGN KEY(""Class_idClass"")
                                REFERENCES ""Class""(""idClass"") ON DELETE SET NULL
                            );";
            DB db = DB.getDB(file);
            db.NonQuery(query);
            return (res);
        }

        public static bool Create(Registration e)
        {
            DB db = DB.getDB(file);
            string query = @"INSERT INTO Registration (registrationDate, registrationValue, registrationRef, Client_idClient, Class_idClass)
                            VALUES (@registrationDate, @registrationValue, @registrationRef, @Client_idClient, @Class_idClass)";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            string date1 = e.Date.ToString("yyyy-MM-dd HH:mm:ss"); parms.Add("@registrationDate", date1);
            parms.Add("@registrationValue", e.Value);
            parms.Add("@registrationRef", e.Ref);
            parms.Add("@Client_idClient", e.IdClient);
            parms.Add("@Class_idClass", e.IdClass);
            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static bool Delete(Registration e)
        {
            DB db = DB.getDB(file);
            string query = @"DELETE FROM Registration WHERE registrationRef = @registrationRef";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@registrationRef", e.Ref);
            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);

        }

        public static bool Update(Registration e)
        {      
            DB db = DB.getDB(file);
            string query = @"UPDATE Registration SET registrationDate = @registrationDate, registrationValue = @registrationValue,
                            registrationRef = @registrationRef, Client_idClient = @Client_idClient, Class_idClass = @Class_idClass
                            WHERE idRegistration = @idRegistration";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@idRegistration", e.Id);
            string date = e.Date.ToString("yyyy-MM-dd HH:mm:ss"); parms.Add("@registrationDate", date);
            parms.Add("@registrationValue", e.Value);
            parms.Add("@registrationRef", e.Ref);
            parms.Add("@Client_idClient", e.IdClient);
            parms.Add("@Class_idClass", e.IdClass);
            bool res = db.NonQuery(query, parms);

            return (res);
        }

        public static bool GetByRef(Registration e)
        {
            bool res = false;
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Registration WHERE registrationRef = @registrationRef";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@registrationRef", e.Ref);
            using (ISQLiteStatement statement = db.Query(query, parms))
            {
                if (statement.Step() == SQLiteResult.ROW)
                {
                    MappingDB200(statement, e);
                    res = true;
                }
            }
            return res;
        }

        public static bool GetById(Registration e)
        {
            bool res = false;
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Client c, Class cs
                            JOIN Registration s
                            ON s.Client_idClient = c.idClient
                            AND s.Class_idClass = cs.idClass
                            WHERE idRegistration = @idRegistration";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@idRegistration", e.Id);
            using (ISQLiteStatement statement = db.Query(query, parms))
            {
                if (statement.Step() == SQLiteResult.ROW)
                {
                    MappingDB200(statement, e);
                    res = true;
                }
            }
            return res;
        }


        public static ObservableCollection<Registration> GetAll()
        {
            ObservableCollection<Registration> res = new ObservableCollection<Registration>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Client c, Class cs
                            JOIN Registration s
                            ON s.Client_idClient = c.idClient
                            AND s.Class_idClass = cs.idClass";
            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    long id = (long)statement["idRegistration"];
                    Registration u = new Registration();
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
            string query = @"SELECT * FROM Client c, Class cs
                            JOIN Registration s
                            ON s.Client_idClient = c.idClient
                            AND s.Class_idClass = cs.idClass
                            WHERE idClient = @idClient";
            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    Registration u = new Registration();
                    MappingDB200Func1(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }

        private static void MappingDB200(ISQLiteStatement statement, Registration e)
        {
            e.Id = (long)statement["idRegistration"];
            string date2 = (string)statement["registrationDate"]; e.Date = DateTime.Parse(date2);
            e.Value = (double)statement["registrationValue"];
            e.Ref = (long)statement["registrationRef"];

            //e.IdClient = (long)statement["Client_idClient"];
            //e.IdClass = (long)statement["Class_idClass"];

            e.Client = new Client();
            e.Client.Id = (long)statement[0];
            e.Client.Name = (string)statement[1];
            e.Client.CC = (long)statement[2];
            e.Client.Phone = (string)statement[3];
            e.Client.HomeAddress = (string)statement[4];
            e.Client.Locality = (string)statement[5];

            e.Class = new Class();
            e.Class.Id = (long)statement[6];
            e.Class.Name = (string)statement[7];
            e.Class.Type = (string)statement[8];
        }

        internal static void MappingDB200Func1(ISQLiteStatement statement, Registration u)
        {
            u.Id = (long)statement["idRegistration"];
            u.Ref = (long)statement["registrationRef"];

            u.Client = new Client();
            u.Client.Id = (long)statement["idClient"];
            u.Client.Name = (string)statement["clientName"];
            //u.Client.CC = (long)statement[16];

            u.Class = new Class();
            u.Class.Id = (long)statement["idClass"];
            u.Class.Name = (string)statement["className"];
        }
    }
}
