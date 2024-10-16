using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class AccountBase
    {
        // Static factory method to create the appropriate account type
        public static AccountBase CreateAccount(AccountType type)
        {
            AccountBase account = null;
            switch (type)
            {
                case AccountType.Silver:
                    account = new SilverAccount();
                    break;
                case AccountType.Gold:
                    account = new GoldAccount();
                    break;
                case AccountType.Platinum:
                    account = new PlatinumAccount();
                    break;
            }
            return account;
        }

        // Account balance
        public decimal Balance { get; private set; }

        // Reward points earned
        public int RewardPoints { get; private set; }

        // Handle transaction and update balance
        public void AddTransaction(decimal amount)
        {
            // Only award reward points for positive deposits
            if (amount > 0)
            {
                RewardPoints += CalculateRewardPoints(amount);
            }

            // Update balance, positive for deposit, negative for withdrawal
            Balance += amount;
        }

        // Abstract method for calculating reward points in derived classes
        public abstract int CalculateRewardPoints(decimal amount);
    }
}
