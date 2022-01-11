using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Agenda.Database
{
    public class AgendaDatabase
    {
        private static AgendaDatabase _database = new AgendaDatabase();
        string _nomFichier;
        SQLiteConnection _connexion;
        // Table des creneaux
        public const string TABLE_CRENEAUX = "CRENEAUX";
        public const string CRENEAU_CRENEAU = "CRENEAU";
        public const string CRENEAU_ETAT = "ETAT";
        public const string CRENEAU_LIBELLE = "LIBELLE";
        public const string CRENEAU_DATE_CREATION = "DATE_CREATION";
        public const string CRENEAU_DATE_MODIFICATION = "DATE_MODIFICATION";

        /// <summary>
        /// Retrouve les creneaux associés à un jour
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        ///// <exception cref="NotImplementedException"></exception>
        //internal CreneauHoraire[] getCreneaux(MaDate date)
        //{
        //    try
        //    {
        //        MaDate debutJournee = date.getDebutJournee();
        //        MaDate finJournee = date.getFinJournee();

        //        using (SQLiteCommand cmd = new SQLiteCommand(_connexion))
        //        {
        //            cmd.CommandText = $"SELECT * FROM {TABLE_CRENEAUX} WHERE {CRENEAU_CRENEAU} >= @value_min AND {CRENEAU_CRENEAU} <= @value_max";

        //            cmd.Parameters.AddWithValue("@value_min", debutJournee.toSql());
        //            cmd.Parameters.AddWithValue("@price", finJournee.toSql());
        //            cmd.Prepare();
        //            using (SQLiteDataReader rdr = cmd.ExecuteReader())
        //            {
        //                CreneauHoraire[] creneaux = new CreneauHoraire[rdr.GetInt32(0)];
        //                int i = 0;
        //                while (rdr.Read())
        //                {
        //                    creneaux[i] = new CreneauHoraire(rdr);
        //                    i++;
        //                }

        //                return creneaux;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);

        //    }
        //    return null;
        //}

        internal SQLiteDataReader getCreneau(MaDate date)
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(_connexion))
                {
                    cmd.CommandText = $"SELECT * FROM {TABLE_CRENEAUX} WHERE {CRENEAU_CRENEAU} = @valeur";

                    cmd.Parameters.AddWithValue("@valeur", date.toSql());
                    cmd.Prepare();
                    SQLiteDataReader rdr = cmd.ExecuteReader();
                    if (rdr?.HasRows == true)
                        return rdr;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

            }
            return null;
        }


        private AgendaDatabase()
        {
            try
            {
                _nomFichier = getDbPath();
                creerBDSiNonExiste();
                _connexion = new SQLiteConnection("Data Source=" + _nomFichier);
                _connexion.Open();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        private void creerBDSiNonExiste()
        {
            try
            {
                if (!File.Exists(_nomFichier))
                {
                    // Creer la base de donnees
                    SQLiteConnection.CreateFile(_nomFichier);

                    using (var sqlite2 = new SQLiteConnection($"Data Source={_nomFichier}"))
                    {
                        sqlite2.Open();
                        string sql = $"CREATE TABLE {TABLE_CRENEAUX}( {CRENEAU_CRENEAU} INTEGER  PRIMARY KEY NOT NULL, {CRENEAU_ETAT} INTEGER NOT NULL, {CRENEAU_LIBELLE} STRING  NOT NULL, {CRENEAU_DATE_CREATION} INTEGER  NOT NULL, {CRENEAU_DATE_MODIFICATION} INTEGER  NOT NULL)";
                        SQLiteCommand command = new SQLiteCommand(sql, sqlite2);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        private string getDbPath()
        {
            string repertoire = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Agenda");
            if (!Directory.Exists(repertoire))
                Directory.CreateDirectory(repertoire);
            return Path.Combine(repertoire, "agenda.sqlite");
        }

        public static AgendaDatabase Instance()
        {
            return _database;
        }
    }
}
