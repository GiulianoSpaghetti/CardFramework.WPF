Framework di numerone in maui per la realizzazione di giochi di carte.
La codebase è in .net, con l'aggiunta di un resourcedictionary da passare.
Il resource dictionary deve includere 8 campi: bastoni, coppe, spade, denari, cuori, quadri, fiori e picche da tradurre dall'italiano nella lingua desiderata, i 4 semi dei mazzi di carte italiane, e francesi.
Il codice di apertura deve essere:

      e = new ElaboratoreCarteBriscola(briscolaDaPunti, 40, 0, 39);
      m = new Mazzo(e);
      m.SetNome(nomeMazzo)
      Carta.Inizializza(numerocarte, new CartaHelperBriscola(elaboratoreCarteBriscola.getCartaBriscola)));
      if (!Carta.CaricaImmagini(path, m, numerocarte, d))
            new ToastContentBuilder().AddArgument((string)d["MazzoIncompleto"] as string).AddText($"{d["CaricatoNapoletano"] as string}").AddAudio(new Uri("ms-winsoundevent:Notification.Reminder")).Show();            if (nomeMazzo == "Napoletano")
            cartaCpu.Source = new BitmapImage(new Uri("pack://application:,,,/resources/images/retro carte pc.png"));
        else
            try
            {
                cartaCpu.Source = new BitmapImage(new Uri($"{s}{nomeMazzo}\\retro carte pc.png"));

            }
            catch (Exception ex)
            {
                cartaCpu.Source = new BitmapImage(new Uri("pack://application:,,,/resources/images/retro carte pc.png"));

            }

        g = new Giocatore(new GiocatoreHelperUtente(), nomeUtente, dimensionemano);
        cpu = new Giocatore(new GiocatoreHelperCpu(ElaboratoreCarteBriscola.GetCartaBriscola()), nomeCpu, dimensionemano);

        briscola = Carta.GetCarta(ElaboratoreCarteBriscola.GetCartaBriscola());
        for (UInt16 i = 0; i < dimensionemano; i++)
        {
            g.AddCarta(m);
            cpu.AddCarta(m);
        }
        Utente0.Source = g.GetImmagine(0);
        Utente1.Source = g.GetImmagine(1);
        Utente2.Source = g.GetImmagine(2);
        ....
        Cpu0.Source = cartaCpu.Source;
        Cpu1.Source = cartaCpu.Source;
        Cpu2.Source = cartaCpu.Source;
        ....

una volta fatto questo, in carta si avrà un vettore di numerocarte elementi, in g e cpu si avrà un vettore di dimensionemano elementi corrispondenti alle prime 2*dimensionemano carte del mazzo, 
che saranno riempite con addcarta.
Quando addcarta restituisce un IndexOutOfRangeException exception si avrà la fine del mazzo.
Utente0-dimensionemano sono le Image XAML corrispondenti alle carte del giocatore, mentre Cpu0-dimensionemano sono le Image corrispondenti alle carte della cpu.

Se avete un gioco di carte sul piatto, il modo di agire dei giocatori professionisti è quello di crearsi mentalmente il grafo di presa. Mi spiego: per la scopa in mano ho un 8, è prendibile tramite 7+1 e 6+2, entrambi vanno bene. Vanno messi in un grafo e va così scomposto l'8, per poi prendere sulla base del piatto quello che consuma il maggior numero di carte del piatto stesso. Quindi se ho 8 e 10 e posso prendere più carte che con l'8 invece che col 10, va giocato l'8.
