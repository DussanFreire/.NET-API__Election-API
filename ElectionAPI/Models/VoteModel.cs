using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Models
{
    public class VoteModel
    {
        public long Id { get; set; }
        public bool PartyA { get; set; }
        public bool PartyB { get; set; }
        public bool PartyC { get; set; }
        public bool IsValid { get; set; }
        public string Name { get; set; }
        public DateTime DateRegistered { get; set; }
        public long TableId { get; set; }
    }
}
