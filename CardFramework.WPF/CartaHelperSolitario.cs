using System.Windows;

namespace org.altervista.numerone.framework
{
    public class CartaHelperSolitario: CartaHelper
    {
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

        public ushort GetNumero(ushort seme, ushort valore)
        {
            if (seme > 4 || valore > 9)
                throw new ArgumentException($"Chiamato cartaHelperBriscola::getNumero con seme={seme} e valore={valore}");
            return (ushort)(seme * 10 + valore);
        }

        public ushort GetPunteggio(ushort Carta)
        {
            return 0;
        }

        public ushort GetSeme(ushort Carta)
        {
            return (ushort)(Carta / 10);
        }

        public string GetSemeStr(ushort carta, string mazzo, ResourceDictionary d)
        {
            return "";
        }

        public ushort GetValore(ushort Carta)
        {
            return (ushort)(Carta % 10);
        }
    }
}