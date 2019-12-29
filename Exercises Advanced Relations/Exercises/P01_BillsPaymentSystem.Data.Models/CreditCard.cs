using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public CreditCard(decimal limit, decimal moneyOwed, DateTime expirationDate)
        {
            Limit = limit;
            MoneyOwed = moneyOwed;
            ExpirationDate = expirationDate;
        }

        [Key]
        public int CreditCardId { get; set; }

        public decimal Limit { get; set; }

        public decimal MoneyOwed { get; set; }

        

        public DateTime ExpirationDate { get; set; }
        //        CreditCard:
        //o CreditCardId
        //o Limit
        //o MoneyOwed
        //o LimitLeft(calculated property, not included in the database)
        //o ExpirationDate

        public virtual PaymentMethod PaymentMethod { get; set; }

        [NotMapped]
        public decimal LimitLeft => this.Limit - this.MoneyOwed;
    }
}
