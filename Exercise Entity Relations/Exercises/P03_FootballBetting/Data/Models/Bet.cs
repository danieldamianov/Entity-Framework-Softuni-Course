﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
        //⦁	Bet – BetId, Amount, Prediction, DateTime, UserId, GameId
        [Key]
        public int BetId { get; set; }

        public decimal Amount { get; set; }

        public int Prediction { get; set; }

        public DateTime DateTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
