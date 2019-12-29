using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        public BankAccount(decimal balance, string bankName, string sWIFTCode)
        {
            Balance = balance;
            BankName = bankName;
            SWIFTCode = sWIFTCode;
        }

        [Key]
        public int BankAccountId { get; set; }

        public decimal Balance { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string BankName { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string SWIFTCode { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }
        //        BankAccount:
        //o BankAccountId
        //o Balance
        //o BankName(up to 50 characters, unicode)
        //o SWIFT Code(up to 20 characters, non-unicode)
    }
}
