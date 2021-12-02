using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ucu.Poo.Defense
{
    public class Offer
    {
        public DateTime EndDate { get; set; }

        public IReadOnlyCollection<OfferItem> Items
        {
            get
            {
                return new ReadOnlyCollection<OfferItem>(this.items);
            }
        }

        private IList<OfferItem> items = new List<OfferItem>();

        public Offer(DateTime endDate)
        {
            this.EndDate = endDate;
        }

        public void AddItem(OfferItem item)
        {
            this.items.Add(item);
        }

        public void RemoveItem(OfferItem item)
        {
            this.items.Remove(item);
        }
        public string AsText()
        {
            string texto = $"Fecha:{EndDate}";
            foreach (OfferItem oferta in items)
            {
                texto = texto + $"{oferta.Quantity} de {oferta.Nombrederesiduo} a {oferta.Price}/n";
            }
            return texto;
        }
        public int Total
        {
            get
            {
            int total=0;
            foreach (OfferItem item in items)
            {
                total = total + item.SubTotal;
            }
            return total;
            }
        }

    }
}