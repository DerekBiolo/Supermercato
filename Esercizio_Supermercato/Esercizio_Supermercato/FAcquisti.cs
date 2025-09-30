using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Esercizio_Supermercato
{
    public partial class FAcquisti : Form
    {
        private List<CProdotto> prodottiDisponibili;  // stock
        private List<CProdotto> carrello;             // carrello

        public FAcquisti(List<CProdotto> prodotti, List<CProdotto> carrelloEsistente)
        {
            InitializeComponent();
            prodottiDisponibili = prodotti; // prodotti disponibili in stock
            carrello = carrelloEsistente; // carrello = carrello del main form ( se esiste gia quello esistente altrimenti nuovo )
        }

        private void FAcquisti_Load(object sender, EventArgs e)
        {
            cmbbox_Prodotto.DataSource = prodottiDisponibili; // datasource prende tutti gli elementi della lista
            cmbbox_Prodotto.DisplayMember = "Nome"; // displaymember filtra per la proprieta ( nome )
            numeric_Quantita.Minimum = 1; // setto 1 come minimo del numericupdown

            AggiornaUICarrello(); // mostra subito eventuali prodotti già nel carrello
        }

        private void cmbbox_Prodotto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selezionato = (CProdotto)cmbbox_Prodotto.SelectedItem; // casto a CProdotto l'elemento selezionato
            if (selezionato != null)
            {
                lbl_Prezzo.Text = $"Prezzo unitario: {selezionato.Prezzo:C}"; // prendo il prezzo dalla prorpieta del CProdotto
                numeric_Quantita.Maximum = selezionato.Quantita > 0 ? selezionato.Quantita : 1; // uso un op tern per vedere se il prodotto una quantita, 
                                                                                                // se la ha imposto il valore massimo del numeric updown 
                                                                                                // altrimenti metto 0
                numeric_Quantita.Value = 1; // valore defauklt
            }
        }

        private void btn_AggiungiProdotto_Click(object sender, EventArgs e)
        {
            var selezionato = (CProdotto)cmbbox_Prodotto.SelectedItem; // prendo il CProdotto allo stesso modo
            int quantitaDaAggiungere = (int)numeric_Quantita.Value; // casto a int la quantia

            if (selezionato == null) return; // ritorno se no selezionato

            if (quantitaDaAggiungere <= 0 || selezionato.Quantita < quantitaDaAggiungere) //controllo che la quantita stia nel massimo e minimo ( max = stock min = 0)
            {
                MessageBox.Show("Quantità non disponibile.");
                return;
            }

            // se il prodotto e gia nel carrello
            var esistente = carrello.FirstOrDefault(p => p.Nome == selezionato.Nome);
            if (esistente != null)
            {
                esistente.Quantita += quantitaDaAggiungere; // modifico solo la quantita
            }
            else
            {
                // creo un nuovo prodotot
                carrello.Add(new CProdotto
                {
                    Nome = selezionato.Nome,
                    Categoria = selezionato.Categoria,
                    Prezzo = selezionato.Prezzo,
                    Quantita = quantitaDaAggiungere
                });
            }

            // aggiorno lo stock ( NON IL JSON PERCHE L'UTENTE DEVE ANCORA PAGARE MA LO STOCK "ATTUALE" IN MODO DA NON ANDARE OLTRE I LIMITI )
            selezionato.Quantita -= quantitaDaAggiungere;
            numeric_Quantita.Maximum = selezionato.Quantita;

            AggiornaUICarrello(); // aggiorno il carelo e la lista
        }

        private void btn_RemoveProduct_Click(object sender, EventArgs e)
        {
            int indiceSelezionato = listbox_ListaSpesa.SelectedIndex; //indice delezionato
            if (indiceSelezionato < 0) return;

            var selezionato = carrello[indiceSelezionato]; // prendo l'elemento in base all'indice

            // ripristino la quantiat dello stock originale (sempre dello stock "attuale")
            var originale = prodottiDisponibili.FirstOrDefault(p => p.Nome == selezionato.Nome);
            if (originale != null)
            {
                originale.Quantita += selezionato.Quantita;
            }

            carrello.RemoveAt(indiceSelezionato); // rimuove l'elemento all'indice selezionato

            AggiornaUICarrello(); // aggiorno il carelo e la lista
        }

        // Funzione unificata che aggiorna la ListBox e il totale
        private void AggiornaUICarrello()
        {
            listbox_ListaSpesa.DataSource = null; // scollega DataSource

            if (carrello == null || carrello.Count == 0)
            {
                listbox_ListaSpesa.Items.Clear();
                listbox_ListaSpesa.Items.Add("Nessun elemento nel carrello"); // mostra messaggio se vuoto
                lbl_Tot.Text = "Totale: €0,00"; // totale a 0
                return;
            }

            // Crea una lista di stringhe da mostrare
            var visualizzazione = carrello
                .Select(p => $"{p.Nome} x{p.Quantita} - {p.Prezzo:C} ciascuno") // per ogni elemento lo creo con questa formattazione
                .ToList(); // e lo trasformo in una lista di stringhe

            listbox_ListaSpesa.DataSource = visualizzazione; // uso la nuova datasource per popolare la lista

            // calcolo il totale
            decimal totale = carrello.Sum(p => p.Prezzo * p.Quantita); // sommo ogni prodotto moltiplicandolo per la sua quantita
            lbl_Tot.Text = "Totale: " + totale.ToString("C"); // aggiorno label totale
        }

        public List<CProdotto> GetCarrello()
        {
            return carrello; // restituisce il carrello
        }
    }
}
