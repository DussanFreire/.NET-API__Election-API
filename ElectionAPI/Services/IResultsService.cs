using ElectionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionAPI.Services
{
    public interface IResultsService
    {
        public ResultsModel GetResults();
    }
}
