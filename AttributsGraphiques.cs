/*
 * Created by SharpDevelop.
 * User: kine
 * Date: 05/01/2022
 * Time: 17:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

using System.Drawing;
using System.Windows.Forms;

namespace Agenda
{
	/// <summary>
	/// Description of AttributsGraphiques.
	/// </summary>
	public class AttributsGraphiques
	{
		public MaDate aujourdhui = new MaDate();
		public bool jourCourant;
		public Dictionary<CreneauHoraire.ETAT, Color> couleursEtat;
		public Font fonteNomMois;
		public Color couleurNomMois;
		public int paddingTop;
					
		public Color couleurCase = Color.AliceBlue ;
		public Brush brushCases = Brushes.AliceBlue ;
		public int margeEntreCasesX = 10;
		public int margeHeure= 100;		
		public int hauteurNomJours = 20;
		public int hauteurLigne = 20;
		public int margeLigne = 2;
		
		public Color couleurAujourdhui = Color.Red;
		public Font fonteAujourdhui = SystemFonts.CaptionFont;
		
		public Color couleurJourCourant ;
		public Brush brushJourCourant = Brushes.DarkSlateBlue;
		
		public Font fonteBandeau= SystemFonts.CaptionFont;
		public Color couleurBandeau = Color.DarkSlateBlue;
		
		public Pen penCaseSelectionnee = new Pen( Color.Red, 4);
		public AttributsGraphiques()
		{
			couleursEtat = new Dictionary<CreneauHoraire.ETAT, Color>();
		}
		
		public Color getColor( CreneauHoraire.ETAT e)
		{
			if (couleursEtat.ContainsKey(e))
				return couleursEtat[e];
			
			return Color.Red;
		}
		
	}
}
