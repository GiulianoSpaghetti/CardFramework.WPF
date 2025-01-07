/*
  *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 1.1.3
 *
 *  Created by Giulio Sorrentino (numerone) on 29/01/23.
 *  Copyright 2023 Some rights reserved.
 *
 */

using System.Windows;
namespace org.altervista.numerone.framework.briscola
{
    /// <summary>
    /// Interfaccia per modificare il comportamento della classe carta in base al gioco della briscola
    /// </summary>
    public class CartaHelper : org.altervista.numerone.framework.CartaHelper {
        /// <summary>
        /// numer intero indicante la carta di briscola, viene salvato per il compareto
        /// </summary>
        private readonly UInt16 CartaBriscola;
        /// <summary>
        /// costruttore che inizializza l'intero indicante la carta di briscola
        /// </summary>
        /// <param name="briscola">intero di briscola</param>
        public CartaHelper(UInt16 briscola) { CartaBriscola = briscola; }
        /// <summary>
        /// retituisce il seme della carta indicata
        /// </summary>
        /// <param name="Carta">carta di cui prendere il seme</param>
        /// <returns>un numero intero, verosimilmemnte da 0 a 4</returns>
        public UInt16 GetSeme(UInt16 Carta) {
			return (UInt16)(Carta / 10);
		}
        /// <summary>
        /// rettuisce il valore della carta indicata
        /// </summary>
        /// <param name="Carta">carta di cui prendere il valore</param>
        /// <returns>un numero intero, verosimilmente da 0 a 9</returns>
        public UInt16 GetValore(UInt16 Carta) {
			return (UInt16)(Carta % 10);
		}
        /// <summary>
        /// resituisce il punteggio della carta indicata
        /// </summary>
        /// <param name="Carta">carta di cui prendere il punteggio</param>
        /// <returns>restituisce il punteggio sulla base del gioco che si sta facendo</returns>
        public UInt16 GetPunteggio(UInt16 Carta) {
			UInt16 valore = 0;
			switch (Carta % 10) {
				case 0: valore = 11; break;
				case 2: valore = 10; break;
				case 9: valore = 4; break;
				case 8: valore = 3; break;
				case 7: valore = 2; break;
			}
			return valore;
        }
        /// <summary>
        /// retituisce il seme in formato stringa della carta presa in esame (uno tra s0 e s7)
        /// </summary>
        /// <param name="carta">carta da prendere in esame</param>
        /// <param name="mazzo">stabilisce se è italiano o francese</param>
        /// <param name="d">dizionario indicante le stringhe dei sei italiani e francesi</param>
        /// <returns>uno tra s0 e s7 a seconda del seme della carta</returns>
        public string GetSemeStr(UInt16 carta, String mazzo, ResourceDictionary d)
        {
            string s = "a";
            if (mazzo == "Bergamasco" || mazzo == "Bolognese" || mazzo == "Bresciano" || mazzo == "Napoletano" || mazzo == "Romagnolo" || mazzo == "Sardo" || mazzo == "Siciliano" || mazzo == "Trientino" || mazzo == "Trevigiano" || mazzo == "Trentino" || mazzo == "Triestino")
                switch (carta / 10)
                {
                    case 0: s = d["bastoni"] as String; break;
                    case 1: s = d["coppe"] as String; break;
                    case 2: s = d["denari"] as String; break;
                    case 3: s = d["spade"] as String; break;
                }
            else
                switch (carta / 10)
                {
                    case 0: s = d["Fiori"] as String; break;
                    case 1: s = d["Quadri"] as String; break;
                    case 2: s = d["Cuori"] as String; break;
                    case 3: s = d["Picche"] as String; break;
                }
            return s;
        }

        /// <summary>
        /// Accoppia seme e valore per tornare l'intero indicante la carta
        /// </summary>
        /// <param name="seme">seme della carta</param>
        /// <param name="valore">valore della carta</param>
        /// <returns>intero indicante la carta</returns>
        public UInt16 GetNumero(UInt16 seme, UInt16 valore) {
			if (seme > 4 || valore > 9)
				throw new ArgumentException($"Chiamato CartaHelperBriscola::getNumero con seme={seme} e valore={valore}");
			return (UInt16)(seme * 10 + valore);
		}
        /// <summary>
        /// Retituisce la struttura indicante la carta di briscola
        /// </summary>
        /// <returns>la struttura indicante la carta di briscola</returns>
        public Carta GetCartaBriscola() { return Carta.GetCarta(CartaBriscola); }
        /// <summary>
        /// Compara le due carte per stabilire ch sia la maggiore
        /// </summary>
        /// <param name="Carta">prima carta presa in esame</param>
        /// <param name="Carta1">seconda carta presa in esame</param>
        /// <returns>-1 se maggiore la prima, zero se uguale, 1 se maggiore la seconda</returns>
        public int CompareTo(UInt16 Carta, UInt16 Carta1) {
			UInt16 punteggio = GetPunteggio(Carta),
				   punteggio1 = GetPunteggio(Carta1),
				   valore = GetValore(Carta),
				   valore1 = GetValore(Carta1),
				   semeBriscola = GetSeme(CartaBriscola),
				   semeCarta = GetSeme(Carta),
					  semeCarta1 = GetSeme(Carta1);
			if (punteggio < punteggio1)
				return 1;
			else if (punteggio > punteggio1)
				return -1;
			else {
				if (valore < valore1 || (semeCarta1 == semeBriscola && semeCarta != semeBriscola))
					return 1;
				else if (valore > valore1 || (semeCarta == semeBriscola && semeCarta1 != semeBriscola))
					return -1;
				else
					return 0;
			}
		}
	}
}