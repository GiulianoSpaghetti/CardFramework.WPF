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
    /// Classe che identifica il mazzo di gioco
    /// </summary>
    public class Mazzo
    {
        /// <summary>
        /// vettore delle carte
        /// </summary>
        private UInt16[] carte;
        /// <summary>
        /// dimensione del vettore delle carte
        /// </summary>
        private UInt16 numeroCarte;
        /// <summary>
        /// personalizza il comportamento dell'elaborazione della carta
        /// </summary>
        private readonly ElaboratoreCarte elaboratore;
        /// <summary>
        /// nome del mazzo, serve per stabilire se le stringhe di gioco devono essere italiane o francesi
        /// </summary>
        private String nome;
        /// <summary>
        /// Elabora il numero di carte indicate dall'elaboratore sulla base del minimo e del massimo messi nell'elaboratore
        /// </summary>
        private void Mischia()
        {
            for (numeroCarte = 0; numeroCarte < elaboratore.GetNumeroCarte(); numeroCarte++)
                carte[numeroCarte] = elaboratore.GetCarta();
        }
        /// <summary>
        /// crea il mazzo
        /// </summary>
        /// <param name="e">elaboratore per personalizzare il mazzo</param>
        public Mazzo(ElaboratoreCarte e)
        {
            elaboratore = e;
            carte = new UInt16[elaboratore.GetNumeroCarte()];
            Mischia();
        }
        /// <summary>
        /// getter del numero di carte totali del mazzo
        /// </summary>
        /// <returns>numero di carte totali del mazzo</returns>
        public UInt16 GetNumeroCarte() { return numeroCarte; }
        /// <summary>
        /// restituisce la prima carta in cima al mazzo
        /// </summary>
        /// <returns>intero indicante la carta in cima al mazzo</returns>
        /// <exception cref="IndexOutOfRangeException">se non ci sono più carte</exception>
        public UInt16 GetCarta()
        {
            if (numeroCarte > 40)
                throw new IndexOutOfRangeException();
            UInt16 c = carte[--numeroCarte];
            return c;
        }
        /// <summary>
        /// getter del nome del mazzo
        /// </summary>
        /// <returns>il nome del mazzo</returns>
        public String GetNome() { return nome; }
        /// <summary>
        /// setter del nome del mazzo
        /// </summary>
        /// <param name="s">nome del mazzo</param>
        public void SetNome(String s) { nome = s; }
    };
}