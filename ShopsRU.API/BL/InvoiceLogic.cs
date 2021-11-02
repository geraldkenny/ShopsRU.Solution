using ShopRU.Core.ModelDTO;
using ShopsRU.API.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRU.API.BL
{
    public class InvoiceLogic : IInvoiceLogic
    {
        /// <summary>
        /// Calculates the discount on items and return the invoice amount to be paid
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public decimal CalculateDiscount(InvoiceBillDTO bill)
        {
            if (bill is null)
            {
                throw new ArgumentNullException(nameof(bill));
            }

            int percent = 0;

            switch (bill.Customer.UserType)
            {
                case Entities.UserType.Affiliate:
                    percent = 10;
                    break;

                case Entities.UserType.Customer:
                    percent = 30;
                    break;

                default:
                    if (bill.Customer.CreatedAt > DateTime.Today.AddYears(-2))
                    {
                        percent = 5;
                    }

                    break;
            }

            var discountableItemsAmount = bill.Items.Where(c => c.GoodsType != Entities.GoodsType.Groceries).Sum(x => x.Amount);
            var discount = (discountableItemsAmount * percent) / 100;

            var totalBillAmount = bill.Items.Sum(x => x.Amount);

            var billAmountAfterDiscount = totalBillAmount - discount;
            var netPayableAmount = billAmountAfterDiscount - (5 * billAmountAfterDiscount / 100);

            bill.TotalAmount = totalBillAmount;
            bill.DiscountAmount = discount;
            bill.InvoiceNumber = GenerateInvoice();

            return netPayableAmount;
        }

        private static string GenerateInvoice()
        {
            string numbers = "1234567890";

            string characters = numbers;
            int length = 10;
            string id = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (id.IndexOf(character) != -1);
                id += character;
            }
            return "RU" + id;
        }
    }
}