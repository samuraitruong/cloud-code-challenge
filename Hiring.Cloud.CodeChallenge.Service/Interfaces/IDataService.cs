using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hiring.Cloud.CodeChallenge.Model.Interfaces;

namespace Hiring.Cloud.CodeChallenge.Service.Interfaces
{
    public interface IDataService
    {
        List<IData> FetchData();
        Task<List<IData>> FetchDataAsync();
    }
}
