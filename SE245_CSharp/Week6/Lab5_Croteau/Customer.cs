using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Croteau
{
    class Customer : PersonV2
    {
        private DateTime customerSince;
        private double totalPurchases;
        private bool discountMember;
        private int rewardsEarned;

        //create constructor for Customer class which inherits from PersonV2
        public Customer() : base() //this inherits the constructor from parent (PersonV2 in this case)
        {
            customerSince = DateTime.Now;
            totalPurchases = 0.0;
            discountMember = false;
            rewardsEarned = 0;
        }

        public DateTime CustomerSince
        {
            get { return customerSince; }

            set
            {
                //cannot be a future date
                if (!Validator.IsFutureDate(value))
                {
                    customerSince = value; //store it
                }

                else
                {
                    Feedback += "\nERROR: You cannot enter a future date in the Customer Since field.";
                }
            }
        }

        public double TotalPurchases
        {
            get { return totalPurchases; }

            set
            {
                //cannot be negative
                if (Validator.IsMinValue(value, 0))
                {
                    totalPurchases = value;
                }

                else
                {
                    Feedback += "\nERROR: Total Purchases cannot be a negative number.";
                }
            }

        }

        public bool DiscountMember
        {
            get { return discountMember; }

            set { discountMember = value; }
        }

        public int RewardsEarned
        {
            get { return rewardsEarned; }

            set
            {
                //cannot be negative
                if (Validator.IsMinValue(value, 0))
                {
                    rewardsEarned = value;
                }

                else
                {
                    Feedback += "\nERROR: Rewards Earned cannot be a negative number.";
                }
            }

        }
    }
}
