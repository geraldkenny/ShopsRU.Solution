using ShopRU.Core.ModelDTO;
using ShopsRU.API.BL.Interfaces;
using ShopsRU.API.Repositories.Interfaces;
using ShopsRU.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopsRU.API.BL
{
    public class InvoiceLogic : IInvoiceLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Calculates the discount on items and return the invoice amount to be paid
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public async Task<decimal> CalculateInvoiceDiscountAsync(InvoiceBillDTO bill)
        {
            if (bill is null || bill.Customers is null)
            {
                throw new ArgumentNullException(nameof(bill));
            }

            Discounts discountType = await _unitOfWork.DiscountRepository.GetByTypeAsync(bill.Customers.UserType);

            try
            {
                int percent = 0;

                switch (discountType?.UserType)
                {
                    case UserType.Affiliate:

                        percent = discountType.Percent;
                        break;

                    case UserType.Employee:
                        percent = discountType.Percent;
                        break;

                    default:
                        if (bill.Customers.CreatedAt > DateTime.Today.AddYears(-2))
                        {
                            percent = 5;
                        }

                        break;
                }

                var discountableItemsAmount = bill.Items.Where(c => c.GoodsType != Entities.GoodsType.Groceries).Sum(x => x.Amount);
                var discount = (discountableItemsAmount * percent) / 100;

                var totalBillAmount = bill.Items.Sum(x => x.Amount);

                var billAmountAfterDiscount = totalBillAmount - discount;
                var netPayableAmount = Math.Round(billAmountAfterDiscount - (5 * billAmountAfterDiscount / 100));

                bill.TotalAmount = totalBillAmount;
                bill.DiscountAmount = totalBillAmount - netPayableAmount;
                bill.InvoiceNumber = GenerateInvoice();

                return netPayableAmount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Generates randomized invoice number
        /// </summary>
        /// <returns></returns>
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