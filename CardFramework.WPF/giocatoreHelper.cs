/*
  *  This code is distribuited under GPL 3.0 or, at your opinion, any later version
 *  CBriscola 1.1.3
 *
 *  Created by Giulio Sorrentino (numerone) on 29/01/23.
 *  Copyright 2023 Some rights reserved.
 *
 */

namespace org.altervista.numerone.framework
{    /// <summary>
     /// Interfaccia per modificare il comportamento della classe giocatore
     /// </summary>
    public interface GiocatoreHelper
	{
        /// <summary>
        /// Gioca se è il primo di mano, se è l'utente deve restituire i, se è la cpu deve restituire l'indice in mano a v indicante il numero della carta da giocare
        /// </summary>
        /// <param name="i">carta da giocare se è l'utente</param>
        /// <param name="v">vettore delle carte da giocare se è il computer</param>
        /// <param name="numeroCarte">dimensione di v</param>
        /// <returns>indice di v indicante la carta giocata</returns>
        UInt16 Gioca(UInt16 i, Carta[] v, UInt16 numeroCarte);
        /// <summary>
        /// Gioca se è il secondo di mano, se è l'utente deve restituire i, se è la cpu deve restituire l'indice in mano a v indicante il numero della carta da giocare in base a c e stessoSeme
        /// </summary>
        /// <param name="i">carta da giocare se è l'utente</param>
        /// <param name="v">vettore delle carte da giocare se è il computer</param>
        /// <param name="numeroCarte">dimensione di v</param>
        /// <param name="c">carta giocata dal primo di mano</param>
        /// <returns>indice di v indicante la carta scelta</returns>
        UInt16 Gioca(UInt16 i, Carta[] v, UInt16 numeroCarte, Carta c);
        /// <summary>
        /// Gioca se è il secondo di mano, se è l'utente deve restituire i, se è la cpu deve restituire l'indice in mano a v indicante il numero della carta da giocare in base a c e stessoSeme
        /// </summary>
        /// <param name="i">carta da giocare se è l'utente</param>
        /// <param name="v">vettore delle carte da giocare se è il computer</param>
        /// <param name="numeroCarte">dimensione di v</param>
        /// <param name="piatto">carte per terra</param>
        /// <returns>indice di v indicante la carta scelta</returns>
        UInt16 Gioca(UInt16 i, Carta[] v, UInt16 numeroCarte, List<Carta> piatto);
        /// <summary>
        /// Deve aggiornare il punteggio del giocatore
        /// </summary>
        /// <param name="punteggio">il punteggio da aggiornare</param>
        /// <param name="c">la prima carta giocata</param>
        /// <param name="c1">la seconda carta g</param>
        void AggiornaPunteggio(ref UInt16 punteggio, Carta c, Carta c1);

    };
}