using System.Collections.Generic;
namespace TwoFormsOnePage.Models
{
    public class Drank
    {
        public List<Liquor> AllBooze { get; set; }
        public List<Mixer> NotBooze { get; set; }
        public Liquor LiquorForm { get; set; }
        public Mixer MixerForm { get; set; }
    }
}