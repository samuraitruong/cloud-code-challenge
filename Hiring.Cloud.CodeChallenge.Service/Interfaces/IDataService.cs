using System;
using System.Collections.Generic;
using Hiring.Cloud.CodeChallenge.Model.Interfaces;

namespace Hiring.Cloud.CodeChallenge.Service.Interfaces
{
    public interface IDataService
    {
        List<IData> FetchData();
    }
}
