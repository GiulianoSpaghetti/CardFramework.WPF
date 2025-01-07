using System.Windows;

namespace org.altervista.numerone.framework.solitario
{
     /// <summary>
     /// Interfaccia per modificare il comportamento della classe carta in base al gioco del solitario la ottre di babele
     /// </summary>
    public class CartaHelper: org.altervista.numerone.framework.CartaHelper
    {        
        /// <summary>
        /// Compara le due carte per stabilire chi sia la maggiore
        /// </summary>
        /// <param name="carta">prima carta presa in esame</param>
        /// <param name="carta1">seconda carta presa in esame</param>
        /// <returns>-1 se maggiore la prima, zero se uguale, 1 se maggiore la seconda</returns>
        public int CompareTo(ushort carta, ushort carta1)
        {
            UInt16 valore = GetValore(carta),
                valore1 = GetValore(carta1),
                semeCarta = GetSeme(carta),
                semeCarta1 = GetSeme(carta1);
            if (valore < valore1)
                return 1;
            else if (valore > valore1)
                return -1;
            else
                return 0;
        }
        /// <summary>
        /// Accoppia seme e valore per tornare l'intero indicante la carta
        /// </summary>
        /// <param name="seme">seme della carta</param>
        /// <param name="valore">valore della carta</param>
        /// <returns>intero indicante la carta</returns>
        public ushort GetNumero(ushort seme, ushort valore)
        {
            if (seme > 4 || valore > 9)
                throw new ArgumentException($"Chiamato cartaHelperBriscola::getNumero con seme={seme} e valore={valore}");
            return (ushort)(seme * 10 + valore);
        }
        /// <summary>
        /// resituisce il punteggio della carta indicata
        /// </summary>
        /// <param name="Carta">carta di cui prendere il punteggio</param>
        /// <returns>restituisce il punteggio sulla base del gioco che si sta facendo</returns>
        public ushort GetPunteggio(ushort Carta)
        {
            return 0;
        }
        /// <summary>
        /// retituisce il seme della carta indicata
        /// </summary>
        /// <param name="Carta">carta di cui prendere il seme</param>
        /// <returns>un numero intero, verosimilmemnte da 0 a 4</returns>
        public ushort GetSeme(ushort Carta)
        {
            return (ushort)(Carta / 10);
        }
        /// <summary>
        /// retituisce il seme in formato stringa della carta presa in esame (uno tra s0 e s7)
        /// </summary>
        /// <param name="carta">carta da prendere in esame</param>
        /// <param name="mazzo">stabilisce se è italiano o francese</param>
        /// <param name="d">ResourceDictionary indicante i semi italiani e francesi</param>
        public string GetSemeStr(ushort carta, string mazzo, ResourceDictionary d)
        {
            return "";
        }
        /// <summary>
        /// rettuisce il valore della carta indicata
        /// </summary>
        /// <param name="Carta">carta di cui prendere il valore</param>
        /// <returns>un numero intero, verosimilmente da 0 a 9</returns>

        public ushort GetValore(ushort Carta)
        {
            return (ushort)(Carta % 10);
        }
    }
}