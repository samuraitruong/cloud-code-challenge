using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hiring.Kloud.CodeChallenge.Model.Interfaces;

namespace Hiring.Kloud.CodeChallenge.Service.Interfaces
{
    public interface IDataService
    {
        List<IData> FetchData();
        Task<List<IData>> FetchDataAsync();
    }
}
