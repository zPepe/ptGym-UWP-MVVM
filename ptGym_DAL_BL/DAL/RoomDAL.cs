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
    class RoomDAL
    {
        private static string file = "ptGym.db";

        public static bool CreateTable()
        {
            bool res = false;
            string query = @"CREATE TABLE IF NOT EXISTS ""Room""(
                          ""idRoom"" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                          ""capacity"" INTEGER NOT NULL,
                          ""roomName"" VARCHAR(45) NOT NULL,
                          CONSTRAINT ""idRoom_UNIQUE""
                            UNIQUE(""idRoom""),
                          CONSTRAINT ""roomName_UNIQUE""
                            UNIQUE(""roomName"")
                        );";
            DB db = DB.getDB(file);
            db.NonQuery(query);
            return (res);
        }

        public static bool Create(Room e)
        {
            DB db = DB.getDB(file);
            string query = @"INSERT INTO Room (capacity, roomName) VALUES (@capacity, @roomName)";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@capacity", e.Capacity);
            parms.Add("@roomName", e.Name);
            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static bool Delete(Room e)
        {
            DB db = DB.getDB(file);
            string query = @"DELETE FROM Room WHERE roomName = @roomName";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@roomName", e.Name);
            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static bool Update(Room e)
        {
            DB db = DB.getDB(file);
            string query = @"UPDATE Room SET capacity = @capacity, roomName = @roomName
                            WHERE idRoom = @idRoom";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@idRoom", e.Id);
            parms.Add("@capacity", e.Capacity);
            parms.Add("@roomName", e.Name);
            bool res = db.NonQuery(query, parms);

            return (res);
        }

        public static bool GetByName(Room e)
        {
            bool res = false;
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Room WHERE roomName = @roomName";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@roomName", e.Name);
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

        public static ObservableCollection<Room> GetAll()
        {
            ObservableCollection<Room> res = new ObservableCollection<Room>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Room";
            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    long id = (long)statement["idRoom"];

                    Room u = new Room();
                    MappingDB200(statement, u);
                    res.Add(u);

                }
            }
            return (res);
        }

        public static ObservableCollection<Room> GetByName1(string roomName)
        {
            ObservableCollection<Room> res = new ObservableCollection<Room>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Room WHERE roomName = @roomName";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@roomName", roomName);
            using (ISQLiteStatement statement = db.Query(query, parms))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    long id = (long)statement["idRoom"];

                    Room u = new Room();
                    MappingDB200(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }

        private static void MappingDB200(ISQLiteStatement statement, Room e)
        {
            e.Id = (long)statement["idRoom"];
            e.Capacity = (long)statement["capacity"];
            e.Name = (string)statement["roomName"];
        }

        public static bool CheckClass(long id)
        {
            bool res = false;
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Class r WHERE r.Room_idRoom = ?";
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
