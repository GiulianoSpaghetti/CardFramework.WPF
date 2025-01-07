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
    /// Interfaccia per modificare il comportamento della classe mazzo
    /// </summary>
    public interface ElaboratoreCarte
    {
        /// <summary>
        /// restituisce la prossima carta del mazzo
        /// </summary>
        /// <returns>prende la prima carta non ancora uscita</returns>
        UInt16 GetCarta();
        /// <summary>
        /// Dice quante carte sono rimaste nel mazzo
        /// </summary>
        /// <returns>Retituisce il numero di carte nel mazzo</returns>
        UInt16 GetNumeroCarte();
    };
}