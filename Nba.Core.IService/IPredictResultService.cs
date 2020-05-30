using System;
using System.Collections.Generic;
using System.Text;
using Nba.Core.Models.Entites;

namespace Nba.Core.IService
{
    public interface IPredictResultService: IAppService
    {
        List<PredictResult> GetList();

        void Add(PredictResult item);

        void Add(List<PredictResult> items);
    }
}
