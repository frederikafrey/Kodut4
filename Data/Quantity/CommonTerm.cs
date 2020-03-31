using Abc.Data.Common;

namespace Abc.Data.Quantity
{
    public class CommonTerm : PeriodData
    {
        public string MasterId { get; set; } // id unitile või measurile
        public string TermId { get; set; } //hoiab meil id mingile teisele measurele
        public int Power { get; set; } //aste, mis näitab et kas mingi ühik või mõõt mis selle termiga näidatakse, mis astmes ta on
    }
}
