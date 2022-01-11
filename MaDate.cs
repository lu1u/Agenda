/*
 * Created by SharpDevelop.
 * User: kine
 * Date: 04/01/2022
 * Time: 14:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;

namespace Agenda
{
	/// <summary>
	/// Description of MaDate.
	/// </summary>
	public class MaDate
	{
		public const int JOUR = 1;
		public const int JOUR_DU_MOIS = 2;
		public const int MOIS = 4;
		public const int ANNEE = 8;
		private DateTime _date;
		public MaDate()
		{
			_date = DateTime.Now;
		}
		
		public MaDate(DateTime date)
		{
			_date = date;
		}
		
		public string ToString(int format = JOUR_DU_MOIS | JOUR | MOIS | ANNEE)
		{
			string res = "";
			if ((format & JOUR_DU_MOIS) != 0)
				ajoute( ref res,  JourSemaine());
			if ((format & JOUR) != 0)
				ajoute(ref res, ""+_date.Day);
			if ((format & MOIS) != 0)
				ajoute(ref res,  Mois());
			
			if ( (format & ANNEE) != 0)
				ajoute( ref res, "" + _date.Year);
			return res;
		}
		
		void ajoute(ref string res, string valeur)
		{
			if ( res.Length>0)
				res += " ";
			res += valeur;
		}

        internal MaDate setHeure(Heure heure)
        {
			DateTime t = new DateTime(_date.Year, _date.Month, _date.Day, heure.getHeure(), heure.getMinutes(), 0);
			return new MaDate(t);
		}

        internal MaDate getDebutJournee()
        {
			DateTime t = new DateTime(_date.Year, _date.Month, _date.Day, 0,0,0) ;
			return new MaDate(t);
        }

		internal MaDate getFinJournee()
		{
			DateTime t = new DateTime(_date.Year, _date.Month, _date.Day, 23, 59, 59);
			return new MaDate(t);
		}

        internal long toSql()
        {
            return long.Parse(_date.ToString("yyyyMMddHHmmss"));
		}

		internal MaDate fromSql(long sql)
        {
			int ss = (int)(sql % 100L);
			sql = sql / 100;
			int mm = (int)(sql % 100L);
			sql = sql / 100;
			int HH = (int)(sql % 100L);
			sql = sql / 100;
			int dd = (int)(sql % 100L);
			sql = sql / 100;
			int MM = (int)(sql % 100L);
			sql = (int)(sql % 100L);
			int yyyy = (int)sql ;
			DateTime d = new DateTime(yyyy, MM, dd, HH, mm, ss);
			return new MaDate(d);
		}

        internal DateTime getDateTime()
        {
			return _date;
        }

        public MaDate getJourSuivant()
		{
			MaDate d = new MaDate(_date);
			d.jourSuivant();
			return d;
		}
		
		public void jourPrecedent()
		{
			_date = _date.AddDays(-1);
		}
		
		public void jourSuivant()
		{
			_date = _date.AddDays(1);
		}
		
		public MaDate getSemainePrecedente()
		{
			return new MaDate(_date.AddDays(-7));
		}
		
		
		public MaDate getSemaineSuivante()
		{
			return new MaDate(_date.AddDays(7));
		}
		
		public void semainePrecedente()
		{
			_date =_date.AddDays(-7);
		}
		
		public void semaineSuivante()
		{
			_date =_date.AddDays(7);
		}
		
		public MaDate premierJourDeLaSemaine()
		{
			//DayOfWeek first = DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek;
			//return new MaDate(_date.AddDays(-((int)_date.DayOfWeek - (int)DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek)));
			
			DayOfWeek firstDay = DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek;
			DateTime firstDayInWeek = _date.Date;
			while (firstDayInWeek.DayOfWeek != firstDay)
				firstDayInWeek = firstDayInWeek.AddDays(-1);

			return new MaDate(firstDayInWeek);
		}
		
		public String JourSemaine()
		{
			int jour = ((int)_date.DayOfWeek) % 7;
			return DateTimeFormatInfo.CurrentInfo.GetDayName(_date.DayOfWeek);
		}
		
		public String Mois()
		{
			return DateTimeFormatInfo.CurrentInfo.GetMonthName(_date.Month);
		}
		
		public bool memeJour(MaDate date)
		{
			if ( _date.Year != date._date.Year)
				return false;
			if ( _date.Month != date._date.Month)
				return false;
			return _date.Day == date._date.Day;
		}
		
		public int  Annee()
		{
			return _date.Year;
		}
		
		public int getNoSemaine()
		{
			CultureInfo ciCurr = CultureInfo.CurrentCulture;
			int weekNum = ciCurr.Calendar.GetWeekOfYear(_date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
			return weekNum;
		}
	}
}
