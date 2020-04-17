using MvvmHelpers;
using System;

namespace BusinessTalkFinal.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string dateTime { get; set; }
    }
}