/*
 * Created by SharpDevelop.
 * User: kine
 * Date: 04/01/2022
 * Time: 18:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;

namespace Agenda
{
	/// <summary>
	/// Description of Heure.
	/// </summary>
	public class Heure
	{
		private int _minutes;
		public const int MINUTES_PAR_HEURE = 60;
		public const int MINUTES_PAR_DEMI_HEURE = 30;
		public const int HEURE_DEBUT = 8 * MINUTES_PAR_HEURE ;
		public const int HEURE_FIN = (19 * MINUTES_PAR_HEURE) + 30 ;
		public static  Heure HeureDebut = new Heure( 8, 0);
		public static  Heure HeureFin = new Heure( 19, 30);
		public static int CalculeMinute( int heures, int minutes)
		{
			return heures* MINUTES_PAR_HEURE + minutes;
		}
		
		
		public Heure()
		{
		_minutes = 	HEURE_DEBUT;
		}
		
		public Heure( int heures, int minutes)
		{
			_minutes = CalculeMinute(heures, minutes);
		}
		
		public override String ToString()
		{
			int heure = _minutes / MINUTES_PAR_HEURE;
			int minutes = _minutes - (heure * MINUTES_PAR_HEURE);
			return heure.ToString("00") + ":" + minutes.ToString("00");
		}
		
		public void HeureSuivante()
		{
			_minutes += MINUTES_PAR_HEURE;
		}
		
		public void DemiHeureSuivante()
		{
			_minutes += MINUTES_PAR_DEMI_HEURE;
		}

        internal int getMinutes()
        {
			return _minutes % MINUTES_PAR_HEURE;
        }

        internal int getHeure()
        {
			return _minutes / MINUTES_PAR_HEURE; ;
        }

        public Heure Clone ()
        {
			Heure h = new Heure(0,0);
			h._minutes = _minutes;
			return h;
        }
		public static bool operator <= (Heure a, Heure b) 
		{ 
			return a._minutes <= b._minutes;
		}
		public static bool operator >= (Heure a, Heure b) { return a._minutes >= b._minutes;}
	}
}
