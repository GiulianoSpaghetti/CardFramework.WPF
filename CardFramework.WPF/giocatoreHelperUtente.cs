/*
  *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 1.1.3
 *
 *  Created by Giulio Sorrentino (numerone) on 29/01/23.
 *  Copyright 2023 Some rights reserved.
 *
 */


namespace org.altervista.numerone.framework

{
    /// <summary>
    /// Classe per modificare il comportamento della classe giocatore in base all'esperienza di gioco dell'utente
    /// </summary>
    public class GiocatoreHelperUtente : GiocatoreHelper
	{
		public GiocatoreHelperUtente()
		{
			;
		}
        /// <summary>
        /// restituisce la carta scelta dall'utente, cioè i, sempre se papabile
        /// </summary>
        /// <param name="i">carta scelta dall'utente</param>
        /// <param name="v">vettore delle carte</param>
        /// <param name="numeroCarte">dimensione del vettore delle carte</param>
        /// <returns>semplicemente i</returns>
        /// <exception cref="ArgumentException">se i non è nel range</exception>
        public UInt16 Gioca(UInt16 i, Carta[] v, UInt16 numeroCarte)
		{
			if (i < numeroCarte)
				return i;
			else
				throw new ArgumentException("");
		}
        /// <summary>
        /// Restituisce i se è una carta papabile, facendo eventualmente il controllo se è dello stesso seme della carta già giocata
        /// </summary>
        /// <param name="i">indice della carta da giocare</param>
        /// <param name="v">vettore delle carte</param>
        /// <param name="numeroCarte">dimensione del vettore delle carte</param>
        /// <param name="c">carta già giocata</param>
        /// <returns>i se è pababile</returns>
        /// <exception cref="Exception">la carta indicata non è pababile</exception>
        public UInt16 Gioca(UInt16 i, Carta[] v, UInt16 numeroCarte, Carta c)
		{
			return Gioca(i, v, numeroCarte);
		}
        /// <summary>
        /// Aggiorna il punteggio della struttura sulla base delle due carte giocate
        /// </summary>
        /// <param name="punteggioAttuale">il punteggio attuale</param>
        /// <param name="c">la prima carta giocata</param>
        /// <param name="c1">la seconda carta giocata</param>
        public void AggiornaPunteggio(ref UInt16 punteggioAttuale, Carta c, Carta c1)
		{
			punteggioAttuale = (UInt16)(punteggioAttuale + c.GetPunteggio() + c1.GetPunteggio());
		}
        /// <summary>
        /// metodo da richiamare in presenza del piatto, deve costruirsi i grafi di gioco
        /// </summary>
        /// <param name="i">indice dellc arta da giocare, da non considerare se è la cpu</param>
        /// <param name="v">vettore delle carte da guicare</param>
        /// <param name="numeroCarte">dimensione di v</param>
        /// <param name="piatto">lista delle carte per terra</param>
        /// <returns>indice di v indicante la carta scelta</returns>
        /// <exception cref="NotImplementedException">nella briscola questo metodo non è inizializzato</exception>
        public ushort Gioca(ushort i, Carta[] v, ushort numeroCarte, List<Carta> piatto)
        {
            throw new NotImplementedException();
        }
    };
}