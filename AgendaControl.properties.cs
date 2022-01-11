/*
 * Created by SharpDevelop.
 * User: kine
 * Date: 05/01/2022
 * Time: 09:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

using System.ComponentModel;
namespace Agenda
{
	/// <summary>
	/// Description of AgendaControl_Properties.
	/// </summary>
	public partial class AgendaControl
	{

		[Browsable(true)]
		[Category("Agenda")]
		[Description("Couleur des cases")]
		[DisplayName("Couleur cases")]
		public Color CouleurCase
		{
			get { return _attributsGraphiques.couleurCase; }
			set { _attributsGraphiques.couleurCase = value; _attributsGraphiques.brushCases = new SolidBrush(_attributsGraphiques.couleurCase); Invalidate(); }
		}

		[Browsable(true)]
		[Category("Agenda")]
		[Description("Couleur du jour courant")]
		[DisplayName("Couleur jour courant")]
		public Color CouleurJourCourant
		{
			get { return _attributsGraphiques.couleurJourCourant; }
			set { _attributsGraphiques.couleurJourCourant = value; _attributsGraphiques.brushJourCourant = new SolidBrush(_attributsGraphiques.couleurJourCourant); Invalidate(); }
		}

		[Browsable(true)]
		[Category("Agenda")]
		[Description("Couleur bandeau")]
		[DisplayName("Couleur bandeau")]
		public Color CouleurBandeau
		{
			get { return _attributsGraphiques.couleurBandeau; }
			set { _attributsGraphiques.couleurBandeau = value; Invalidate(); }
		}


		[Browsable(true)]
		[Category("Agenda")]
		[Description("Fonte bandeau")]
		[DisplayName("Fonte bandeau")]
		public Font FonteBandeau
		{
			get { return _attributsGraphiques.fonteBandeau; }
			set { _attributsGraphiques.fonteBandeau = value; Invalidate(); }
		}

		[Browsable(true)]
		[Category("Agenda")]
		[Description("Couleur aujourd'hui")]
		[DisplayName("Couleur aujourd'hui")]
		public Color CouleurAujourdhui
		{
			get { return _attributsGraphiques.couleurAujourdhui; }
			set { _attributsGraphiques.couleurAujourdhui = value; Invalidate(); }
		}


		[Browsable(true)]
		[Category("Agenda")]
		[Description("Fonte aujourd'hui")]
		[DisplayName("Fonte aujourd'hui")]
		public Font FonteAujourdhui
		{
			get { return _attributsGraphiques.fonteAujourdhui; }
			set { _attributsGraphiques.fonteAujourdhui = value; Invalidate(); }
		}
		[Browsable(true)]
		[Category("Agenda")]
		[Description("Marge à gauche pour les heures")]
		[DisplayName("Marge heure")]
		public int MargeHeure
		{
			get { return _attributsGraphiques.margeHeure; }
			set { _attributsGraphiques.margeHeure = value; Invalidate(); }
		}

		[Browsable(true)]
		[Category("Agenda")]
		[Description("Marge en haut de la fenêtre")]
		[DisplayName("Padding Top")]
		public int PaddingTop
		{
			get { return _attributsGraphiques.paddingTop; }
			set { _attributsGraphiques.paddingTop = value; Invalidate(); }
		}

		[Browsable(true)]
		[Category("Agenda")]
		[Description("Hauteur du nom des jours")]
		[DisplayName("Hauteur nom jours")]
		public int HauteurNomJours
		{
			get { return _attributsGraphiques.hauteurNomJours; }
			set { _attributsGraphiques.hauteurNomJours = value; Invalidate(); }
		}

		[Browsable(true)]
		[Category("Agenda")]
		[Description("Hauteur des lignes")]
		[DisplayName("Hauteur ligne")]
		public int HauteurLigne
		{
			get { return _attributsGraphiques.hauteurLigne; }
			set { _attributsGraphiques.hauteurLigne = value; Invalidate(); }
		}


		[Browsable(true)]
		[Category("Agenda")]
		[Description("Marge entre les lignes")]
		[DisplayName("Marge ligne")]
		public int MargeLigne
		{
			get { return _attributsGraphiques.margeLigne; }
			set { _attributsGraphiques.margeLigne = value; Invalidate(); }
		}


	}
}
