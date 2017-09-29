using System;
using System.Collections.Generic;
using Hiring.Cloud.CodeChallenge.Model.Interfaces;

namespace Hiring.Cloud.CodeChallenge.Service.Interfaces
{
    public interface ICacheService
    {
        void CacheServiceData(List<IData> data);
        List<IData> GetServiceData();
    }
}
