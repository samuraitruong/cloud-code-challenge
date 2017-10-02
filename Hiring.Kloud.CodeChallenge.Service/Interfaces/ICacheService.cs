using System;
using System.Collections.Generic;
using Hiring.Kloud.CodeChallenge.Model.Interfaces;

namespace Hiring.Kloud.CodeChallenge.Service.Interfaces
{
    public interface ICacheService
    {
        void CacheServiceData(List<IData> data);
        List<IData> GetServiceData();
    }
}
