using System;

namespace SuperUserWeb.Utils
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public void Debit(double amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
            //Balance += amount;
            Balance -= amount;
        }
    }
}
