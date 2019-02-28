using System;

namespace VP_Details.Models
{
    public class Item
    {
        public string Id { get; set; }
        public int Rank { get; set; }
        public string Text { get; set; }
        public string PartyAff { get; set; }
        public string Term { get; set; }
        public string BirthPlace { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        public string ServedUnder { get; set; }
        public string Description { get; set; }
    }
}