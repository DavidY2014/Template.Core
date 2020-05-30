using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nba.Core.Models.Entites
{
    public class PredictResult
    {
        [Key]
        public int Id { get; set; }

        public string WinTeam { get; set; }

        public string LoseTeam { get; set; }

        public double Probility { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
