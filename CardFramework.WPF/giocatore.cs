/*
  *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 1.1.3
 *
 *  Created by Giulio Sorrentino (numerone) on 29/01/23.
 *  Copyright 2023 Some rights reserved.
 *
 */

using System.Windows.Media.Imaging;

namespace org.altervista.numerone.framework
{
    /// <summary>
    /// Identifica il giocatore
    /// </summary>
    public class Giocatore
	{
        /// <summary>
        /// nome del giocatore
        /// </summary>
        private string nome;
        /// <summary>
        /// la mano del giocatire
        /// </summary>
        private Carta[] mano;
        /// <summary>
        /// se la mano deve essere ordinata
        /// </summary>
        private bool ordinaMano;
        /// <summary>
        /// numero di carrte presenti nella mano, indice della carta presa in esame che è globale, indice della carta giocata e punteggio
        /// </summary>
        private UInt16 numeroCarte, iCarta, iCartaGiocata, punteggio;
        /// <summary>
        /// numero totale di carte presenti nella mano
        /// </summary>
        private readonly UInt16 totaleCarte;
        /// <summary>
        /// helper che condiziona il comportamento della struttura
        /// </summary>
        private readonly GiocatoreHelper helper;
		public enum CARTA_GIOCATA { NESSUNA_CARTA_GIOCATA = UInt16.MaxValue };
        /// <summary>
        /// inzializza la struttura
        /// </summary>
        /// <param name="h">modifica il comportamento della struttura</param>
        /// <param name="n">nome del giocatore</param>
        /// <param name="carte">numero di carte in mano al giocatore</param>
        /// <param name="ordina">se la mano deve essere ordinata</param>
        public Giocatore(GiocatoreHelper h, string n, UInt16 carte, bool ordina = true)
		{
			totaleCarte = carte;
			ordinaMano = ordina;
			numeroCarte = carte;
			iCartaGiocata = (UInt16)(CARTA_GIOCATA.NESSUNA_CARTA_GIOCATA);
			punteggio = 0;
			helper = h;
			nome = n;
			mano = new Carta[totaleCarte];
			iCarta = 0;
		}
        /// <summary>
        /// Getter del nome
        /// </summary>
        /// <returns>il nome del giocatore</returns>
        public string GetNome() { return nome; }
        /// <summary>
        /// setter del nome
        /// </summary>
        /// <param name="n">nome del giocatore</param>
        public void SetNome(string n) { nome = n; }
        /// <summary>
        /// setter del flag di ordinamento della mano
        /// </summary>
        /// <returns>se la mano deve essere ordinata o meno</returns>
        public bool GetFlagOrdina() { return ordinaMano; }
        /// <summary>
        /// settere del flag di oprdinameno della mano
        /// </summary>
        /// <param name="ordina"></param>
        public void SetFlagOrdina(bool ordina) { ordinaMano = ordina; }
        /// <summary>
        /// Aggiunge una carta nella mano del giocatore, eventualmente ordinando e sostituendo la carta già giocata in precedenza se esiste. Se il mazzo non ha carte compatta la mano e diminuisce numeroCarte, ma non totaleCarte
        /// </summary>
        /// <param name="m">mazzo da cui prendere la carta</param>
        /// <exception cref="ArgumentException">Se si supera il massimo delle carte contenibili</exception>
        public void AddCarta(Mazzo m)
		{
			UInt16 i = 0;
			Carta temp;
			if (iCarta == numeroCarte && iCartaGiocata == (UInt16)CARTA_GIOCATA.NESSUNA_CARTA_GIOCATA)
				throw new ArgumentException($"Chiamato Giocatore::setCarta con mano.size()==numeroCarte=={numeroCarte}");
			if (iCartaGiocata != (UInt16)CARTA_GIOCATA.NESSUNA_CARTA_GIOCATA)
			{
				for (i = iCartaGiocata; i < numeroCarte - 1; i++)
					mano[i] = mano[i + 1];
				mano[i] = null;
				iCartaGiocata = (UInt16)CARTA_GIOCATA.NESSUNA_CARTA_GIOCATA;
				mano[iCarta - 1] = SostituisciCartaGiocata(m);
				for (i = (UInt16)(iCarta - 2); i < UInt16.MaxValue && iCarta > 1 && mano[i].CompareTo(mano[i + 1]) < 0; i--)
				{
					temp = mano[i];
					mano[i] = mano[i+1];
					mano[i+1] = temp;
				}
				return;
			}
			Ordina(m);


		}
        /// <summary>
        /// Ordina la mano con l'insertion sort
        /// </summary>
        /// <param name="m">mazzo da cui prendere la carta</param>
        private void Ordina(Mazzo m)
		{
			UInt16 i = 0;
			UInt16 j = 0;
			Carta c = SostituisciCartaGiocata(m);
			for (i = 0; i < iCarta && mano[i] != null && c.CompareTo(mano[i]) < 0; i++) ;
			for (j = (UInt16)(numeroCarte - 1); j > i; j--)
				mano[j] = mano[j - 1];
			mano[i] = c;
			iCarta++;
		}
        /// <summary>
        /// Sostituisce la carta giocata con una fresca presa dal mazzo, se non ci sono più carrte nel mazzo diminuisce numeroCarte ed iCarta
        /// </summary>
        /// <param name="m">mazzo da cui prendere la carta giocata</param>
        /// <returns>la carta da aggiungere</returns>
        private Carta SostituisciCartaGiocata(Mazzo m)
		{
			Carta c;
			try
			{
				c = Carta.GetCarta(m.GetCarta());
			}
			catch (IndexOutOfRangeException e)
			{
				numeroCarte--;
				iCarta--;
				if (numeroCarte == 0)
					throw e;
				return mano[numeroCarte];
			}
			return c;
		}
        /// <summary>
        /// getter della carta giocata
        /// </summary>
        /// <returns>la struttura indicante la carta giocata</returns>
        public Carta GetCartaGiocata()
		{
			return mano[iCartaGiocata];
		}
        /// <summary>
        /// setter del punteggio
        /// </summary>
        /// <returns>retituisce il punteggio corrente</returns>
        public UInt16 GetPunteggio() { return punteggio; }
        /// <summary>
		/// Se è l'utente imposta la carta giocata come i, se è il computer elabora una carta da giocare essendo il primo di mano
		/// </summary>
		/// <param name="i">vale solo come utente, indice della carta da giocare</param>
		public void Gioca(UInt16 i)
		{
			iCartaGiocata = helper.Gioca(i, mano, numeroCarte);
		}
        /// <summary>
        /// Se è l'utente imposta la carta giocata come i, se è il computer elabora una carta da giocare essendo il secondo di mano
        /// </summary>
        /// <param name="i">vale solo come utente, indice della carta da giocae</param>
        /// <param name="g1">primo di mano</param>
        public void Gioca(UInt16 i, Giocatore g1)
		{
			iCartaGiocata = helper.Gioca(i, mano, numeroCarte, g1.GetCartaGiocata());
		}
        /// <summary>
        /// Se è l'utente deve impostare iCartaGiocata ad i, se è il computer deve costruirsi i grafi di presa sulla base delle carte in mano e del piatto per stabilirsi cosa giocare
        /// </summary>
        /// <param name="i">vale solo se è l'utente, numero della carta da giocare</param>
        /// <param name="piatto">il piatto</param>
        public void Gioca(UInt16 i, List<Carta> piatto)
        {
            iCartaGiocata = helper.Gioca(i, mano, numeroCarte, piatto);
        }
        /// <summary>
        /// Aggiorna il puntegio sulla base delle carte giocate
        /// </summary>
        /// <param name="g">l'altro giocatore</param>
        /// <returns>il punteggio attuale</returns>
        public UInt16 AggiornaPunteggio(Giocatore g)
		{
			helper.AggiornaPunteggio(ref punteggio, GetCartaGiocata(), g.GetCartaGiocata());
            return punteggio;
		}
        /// <summary>
		/// retituisce l'immagine della carta indicata in mano all'utente
		/// </summary>
		/// <param name="quale">numero della carta in mano all'utente</param>
		/// <returns>l'immagine della carta</returns>
        public BitmapImage GetImmagine(UInt16 quale)
        {
            return mano[quale].GetImmagine();
        }

        /// <summary>
        /// retituisce l'indice della carta giocata in mano all'utente
        /// </summary>
        /// <returns>indice della carta giocata in mano all'utente, può essere NESSUNA_CARTA_GIOCATA</returns>
        public UInt16 GetICartaGiocata()
		{
			return iCartaGiocata;
		}
        /// <summary>
		/// retituisce il numero di carte in mano all'utente
		/// </summary>
		/// <returns>il numero di carte in mano all'utente, che può essere inferiore a totaleCarte se il mazzo è finito</returns>
		public UInt16 GetNumeroCarte()
		{
			return numeroCarte;
		}
	}

}