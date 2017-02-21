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
    class CoachDAL
    {
        private static string file = "ptGym.db";

        public static bool CreateTable()
        {
            bool res = false;
            string query = @"CREATE TABLE IF NOT EXISTS ""Coach""(
                          ""idCoach"" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                          ""coachName"" VARCHAR(45) NOT NULL,
                          ""coachAge"" INTEGER NOT NULL,
                          ""coachCC"" INTEGER NOT NULL,
                          CONSTRAINT ""idCoach_UNIQUE""
                            UNIQUE(""idCoach""),
                          CONSTRAINT ""coachCC_UNIQUE""
                            UNIQUE(""coachCC"")
                        );";
            DB db = DB.getDB(file);
            db.NonQuery(query);
            return (res);
        }

        public static bool Create(Coach e)
        {
            DB db = DB.getDB(file);
            string query = @"INSERT INTO Coach (coachName, coachAge, coachCC) VALUES (@coachName, @coachAge, @coachCC)";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@coachName", e.Name);
            parms.Add("@coachAge", e.Age);
            parms.Add("@coachCC", e.CC);
            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }


        public static bool Delete(Coach e)
        {
            DB db = DB.getDB(file);
            string query = @"DELETE FROM Coach WHERE coachCC = @coachCC";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@coachCC", e.CC);
            bool res = db.NonQuery(query, parms);
            if (res)
            {
                e.Id = db.LastId();
            }
            return (res);
        }

        public static bool Update(Coach e)
        {
            DB db = DB.getDB(file);
            string query = @"UPDATE Coach set coachName = @coachName, coachAge = @coachAge, coachCC = @coachCC
                            WHERE idCoach = @idCoach";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@idCoach", e.Id);
            parms.Add("@coachName", e.Name);
            parms.Add("@coachAge", e.Age);
            parms.Add("@coachCC", e.CC);
            bool res = db.NonQuery(query, parms);

            return (res);
        }

        public static bool GetByCC(Coach e)
        {
            bool res = false;
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Coach WHERE coachCC = @coachCC";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@coachCC", e.CC);
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


        public static ObservableCollection<Coach> GetByCC1(long CC)
        {
            ObservableCollection<Coach> res = new ObservableCollection<Coach>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Coach WHERE coachCC = @coachCC";
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("@coachCC", CC);
            using (ISQLiteStatement statement = db.Query(query, parms))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    long id = (long)statement["idCoach"];

                    Coach u = new Coach();
                    MappingDB200(statement, u);
                    res.Add(u);
                }
            }
            return (res);
        }

        public static ObservableCollection<Coach> GetAll()
        {
            ObservableCollection<Coach> res = new ObservableCollection<Coach>();
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Coach";
            using (ISQLiteStatement statement = db.Query(query))
            {
                while (statement.Step() == SQLiteResult.ROW)
                {
                    long id = (long)statement["idCoach"];

                    Coach u = new Coach();
                    MappingDB200(statement, u);
                    res.Add(u);

                }
            }
            return (res);
        }
   
        private static void MappingDB200(ISQLiteStatement statement, Coach e)
        {
            e.Id = (long)statement["idCoach"];
            e.Name = (string)statement["coachName"];
            e.Age = (long)statement["coachAge"];
            e.CC = (long)statement["coachCC"];
        }


        public static bool CheckClass(long id)
        {
            bool res = false;
            DB db = DB.getDB(file);
            string query = @"SELECT * FROM Class r WHERE r.Coach_idCoach = ?";
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
