using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Esercizio_Supermercato
{
    public partial class FAcquisti : Form
    {
        private List<CProdotto> prodottiDisponibili;  // Stock originale
        private List<CProdotto> carrello;             // Lista passata dal Form principale

        public FAcquisti(List<CProdotto> prodotti, List<CProdotto> carrelloEsistente)
        {
            InitializeComponent();
            prodottiDisponibili = prodotti;
            carrello = carrelloEsistente; // non ricreare la lista!
        }

        private void FAcquisti_Load(object sender, EventArgs e)
        {
            cmbbox_Prodotto.DataSource = prodottiDisponibili;
            cmbbox_Prodotto.DisplayMember = "Nome";
            numeric_Quantita.Minimum = 1;

            AggiornaCarrello(); // mostra subito eventuali prodotti già nel carrello
            AggiornaListaSpesa();
        }

        private void cmbbox_Prodotto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selezionato = (CProdotto)cmbbox_Prodotto.SelectedItem;
            if (selezionato != null)
            {
                lbl_Prezzo.Text = $"Prezzo unitario: {selezionato.Prezzo:C}";
                numeric_Quantita.Maximum = selezionato.Quantita > 0 ? selezionato.Quantita : 1;
                numeric_Quantita.Value = 1;
            }
        }

        private void btn_AggiungiProdotto_Click(object sender, EventArgs e)
        {
            var selezionato = (CProdotto)cmbbox_Prodotto.SelectedItem;
            int quantitaDaAggiungere = (int)numeric_Quantita.Value;

            if (selezionato == null) return;

            if (quantitaDaAggiungere <= 0 || selezionato.Quantita < quantitaDaAggiungere)
            {
                MessageBox.Show("Quantità non disponibile.");
                return;
            }

            // Cerca se il prodotto è già nel carrello
            var esistente = carrello.FirstOrDefault(p => p.Nome == selezionato.Nome);
            if (esistente != null)
            {
                // Aggiungi quantità
                esistente.Quantita += quantitaDaAggiungere;
            }
            else
            {
                // Nuovo prodotto per il carrello
                carrello.Add(new CProdotto
                {
                    Nome = selezionato.Nome,
                    Categoria = selezionato.Categoria,
                    Prezzo = selezionato.Prezzo,
                    Quantita = quantitaDaAggiungere
                });
            }

            // Aggiorna stock disponibile
            selezionato.Quantita -= quantitaDaAggiungere;
            numeric_Quantita.Maximum = selezionato.Quantita;

            AggiornaCarrello();
        }

        private void btn_RemoveProduct_Click(object sender, EventArgs e)
        {
            int indiceSelezionato = listbox_ListaSpesa.SelectedIndex;
            if (indiceSelezionato < 0) return;

            var selezionato = carrello[indiceSelezionato];

            // Ripristina quantità nello stock originale
            var originale = prodottiDisponibili.FirstOrDefault(p => p.Nome == selezionato.Nome);
            if (originale != null)
            {
                originale.Quantita += selezionato.Quantita;
            }

            carrello.RemoveAt(indiceSelezionato);

            AggiornaCarrello();
            AggiornaListaSpesa();
        }

        private void AggiornaCarrello()
        {
            // Aggiorna visualizzazione listbox
            listbox_ListaSpesa.DataSource = null;

            var visualizzazione = carrello
                .Select(p => $"{p.Nome} x{p.Quantita} - {p.Prezzo:C} ciascuno")
                .ToList();

            listbox_ListaSpesa.DataSource = visualizzazione;

            // Calcola totale
            decimal totale = carrello.Sum(p => p.Prezzo * p.Quantita);
            lbl_Tot.Text = "Totale: " + totale.ToString("C");
        }

        // Metodo pubblico per restituire il carrello al Form principale (opzionale)
        public List<CProdotto> GetCarrello()
        {
            return carrello;
        }

        private void AggiornaListaSpesa()
        {
            listbox_ListaSpesa.DataSource = null; // scollega DataSource

            if (carrello == null || carrello.Count == 0)
            {
                listbox_ListaSpesa.Items.Clear();
                listbox_ListaSpesa.Items.Add("Nessun elemento nel carrello");
                return;
            }

            // Crea una lista di stringhe da mostrare
            var visualizzazione = carrello
                .Select(p => $"{p.Nome} x{p.Quantita} - {p.Prezzo:C} ciascuno")
                .ToList();

            listbox_ListaSpesa.DataSource = visualizzazione;
        }

    }
}
