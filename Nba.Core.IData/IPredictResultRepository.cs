using System;
using System.Collections.Generic;
using System.Text;
using Nba.Core.Models.Entites;

namespace Nba.Core.IData
{
    public interface IPredictResultRepository: IBaseRepository<PredictResult>
    {
        List<PredictResult> GetList();
        void Add(PredictResult item);

        void Add(List<PredictResult> items);
    }
}
