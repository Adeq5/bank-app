using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank.models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public string SenderName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
    }
}
