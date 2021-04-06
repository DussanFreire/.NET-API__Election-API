using ElectionAPI.Data.Repositories;
using ElectionAPI.Exceptions;
using ElectionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Services
{
    public class TableService : ITablesService
    {
        private IElectionRepository _electionRepository;


        private HashSet<string> _allowedOrderByValues = new HashSet<string>()
        {
            "id",
        };
        private HashSet<string> _allowedActions = new HashSet<string>()
        {
            "invalid table",
        };


        public TableService(IElectionRepository electionRepository)
        {
            _electionRepository = electionRepository;
        }
        public TableModel CreateTable(TableModel newTable)
        {
            var createdTable = _electionRepository.CreateTable(newTable);
            return createdTable;
        }

        public bool DeleteTable(long tableId)
        {
            var tableToDelete = GetTable(tableId);
            _electionRepository.DeleteTable(tableId);
            return true;
        }

        public TableWithVotesModel GetTable(long tableId)
        {
            var table = _electionRepository.GetTable(tableId);

            if (table == null)
            {
                throw new NotFoundItemException($"The table with id: {tableId} does not exists.");
            }

            return table;
        }

        public IEnumerable<TableModel> GetTables(string orderBy = "Id")
        {
            if (!_allowedOrderByValues.Contains(orderBy.ToLower()))
                throw new InvalidOperationItemException($"The Orderby value: {orderBy} is invalid, please use one of {String.Join(',', _allowedOrderByValues.ToArray())}");
            var modelList = _electionRepository.GetTables(orderBy.ToLower());
            return modelList;
        }

        public TableWithVotesModel UpdateInvalidTable(long tableId, ActionModel action)
        {
            if (!_allowedActions.Contains(action.Description.ToLower()))
                throw new InvalidOperationItemException($"The action: {action.Description} is invalid, please use one of {String.Join(',', _allowedActions.ToArray())}");
            ValidateTable(tableId);
            var updatedTableEntity = _electionRepository.UpdateInvalidTable(tableId);
            return updatedTableEntity;
        }

        public TableModel UpdateTable(long tableId, TableModel updatedTable)
        {
            ValidateTable(tableId);
            updatedTable.Id = tableId;
            var updatedTableEntity = _electionRepository.UpdateTable(tableId, updatedTable);
            return updatedTableEntity;
        }

        private void ValidateTable(long tableId)
        {
            GetTable(tableId);
        }
    }
}
