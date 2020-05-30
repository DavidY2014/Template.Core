using System;
using System.Collections.Generic;
using System.Text;
using Nba.Core.IData;
using Nba.Core.IService;
using Nba.Core.Models.Entites;

namespace Nba.Core.ServiceImplement
{
    public class PredictResultService : IPredictResultService
    {
        private readonly IPredictResultRepository _predictResultRepository;
        public PredictResultService(IPredictResultRepository predictResultRepository)
        {
            _predictResultRepository = predictResultRepository;
        }
        public List<PredictResult> GetList()
        {
            return _predictResultRepository.GetList();
        }

        public void Add(PredictResult item)
        {
            _predictResultRepository.Add(item);
        }

        public void Add(List<PredictResult> items)
        {
            _predictResultRepository.Add(items);
        }
    }
}
