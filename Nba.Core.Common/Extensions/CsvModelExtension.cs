using System;
using System.Collections.Generic;
using System.Text;
using Nba.Core.Models.Entites;

namespace Nba.Core.Common.Extensions
{
    public static class CsvModelExtension
    {
        public static PredictResult Convert(this CsvModel model)
        {
            var entity = new PredictResult();
            entity.WinTeam = model.win;
            entity.LoseTeam = model.lose;
            entity.Probility =Double.Parse(model.probability);
            return entity;
        
        }

        public static List<PredictResult> ConvertItems(this List<CsvModel> models)
        {
            var entites = new List<PredictResult>();
            foreach (var model in models)
            {
                var entity = model.Convert();
                entites.Add(entity);
            }
            return entites;
        }
    }
}
