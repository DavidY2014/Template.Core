using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nba.Core.EntityFramework;
using Nba.Core.IData;
using Nba.Core.Models.Entites;

namespace Nba.Core.DataImplement
{
    public class PredictResultRepository : BaseRepository<NbaCoreDbContext, PredictResult>, IPredictResultRepository
    {
        public PredictResultRepository(NbaCoreDbContext dbContext) : base(dbContext)
        {

        }
        public List<PredictResult> GetList()
        {
            return Master.PredictResults.ToList();
        }

        public void Add(PredictResult item)
        {
            this.Insert(item);
        }

        public void Add(List<PredictResult> items)
        {
            base.AddCollections<PredictResult>(items);
        }

    }
}
