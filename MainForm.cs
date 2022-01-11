using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class MainForm : Form
    {
		private MaDate _dateCourante = new MaDate();
		public MainForm()
        {
            InitializeComponent();
        }

		void onSemainPrec(object sender, EventArgs e)
		{
			_dateCourante.semainePrecedente();
			agendaControl.setDate(_dateCourante);
		}

		void onJourPrec(object sender, EventArgs e)
		{
			_dateCourante.jourPrecedent();
			agendaControl.setDate(_dateCourante);
		}

		void onJourSuiv(object sender, EventArgs e)
		{
			_dateCourante.jourSuivant();
			agendaControl.setDate(_dateCourante);
		}

		void onSemaineSuiv(object sender, EventArgs e)
		{
			_dateCourante.semaineSuivante();
			agendaControl.setDate(_dateCourante);
		}

		void onAujourdhui(object sender, EventArgs e)
		{
			_dateCourante = new MaDate();
			agendaControl.setDate(_dateCourante);
		}
	}
}
