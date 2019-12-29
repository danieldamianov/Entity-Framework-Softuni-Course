using P01_BillsPaymentSystem.Data.Models.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class PaymentMethod
    {
        public PaymentMethod(PaymentMethodType type)
        {
            Type = type;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public PaymentMethodType Type { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Xor("CreditCardId")]
        public int? BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        //        PaymentMethod:
        //o Id - PK
        //o Type – enum (BankAccount, CreditCard)
        //o UserId
        //o BankAccountId
        //o CreditCardId
    }
}
