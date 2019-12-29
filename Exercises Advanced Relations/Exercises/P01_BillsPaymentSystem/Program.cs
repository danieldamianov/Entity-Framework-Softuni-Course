using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace P01_BillsPaymentSystem
{
    class Program
    {
        static void UpdateName(User user, string newName)
        {

            using (var billsPaymentSystemContext = new BillsPaymentSystemContext())

            {

                var entry = billsPaymentSystemContext.Entry(user);

                entry.State = EntityState.Unchanged;

                user.LastName = newName;

                billsPaymentSystemContext.SaveChanges();

            }

        }
        static void Main(string[] args)
        {
            User user = null;
            using (BillsPaymentSystemContext billsPaymentSystemContext = new BillsPaymentSystemContext())
            {
                //PaymentMethod paymentMethod = new PaymentMethod(PaymentMethodType.BankAccount)
                //{
                //    UserId = 31,
                //    BankAccountId = 1,
                //    CreditCardId = null
                //};

                //billsPaymentSystemContext.PaymentMethods.Add(paymentMethod);
                //billsPaymentSystemContext.SaveChanges();
                //            User: Guy Gilbert
                //Bank Accounts:
                //--ID: 1
                //-- - Balance: 2000.00
                //-- - Bank: Unicredit Bulbank
                //---SWIFT: UNCRBGSF
                //-- ID: 2
                //-- - Balance: 1000.00
                //-- - Bank: First Investment Bank
                // -- - SWIFT: FINVBGSF
                //  Credit Cards:
                //                --ID: 1
                //               -- - Limit: 800.00
                //                -- - Money Owed: 100.00
                //                 -- - Limit Left:: 700.00
                //                  -- - Expiration Date: 2020 / 03
                int userId = 1;
                user = billsPaymentSystemContext.Users.Find(userId);
                var entry = billsPaymentSystemContext.Entry(user);
            }
            using (BillsPaymentSystemContext billsPaymentSystemContext = new BillsPaymentSystemContext())
            {
                UpdateName(user, "newName");
                user = billsPaymentSystemContext.Users.Find(1);
                Console.WriteLine(user.LastName);
                ; 
            }
                //BankAccount[] bankAccounts = user.PaymentMethods.Where(pm => pm.Type == PaymentMethodType.BankAccount).Select(pm => pm.BankAccount).ToArray();
                //CreditCard[] creditCards = user.PaymentMethods.Where(pm => pm.Type == PaymentMethodType.CreditCard).Select(pm => pm.CreditCard).ToArray();
                //StringBuilder stringBuilder = new StringBuilder();
                //stringBuilder.AppendLine($"User: {user.FirstName} {user.LastName}");
                //stringBuilder.AppendLine($"Bank Accounts:");
                //foreach (var bankAccount in bankAccounts)
                //{
                //    stringBuilder.AppendLine($"--ID: {bankAccount.BankAccountId}");
                //    stringBuilder.AppendLine($"---Balance: {bankAccount.Balance}");
                //    stringBuilder.AppendLine($"---Bank: {bankAccount.BankName}");
                //    stringBuilder.AppendLine($"---SWIFT: {bankAccount.SWIFTCode}");
                //}
                //stringBuilder.AppendLine($"Credit Cards:");
                //foreach (var creditCard in creditCards)
                //{
                //    stringBuilder.AppendLine($"--ID: {creditCard.CreditCardId}");
                //    stringBuilder.AppendLine($"---Limit: {creditCard.Limit}");
                //    stringBuilder.AppendLine($"---Money Owed: {creditCard.MoneyOwed}");
                //    stringBuilder.AppendLine($"---Limit Left: {creditCard.LimitLeft}");
                //    stringBuilder.AppendLine($"---Expiration Date: {creditCard.ExpirationDate}");
                //}
                //Console.WriteLine(stringBuilder.ToString());
                //var paymentMethods = billsPaymentSystemContext.PaymentMethods
                //    .Join(billsPaymentSystemContext.Users, (pm => pm.UserId)
                //    , (u => u.UserId), (pm, em) => new { pm.Id, em.FirstName });

                //var usersGrouped = billsPaymentSystemContext.Users.GroupBy(u => u.FirstName).ToArray()[0].ToArray();
                //string[] firstNames = { "Dani", "Yoana", "Krisi", "Venko", "Kiril", "Slavcho", "Ivi", "Svetlin", "Martina" };
                //string[] lastNames = { "Danielov", "Yoanov", "Kristianov", "Venkov", "Kirilov", "Slavchov", "Ivelinov", "Svetlinova", "Martinova" };
                //string[] passwords = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                //string[] emails = { "Danielov@abv.bg", "Yoanov@abv.bg", "Kristianov@abv.bg", "Venkov@abv.bg",
                //"Kirilov@abv.bg","Slavchov@abv.bg","Ivelinov@abv.bg","Svetlinova@abv.bg", "Martinova@abv.bg" };

                //Random random = new Random();
                //for (int I = 0; I < 200; I++)
                //{
                //    User user = new User(firstNames[random.Next(0, 9)], lastNames[random.Next(0, 9)], passwords[random.Next(0, 9)],
                //        emails[random.Next(0, 9)]);
                //    billsPaymentSystemContext.Users.Add(user);
                //    billsPaymentSystemContext.SaveChanges();

                //}

                //for (int i = 0; i < 200; i++)
                //{
                //    CreditCard creditCard = new CreditCard(random.Next(0, 100000), random.Next(0, 100000), DateTime.Now.AddDays(random.Next(1, 100)));
                //    billsPaymentSystemContext.CreditCards.Add(creditCard);
                //    billsPaymentSystemContext.SaveChanges();
                //}

                //for (int i = 0; i < 200; i++)
                //{
                //    string[] bankNames = { "Obb", "UnionBank", "Unicredit", "Bulbank", "NationalBAnk", "Bank2"};
                //    string[] swifts = { "123", "234", "345", "456", "3546", "345" };
                //    BankAccount bankAccount = new BankAccount(random.Next(0, 100000), bankNames[random.Next(0,6)], swifts[random.Next(0, 6)]);
                //    billsPaymentSystemContext.BankAccounts.Add(bankAccount);
                //    billsPaymentSystemContext.SaveChanges();
                //}

                //for (int i = 0; i < 1000; i++)
                //{

                //    PaymentMethod paymentMethod = null;
                //    if (i % 3 == 0)
                //    {
                //        paymentMethod = new PaymentMethod(PaymentMethodType.BankAccount)
                //        {
                //            UserId = random.Next(1, 201),
                //            BankAccountId = random.Next(1, 201),
                //            CreditCardId = random.Next(1, 201)
                //        }; 
                //    }
                //    if (i % 3 == 1)
                //    {
                //        paymentMethod = new PaymentMethod(PaymentMethodType.CreditCard)
                //        {
                //            UserId = random.Next(1, 201),
                //            BankAccountId = null,
                //            CreditCardId = random.Next(1, 201)
                //        };
                //    }

                //    if (i % 3 == 2)
                //    {
                //        paymentMethod = new PaymentMethod(PaymentMethodType.BankAccount)
                //        {
                //            UserId = random.Next(1, 201),
                //            BankAccountId = random.Next(1, 201),
                //            CreditCardId = null
                //        };
                //    }

                //    ValidationContext validationContext = new ValidationContext(paymentMethod);
                //    List<ValidationResult> validationResults = new List<ValidationResult>();
                //    if (Validator.TryValidateObject(paymentMethod,validationContext,validationResults,true))
                //    {
                //        billsPaymentSystemContext.PaymentMethods.Add(paymentMethod);
                //        billsPaymentSystemContext.SaveChanges();
                //    }
                //}
            
        }
    }
}
