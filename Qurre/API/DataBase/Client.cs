using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace Qurre.API.DataBase
{
    public class Client
    {
        internal Client()
        {
            new Thread(() => _()).Start();
            void _()
            {
                Plugin.Config.GetString("Qurre_DataBase", "undefined", "Link-access to your database(MongoDB)");
                string _link = Plugin.Config.ConfigManager.GetDataBase("qurre_database");
                if (_link != "" && _link != "undefined")
                {
                    Enabled = true;
                    try
                    {
                        MClient = new MongoClient(_link);
                        Connected = true;
                    }
                    catch (Exception e) { Log.Error($"umm, error while connecting to MongoDB:\n{e}\n{e.StackTrace}"); }
                }
            }
        }
        public bool Enabled { get; internal set; }
        public bool Connected { get; internal set; }
        public static Client Static => Server.DataBase;
        internal MongoClient MClient { get; private set; }
        private protected readonly List<Database> DataBases = new();
        /// <summary>
        /// MongoDB hierarchy:
        /// <code>
        /// ⠀| Client
        /// ⠀| - DataBase
        /// ⠀   | - Collection
        /// ⠀      | - Document
        /// </code>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Database GetDatabase(string name)
        {
            var list = DataBases.Where(x => x.Name == name);
            if (list.Count() > 0) return list.First();
            Database _new = new(this, name);
            DataBases.Add(_new);
            return _new;
        }
    }
}