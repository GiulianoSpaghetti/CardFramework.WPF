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
    /// Interfaccia per modificare il comportamento della classe mazzo in base al gioco della briscola
    /// </summary>
    public class ElaboratoreCarteBriscola : ElaboratoreCarte
	{
        /// <summary>
        /// numero dellec carte, valore minimo e massimo dei numeri random da elaborare
        /// </summary>
        private UInt16 numeroCarte, min, max;
        /// <summary>
        /// se una carta è già uscita
        /// </summary>
        private bool[] doppione;
        /// <summary>
        /// la carta di briscola, la prima ad uscire
        /// </summary>
        private static UInt16 CartaBriscola;
        /// <summary>
        /// indica se la carta di briscola deve essere salvata e se può essere di peso
        /// </summary>
        private bool inizio,
				 briscolaDaPunti;
		public static Random r = new Random();
        /// <summary>
        /// costruttore che inizializza la struttura, compresi i numeri da elaborare
        /// </summary>
        /// <param name="punti">se la carta di briscola può avere peso</param>
        /// <param name="a">numero totale di carte da elaborare</param>
        /// <param name="m">valore della prima carta</param>
        /// <param name="n">valore della seconda carta</param>
        /// <exception cref="ArgumentException">se il numero totale di carte da chiamare non corrisponde a min+max-1</exception>
        public ElaboratoreCarteBriscola(bool punti = true, UInt16 a=40, UInt16 m=0, UInt16 n=39)
		{
			inizio = true;
			briscolaDaPunti = punti;
			numeroCarte = a;
			min = m;
			max = n;
			if (numeroCarte!=max-min+1)
				throw new ArgumentException("Chiamata ad elaboratorecartebriscola con numeroCarte!=max-min+1");
            doppione = new bool[min+numeroCarte];
			for (int i = 0; i <min+numeroCarte; i++)
				doppione[i] = i<min;
		}
        /// <summary>
        /// elabora la prossima carta da mettere nel mazzo
        /// </summary>
        /// <returns>la prossima carta da mettere nel mazzo</returns>
        /// <exception cref="ArgumentException">se si raggiunge il numero massimo di carte</exception>
        public UInt16 GetCarta()
		{
			UInt16 fine = (UInt16)(r.Next(min, max)),
			Carta = (UInt16)((fine + 1) % (min+numeroCarte));
			while (doppione[Carta] && Carta != fine)
				Carta = (UInt16)((Carta + 1) % (min+numeroCarte));
			if (doppione[Carta])
				throw new ArgumentException("Chiamato elaboratoreCarteItaliane::getCarta() quando non ci sono più carte da elaborare");
			else
			{
				if (inizio)
				{
					UInt16 valore = (UInt16)(Carta % 10);
					if (!briscolaDaPunti && (valore == 0 || valore == 2 || valore > 6))
					{
						Carta = (UInt16)(Carta - valore + 1);
					}
					CartaBriscola = Carta;
					inizio = false;
				}
				doppione[Carta] = true;
				return Carta;
			}
		}
        /// <summary>
        /// restituisce la carta di briscola
        /// </summary>
        /// <returns>la carta di briscola in formato intero</returns>
        public static UInt16 GetCartaBriscola() { return CartaBriscola; }
        /// <summary>
        /// Dice quante carte sono rimaste nel mazzo
        /// </summary>
        /// <returns>Retituisce il numero di carte nel mazzo</returns>
        public ushort GetNumeroCarte()
		{
			return numeroCarte;
		}
	}
}