/*
 * Created by SharpDevelop.
 * User: kine
 * Date: 05/01/2022
 * Time: 09:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Agenda.Database;
using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Agenda
{
    /// <summary>
    /// Description of CreneuHoraire.
    /// </summary>
    public class CreneauHoraire
    {
        public enum ETAT { LIBRE, RESERVE, ATTRIBUE, SPECIAL, FERIE, ANNULE_AVEC_PREAVIS, ANNULE_SANS_PREAVIS }
        private static string[] NOMS = { "Un", "Deux", "Trois", "Quatre" };
        private DateTime _dateCreation;
        private DateTime _dateModification;
        private ETAT _etat;
        private string _label;
        private Heure _heure;
        static Random r;

        static CreneauHoraire()
        {

            r = new Random((int)(DateTime.Now.Ticks % 99999));
        }


        public static CreneauHoraire creerCreneau()
        {
            return new CreneauHoraire();
        }

        public static CreneauHoraire creerCreneau(MaDate jour, Heure minutes)
        {
            MaDate creneau = jour.setHeure(minutes);
            SQLiteDataReader rdr = AgendaDatabase.Instance().getCreneau(creneau);
            if (rdr == null)
                return new CreneauHoraire(creneau);
            else
                return new CreneauHoraire(rdr);

        }
        private CreneauHoraire()
        {

            _etat = (ETAT)r.Next(6);
            _dateCreation = DateTime.Now;
            _dateModification = _dateCreation;
            _label = NOMS[r.Next(NOMS.Length)];
        }

        private CreneauHoraire(MaDate date)
        {
            _dateCreation = date.getDateTime();
            _dateModification = _dateCreation;
            _etat = ETAT.LIBRE;
            _label = "";
        }

        private CreneauHoraire(SQLiteDataReader rdr)
        {
            try
            {
                _etat = (ETAT)Convert.ToInt32(rdr[AgendaDatabase.CRENEAU_ETAT]);
                _dateCreation = new DateTime(Convert.ToInt64(rdr[AgendaDatabase.CRENEAU_DATE_CREATION]));
                _dateModification = new DateTime(Convert.ToInt64(rdr[AgendaDatabase.CRENEAU_DATE_MODIFICATION]));
                _label = Convert.ToString(rdr[AgendaDatabase.CRENEAU_LIBELLE]);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public void affiche(Graphics g, float x, float y, float l, int h, AttributsGraphiques attrs)
        {
            using (Brush b = new SolidBrush(attrs.getColor(_etat)))
                g.FillRectangle(b, x, y, l, h);

            switch (_etat)
            {
                case ETAT.LIBRE: afficheLibre(g, x, y, l, h); break;
                case ETAT.RESERVE: afficheReserve(g, x, y, l, h); break;
                case ETAT.ATTRIBUE: afficheLibre(g, x, y, l, h); break;
                case ETAT.FERIE: afficheLibre(g, x, y, l, h); break;
                case ETAT.SPECIAL: afficheLibre(g, x, y, l, h); break;
                case ETAT.ANNULE_AVEC_PREAVIS: afficheLibre(g, x, y, l, h); break;
                case ETAT.ANNULE_SANS_PREAVIS: afficheLibre(g, x, y, l, h); break;
            }
            g.DrawRectangle(new Pen(attrs.getColor(_etat)), x, y, l, h);
        }

        private void afficheLibre(Graphics g, float x, float y, float l, int h)
        {

        }

        private void afficheReserve(Graphics g, float x, float y, float l, int h)
        {
            Rectangle r = new Rectangle((int)x, (int)y, (int)l, (int)h);
            TextRenderer.DrawText(g, _label, SystemFonts.DefaultFont, r, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordEllipsis);
        }

        internal string getLabel()
        {
            return _label;
        }
    }
}
