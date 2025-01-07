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
    /// Interfaccia per modificare il comportamento della classe cpu
    /// </summary>
    public class GiocatoreHelperCpu : GiocatoreHelper
    {
        /// <summary>
        /// struttura indicante la carta di briscola
        /// </summary>
        private readonly Carta briscola;
        /// <summary>
        /// Retituisce la prima carta di briscola (la più piccola in mano al giocatore
        /// </summary>
        /// <param name="mano">mano del giocatore</param>
        /// <param name="numeroCarte">numero di carte</param>
        /// <returns>indice della carta giocata indicante la briscola più piccola</returns>

        private UInt16 GetBriscola(Carta[] mano, UInt16 numeroCarte)
        {
            UInt16 i;
            for (i = 0; i < numeroCarte; i++)
                if (briscola.StessoSeme(mano[i]))
                    break;
            return i;
        }
        /// <summary>
        /// Inizializza la struttura portandosi il seme di briscola
        /// </summary>
        /// <param name="b">intero indicante la carta di briscola</param>
        public GiocatoreHelperCpu(UInt16 b)
        {
            briscola = Carta.GetCarta(b);
        }
        /// <summary>
        /// Retituisce una carta di valore maggiore di quella giocata se c'è dipendentemente se deve essere la più alta o la subito superiore
        /// </summary>
        /// <param name="mano">mano da prendere in esame</param>
        /// <param name="numeroCarte">numero di carte in mano</param>
        /// <param name="c">carta giocata</param>
        /// <param name="maggiore">stabilisce se devee essere quella subito superiore o la più grande in assoluto</param>
        /// <returns>indice della carta se trovata, numeroCarte altrimenti</returns>
        private UInt16 getSoprataglio(Carta[] mano, Carta c, UInt16 numeroCarte, bool maggiore)
        {
            bool trovata = false;
            UInt16 i;
            if (maggiore)
            {
                for (i = (UInt16)(numeroCarte - 1); i > 0; i--)
                    if (c.StessoSeme(mano[i]) && c.CompareTo(mano[i]) > 0)
                    {
                        trovata = true;
                        break;
                    }
                    else if (c.StessoSeme(mano[i]) && mano[i].CompareTo(c) > 0)
                        break;
            }
            else
            {
                for (i = 0; i < numeroCarte; i++)
                    if (c.StessoSeme(mano[i]) && c.CompareTo(mano[i]) > 0)
                    {
                        trovata = true;
                        break;
                    }
            }
            if (trovata)
                return i;
            else
                return numeroCarte;
        }
        /// <summary>
        /// se è il primo di mano cerca la carta più difficile da prendere
        /// </summary>
        /// <param name="x">indice della carta da giocare, qui non considerato</param>
        /// <param name="mano">vettore delle carte da prendere in esame</param>
        /// <param name="numeroCarte">dimensione del vettore delle carte</param>
        /// <returns>l'indice dela carta da giocare</returns>
        public UInt16 Gioca(UInt16 x, Carta[] mano, UInt16 numeroCarte)
        {
            UInt16 i;
            for (i = (UInt16)(numeroCarte - 1); i > 0; i--) ;
            if ((mano[i].GetPunteggio() > 4 || briscola.StessoSeme(mano[i])))
                i = 0;
            return i;

        }
        /// <summary>
        /// Se è il secondo di mano sceglie quale carta giocare sulla base della carta giocata
        /// </summary>
        /// <param name="x">indice della carta da giocare, qui non considerato</param>
        /// <param name="mano">vettore delle carte da giocare</param>
        /// <param name="numeroCarte">dimensione del vettore dellke carte</param>
        /// <param name="c">carta giocata dall'altro giocatore</param>
        /// <returns>indice di mano indicante la carta da giocare</returns>
        public UInt16 Gioca(UInt16 x, Carta[] mano, UInt16 numeroCarte, Carta c)
        {
            UInt16 i = (UInt16)ElaboratoreCarteBriscola.r.Next(0, UInt16.MaxValue);
            if (!briscola.StessoSeme(c))
            {
                if ((i = getSoprataglio(mano, c, numeroCarte, true)) < numeroCarte)
                    return i;
                if (c.GetPunteggio() > 0 && (i = GetBriscola(mano, numeroCarte)) < numeroCarte)
                {
                    if (c.GetPunteggio() > 4)
                        return i;
                    if (mano[i].GetPunteggio() > 0)
                        if (ElaboratoreCarteBriscola.r.Next() % 10 < 5)
                            return i;
                }
            }
            else
            {
                if (ElaboratoreCarteBriscola.r.Next() % 10 < 5 && (i = getSoprataglio(mano, c, numeroCarte, false)) < numeroCarte)
                    return i;
            }
            i = 0;
            return i;
        }

        /// <summary>
        /// Deve aggiornare il punteggio del giocatore
        /// </summary>
        /// <param name="punteggioAttuale">il punteggio da aggiornare</param>
        /// <param name="c">la prima carta giocata</param>
        /// <param name="c1">la seconda carta giocata</param>
        public void AggiornaPunteggio(ref UInt16 punteggioAttuale, Carta c, Carta c1) { punteggioAttuale = (UInt16)(punteggioAttuale + c.GetPunteggio() + c1.GetPunteggio()); }

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
    }
}