using AstRentals.Web.ViewModels;
using System;

namespace AstRentals.Web.Helpers
{
    public class CheckoutViewModelHelper
    {
        public CheckoutViewModel CreateCheckoutViewModel(PreCheckoutModel model)
        {
            var vm = new CheckoutViewModel
            {
                CarId = model.CarId,
                Colour = model.Colour,
                StartDate = ConvertDateTimeString(model.StartDate),
                EndDate = ConvertDateTimeString(model.EndDate)
            };

            vm.NumberOfDays = Convert.ToInt32((vm.EndDate - vm.StartDate).TotalDays);

            switch (model.Features)
            {
                case "3door":
                    vm.Features = "3 Door";
                    break;
                case "5door":
                    vm.Features = "5 Door";
                    break;
                case "convertible":
                    vm.Features = "Convertible";
                    break;
            }

            switch (model.Cover)
            {
                case "basic":
                    vm.Cover = "Basic Cover (£0.00)";
                    vm.CoverCost = 0.00M;
                    break;
                case "cancellation":
                    vm.Cover = "Basic Cover + Cancellation Guarantee (+£20.00)";
                    vm.CoverCost = 20.00M;
                    break;
                case "extended":
                    vm.Cover = "Extended Insurance (+£50.00)";
                    vm.CoverCost = 50.00M;
                    break;
                case "premium":
                    vm.Cover = "Premium Cover (+£100.00)";
                    vm.CoverCost = 100.00M;
                    break;
            }

            vm.RentalCost = vm.NumberOfDays * 28.00M;
            vm.TotalPrice = vm.RentalCost + vm.CoverCost;

            return vm;
        }

        private DateTime ConvertDateTimeString(string input)
        {
            string[] dateStringArray = input.Split(' ');

            string dateString = $"{dateStringArray[0]} {dateStringArray[1]} {dateStringArray[2]}, {dateStringArray[3]}";

            return Convert.ToDateTime(dateString);
        }

    }
}