/*
 * Created by SharpDevelop.
 * User: kine
 * Date: 05/01/2022
 * Time: 14:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Agenda
{
	/// <summary>
	/// Description of Jour.
	/// </summary>
	public class Jour
	{
		public const int NB_CRENEAUX = 24;
		private MaDate _date;
		private int _selectionne = -1 ;
		
		private CreneauHoraire[] _creneaux = new CreneauHoraire[NB_CRENEAUX];
		public Jour(MaDate date)
		{
			_date = date;
			MaDate aujourdhui = _date.getDebutJournee();
			Heure h = Heure.HeureDebut.Clone();
			for (int i = 0; i < NB_CRENEAUX; i++)
			{
				_creneaux[i] = CreneauHoraire.creerCreneau(aujourdhui, h);
				h.DemiHeureSuivante();
			}
		}
		
		public CreneauHoraire get(int i)
		{
			return _creneaux[i];
		}

		internal CreneauHoraire getSelectionne()
		{
			if (_selectionne < 0 || _selectionne >= NB_CRENEAUX)
				return null;

			return _creneaux[_selectionne];
		}
		public MaDate date { get { return _date;}}
		
		public void affiche(Graphics graphics, Rectangle r, AttributsGraphiques attributsGraphiques)
		{
			if ( attributsGraphiques.jourCourant)
			{
				graphics.FillRectangle(attributsGraphiques.brushJourCourant, r);
			}
			
			if ( _date.memeJour(attributsGraphiques.aujourdhui))
				TextRenderer.DrawText(graphics, _date.ToString(MaDate.JOUR | MaDate.JOUR_DU_MOIS| MaDate.MOIS), attributsGraphiques.fonteAujourdhui, r, attributsGraphiques.couleurAujourdhui, TextFormatFlags.HorizontalCenter | TextFormatFlags.Top|TextFormatFlags.WordEllipsis );
			else
				// Afficher le nom du jour
				TextRenderer.DrawText(graphics, _date.ToString(MaDate.JOUR | MaDate.JOUR_DU_MOIS| MaDate.MOIS), attributsGraphiques.fonteNomMois, r, attributsGraphiques.couleurNomMois, TextFormatFlags.HorizontalCenter | TextFormatFlags.Top|TextFormatFlags.WordEllipsis );
			
			// Creneaux
			for ( int i = 0; i < NB_CRENEAUX;i++)
			{
				float Y = r.Top  + attributsGraphiques.hauteurNomJours + (i*attributsGraphiques.hauteurLigne);
				
					
				CreneauHoraire c = _creneaux[i];
				c.affiche(graphics, r.Left+ attributsGraphiques.margeEntreCasesX, Y, r.Width- attributsGraphiques.margeEntreCasesX*2, attributsGraphiques.hauteurLigne - attributsGraphiques.margeLigne, attributsGraphiques);
				if ( i == _selectionne)
				{
					graphics.DrawRectangle(attributsGraphiques.penCaseSelectionnee,  r.Left+ attributsGraphiques.margeEntreCasesX, Y, r.Width- attributsGraphiques.margeEntreCasesX*2, attributsGraphiques.hauteurLigne - attributsGraphiques.margeLigne);
				}
			}
			
		}
		
		public String getNomMois()
		{
			return _date.Mois();
		}
		
		public int getAnnee()
		{
			return _date.Annee();
		}
		
		public void onClick(int y, AttributsGraphiques attributsGraphiques)
		{
			int noLigne = y / attributsGraphiques.hauteurLigne;
			if ( noLigne>=0 && noLigne<NB_CRENEAUX)
				_selectionne = noLigne;
		}

        internal Heure getHeureSelectionnee()
        {
            Heure heure = new Heure();
			for (int i = 0; i < _selectionne; i++)
            {
				heure.DemiHeureSuivante();
            }

			return heure;
        }
    }
}
