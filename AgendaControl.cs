/*
 * Created by SharpDevelop.
 * User: kine
 * Date: 04/01/2022
 * Time: 14:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Agenda.Database;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Agenda
{
	/// <summary>
	/// Description of AgendaControl.
	/// </summary>
	public partial class AgendaControl : UserControl
	{
		public const int NB_JOURS_SEMAINE = 7;
		private MaDate _dateCourante = new MaDate();
		private Jour[] _jours = new Jour[NB_JOURS_SEMAINE];
		private AttributsGraphiques _attributsGraphiques = new AttributsGraphiques();
        private AgendaDatabase _database;
		private int _jourSelectionne = -1;
		public AgendaControl()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_database = AgendaDatabase.Instance();
		}




		void onResize(object sender, EventArgs e)
		{
			Invalidate();
		}

		void onLoad(object sender, EventArgs e)
		{
			MaDate d = _dateCourante.premierJourDeLaSemaine();

			for (int i = 0; i < NB_JOURS_SEMAINE; i++)
			{
				_jours[i] = new Jour(d);
				d = d.getJourSuivant();
			}
			_attributsGraphiques.couleursEtat.Add(CreneauHoraire.ETAT.LIBRE, Color.FromArgb(16, 0, 0, 0));
			_attributsGraphiques.couleursEtat.Add(CreneauHoraire.ETAT.RESERVE, Color.AntiqueWhite);
			_attributsGraphiques.couleursEtat.Add(CreneauHoraire.ETAT.ATTRIBUE, Color.Beige);
			_attributsGraphiques.couleursEtat.Add(CreneauHoraire.ETAT.SPECIAL, Color.Bisque);
			_attributsGraphiques.couleursEtat.Add(CreneauHoraire.ETAT.FERIE, Color.GhostWhite);
			_attributsGraphiques.couleursEtat.Add(CreneauHoraire.ETAT.ANNULE_AVEC_PREAVIS, Color.BurlyWood);
			_attributsGraphiques.couleursEtat.Add(CreneauHoraire.ETAT.ANNULE_SANS_PREAVIS, Color.BlanchedAlmond);
			_attributsGraphiques.couleurNomMois = ForeColor;
			_attributsGraphiques.fonteNomMois = Font;
		}

		public void setDate(MaDate date)
		{
			_dateCourante = date;
			MaDate d = _dateCourante.premierJourDeLaSemaine();

			for (int i = 0; i < NB_JOURS_SEMAINE; i++)
			{
				_jours[i] = new Jour(d);
				d = d.getJourSuivant();
			}

			Invalidate();
		}


		void onKeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left:
					_dateCourante.jourPrecedent();
					setDate(_dateCourante);
					break;

				case Keys.Right:
					_dateCourante.jourSuivant();
					setDate(_dateCourante);
					break;

				case Keys.PageDown:
					_dateCourante.semaineSuivante();
					setDate(_dateCourante);
					break;

				case Keys.PageUp:
					_dateCourante.semainePrecedente();
					setDate(_dateCourante);
					break;
				case Keys.Home:
					_dateCourante = new MaDate();
					setDate(_dateCourante);
					break;
			}
		}

		void onPaint(object sender, PaintEventArgs e)
		{
			_attributsGraphiques.aujourdhui = new MaDate();

			MaDate jour = _dateCourante.premierJourDeLaSemaine();
			Debug.WriteLine("Jour courant: " + _dateCourante.ToString());
			Debug.WriteLine("Premier jour de la semaine: " + jour.ToString());

			float X = ClientRectangle.Left + _attributsGraphiques.margeHeure;
			float largeurColonne = ((ClientRectangle.Right - X) / 7.0f);
			float Y = ClientRectangle.Top + _attributsGraphiques.paddingTop;
			float H = ClientRectangle.Height - Y - 1;
			// Entete: mois/annee du premier jour de la semaine, mois/annee du dernier
			String message = _jours[0].getNomMois() + " " + _jours[0].getAnnee();
			TextRenderer.DrawText(e.Graphics, message, _attributsGraphiques.fonteBandeau, ClientRectangle, _attributsGraphiques.couleurBandeau, TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordEllipsis);
			message = _jours[NB_JOURS_SEMAINE - 1].getNomMois() + " " + _jours[NB_JOURS_SEMAINE - 1].getAnnee();
			TextRenderer.DrawText(e.Graphics, message, _attributsGraphiques.fonteBandeau, ClientRectangle, _attributsGraphiques.couleurBandeau, TextFormatFlags.Right | TextFormatFlags.Top | TextFormatFlags.WordEllipsis);

			message = "Semaine " + _dateCourante.getNoSemaine();
			TextRenderer.DrawText(e.Graphics, message, _attributsGraphiques.fonteBandeau, ClientRectangle, _attributsGraphiques.couleurBandeau, TextFormatFlags.HorizontalCenter | TextFormatFlags.Top | TextFormatFlags.WordEllipsis);

			// Jours
			for (int i = 0; i < NB_JOURS_SEMAINE; i++)
			{
				_attributsGraphiques.jourCourant = _jours[i].date.memeJour(_dateCourante);
				Rectangle r = new Rectangle((int)(X + (i * largeurColonne)), (int)Y, (int)largeurColonne - _attributsGraphiques.margeEntreCasesX, (int)H);
				_jours[i].affiche(e.Graphics, r, _attributsGraphiques);
			}

			// Horaires
			Y = ClientRectangle.Top + _attributsGraphiques.paddingTop + _attributsGraphiques.hauteurNomJours;
			Heure h = new Heure();
			while (h <= Heure.HeureFin)
			{
				Rectangle r = new Rectangle(ClientRectangle.Left, (int)Y, _attributsGraphiques.margeHeure, _attributsGraphiques.hauteurLigne);
				TextRenderer.DrawText(e.Graphics, h.ToString(), Font, r, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.Top | TextFormatFlags.WordEllipsis);

				//e.Graphics.DrawString( h.ToString(), Font, Brushes.Black, ClientRectangle.Left, Y);
				h.DemiHeureSuivante();
				Y += _attributsGraphiques.hauteurLigne;
			}

		}


		void onMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.X > _attributsGraphiques.margeHeure)
			{
				int X = e.X - _attributsGraphiques.margeHeure;
				int largeurColonne = (ClientRectangle.Width - _attributsGraphiques.margeHeure) / NB_JOURS_SEMAINE;
				if (largeurColonne > 0)
				{
					int noJour = X / largeurColonne;
					if (noJour >= 0 && noJour < NB_JOURS_SEMAINE)
					{
						_jourSelectionne = noJour;
						setDate(_jours[noJour].date);

						int Y = e.Y - (ClientRectangle.Top + _attributsGraphiques.paddingTop + _attributsGraphiques.hauteurNomJours);
						_jours[noJour].onClick(Y, _attributsGraphiques);
					}
				}
			}
		}

        private void onDoubleClic(object sender, MouseEventArgs e)
        {
			if (_jourSelectionne < 0 || _jourSelectionne >= _jours.Length)
				return;

			CreneauHoraire c = _jours[_jourSelectionne].getSelectionne();
			if (c == null)
				return;

			EditionCreneau editionCreneau = new EditionCreneau();
			editionCreneau.labelJour.Text = _jours[_jourSelectionne].date.ToString();
			editionCreneau.labelHeure.Text = _jours[_jourSelectionne].getHeureSelectionnee().ToString();
			editionCreneau.textBoxLabel.Text = c.getLabel();

			if ( editionCreneau.ShowDialog(this) == DialogResult.OK)
            {

            }
        }
    }
}
