using ElectionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Services
{
    public interface ITablesService
    {
        public IEnumerable<TableModel> GetTables(string orderBy = "Id");
        public TableWithVotesModel GetTable(long tableId);
        public TableModel CreateTable(TableModel newTable);
        public bool DeleteTable(long tableId);
        public TableModel UpdateTable(long tableId, TableModel updatedTable);
        public TableWithVotesModel UpdateInvalidTable(long tableId, ActionModel action);
    }
}
