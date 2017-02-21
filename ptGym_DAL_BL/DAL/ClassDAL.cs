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
    class ClassDAL
    {
        private static string file = "ptGym.db";

        public static bool CreateTable()
        {
            bool res = false;
            string query = @"CREATE TABLE IF NOT EXISTS ""Class""(
                            ""idClass"" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                            ""className"" VARCHAR(45) NOT NULL,
                            ""classType"" VARCHAR(45) NOT NULL,
                             ""classDate"" DATETIME NOT NULL,
                             ""price"" DOUBLE NOT NULL,
                             ""Room_idRoom"" INTEGER, 
                             ""Coach_idCoach"" INTEGER,
                             CONSTRAINT ""idClass_UNIQUE""
                                UNIQUE(""idClass""),
                             CONSTRAINT ""className_UNIQUE""
                                UNIQUE(""className""),                                
                            CONSTRAINT ""fk_Class_Room1""
                                FOREIGN KEY(""Room_idRoom"")
                            REFERENCES ""Room""(""idRoom"") ON DELETE SET NULL,
                                CONSTRAINT ""fk_Class_Coach1""
                            FOREIGN KEY(""Coach_idCoach"")
                                REFERENCES ""Coach""(""idCoach"") ON DELETE SET NULL
                        );";
            DB db = DB.getDB(file);
            db.NonQuery(query);
            return (res);
        }

        public static bool Create(Class e)
        {
            DB db = DB.getDB(file);
            string query = @"INSERT INTO Class (className, classType, classDate, price, Room_idRoom, Coach_idCoach) 
                            VALUES (@className, @classType, @classDate, @price, @Room_idRoom, @Coach_idCoach)";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@className", e.Name);
            parms.Add("@classType", e.Type);
            string date = e.Date.ToString("yyyy-MM-dd HH:mm:ss"); parms.Add("@classDate", date);
            parms.Add("@price", e.Price);
            parms.Add("@Room_idRoom", e.IdRoom);
            parms.Add("@Coach_idCoach", e.IdCoach);
            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static bool Delete(Class e)
        {
            DB db = DB.getDB(file);
            string query = @"DELETE FROM Class WHERE className = @className";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@className", e.Name);
            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static bool Update(Class e)
        {
            DB db = DB.getDB(file);
            string query = @"UPDATE Class SET className = @className, classType = @classType, classDate = @classDate, price = @price,
                                    Room_idRoom = @Room_idRoom, Coach_idCoach = @Coach_idCoach
                            WHERE idClass = @idClass";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@idClass", e.Id);
            parms.Add("@className", e.Name);
            parms.Add("@classType", e.Type);
            string date = e.Date.ToString("yyyy-MM-dd HH:mm:ss"); parms.Add("@classDate", date);
            parms.Add("@price", e.Price);
            parms.Add("@Room_idRoom", e.IdRoom);
            parms.Add("@Coach_idCoach", e.IdCoach);

            bool res = db.NonQuery(query, parms);
            return (res);

        }

        public static bool GetByName(Class e)
        {
            bool res = false;
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Class WHERE className = @className";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@className", e.Name);
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

        public static bool GetByID(Class e)
        {
            bool res = false;
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Class WHERE idClass = @idClass";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@idClass", e.Id);
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

        public static bool GetByID1(Class e)
        {
            bool res = false;
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Room r, Coach c
                            JOIN Class s
                            ON s.Room_idRoom = r.idRoom
                            AND s.Coach_idCoach = c.idCoach
                            WHERE idClass = @idClass";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@idClass", e.Id);
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


        public static ObservableCollection<Class> GetAll()
        {
            ObservableCollection<Class> res = new ObservableCollection<Class>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Room r, Coach c
                            JOIN Class s
                            ON s.Room_idRoom = r.idRoom
                            AND s.Coach_idCoach = c.idCoach";
            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    long id = (long)statement["idClass"];

                    Class u = new Class();
                    MappingDB200(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }

        //public static ObservableCollection<Class> GetAllId(long idClass)
        //{
        //    ObservableCollection<Class> res = new ObservableCollection<Class>();
        //    DB db = DB.getDB(file);
        //    string query = @"SELECT * FROM Room r, Coach c
        //                    JOIN Class s
        //                    ON s.Room_idRoom = r.idRoom
        //                    AND s.Coach_idCoach = c.idCoach";
        //    using (ISQLiteStatement statement = db.Query(query))
        //    {
        //        while (statement.Step() == SQLiteResult.ROW)
        //        {
        //            long id = (long)statement["idClass"];

        //            Class u = new Class();
        //            MappingDB200(statement, u);
        //            res.Add(u);
        //        }
        //    }
        //    return (res);
        //}


        private static void MappingDB200(ISQLiteStatement statement, Class e)
        {
            e.Id = (long)statement["idClass"];
            e.Name = (string)statement["className"];
            e.Type = (string)statement["classType"];
            string date2 = (string)statement["classDate"]; e.Date = DateTime.Parse(date2);
            e.Price = (double)statement["price"];

            e.Room = new Room();
            e.Room.Id = (long)statement[0];
            e.Room.Capacity = (long)statement[1];
            e.Room.Name = (string)statement[2];

            e.Coach = new Coach();
            e.Coach.Id = (long)statement[3];
            e.Coach.Name = (string)statement[4];
            e.Coach.Age = (long)statement[5];
            e.Coach.CC = (long)statement[6];
        }

        public static bool CheckRegistration(long id)
        {
            bool res = false;
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Registration r WHERE r.Class_idClass = ?";
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
