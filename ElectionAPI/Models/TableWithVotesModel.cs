using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Models
{
    public class TableWithVotesModel: TableModel
    {
        public IEnumerable<VoteModel> Votes { get; set; }
    }
}
