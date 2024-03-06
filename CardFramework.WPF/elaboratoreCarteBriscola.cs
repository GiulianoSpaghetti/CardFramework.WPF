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
    public class ElaboratoreCarteBriscola : ElaboratoreCarte
	{
		private UInt16 numeroCarte, min, max;
		private bool[] doppione;
		private static UInt16 CartaBriscola;
		private bool inizio,
				 briscolaDaPunti;
		public static Random r = new Random();
		public ElaboratoreCarteBriscola(bool punti = true, UInt16 a=40, UInt16 m=0, UInt16 n=39)
		{
			inizio = true;
			briscolaDaPunti = punti;
			numeroCarte = a;
			min = m;
			max = n;
			if (numeroCarte!=max-min+1)
				throw new ArgumentOutOfRangeException("Chiamata ad elaboratorecartebriscola con numeroCarte!=max-min+1");
            doppione = new bool[min+numeroCarte];
			for (int i = 0; i <min+numeroCarte; i++)
				doppione[i] = i<min;
		}
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

		public static UInt16 GetCartaBriscola() { return CartaBriscola; }

		public ushort GetNumeroCarte()
		{
			return numeroCarte;
		}
	}
}