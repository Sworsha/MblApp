using System;

using VP_Details.Models;

namespace VP_Details.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public int Rank { get; set; }
        public string Text { get; set; }
        public string PartyAff { get; set; }
        public string Term { get; set; }
        public string BirthPlace { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        public string ServedUnder { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
            Rank = item.Rank;
            PartyAff = item.PartyAff;
            Term = item.Term;
            BirthPlace = item.BirthPlace;
            Born = item.BirthPlace;
            Died = item.Died;
            ServedUnder = item.ServedUnder;
        }
    }
}
