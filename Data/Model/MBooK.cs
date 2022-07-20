using System;

namespace BMS.Data
{
    public class MBook
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }
        public string Description { get; set; }

        public Int32 Rate { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateRead { get; set; }


    }
}
