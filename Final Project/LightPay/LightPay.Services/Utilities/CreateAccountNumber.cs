using System;
using System.Text;

namespace LightPay.Services.Utilities
{
    public static class CreateAccountNumber
    {
        public static string CreateNumber()
        {
            StringBuilder number = new StringBuilder();

            while (true)
            {
                Random random = new Random();
                
                for (int i = 1; i < 11; i++)
                {
                    number.Append(random.Next(0, 9));
                }

                if (number[0] != 48)
                {
                    break;
                }
                number.Clear();
            }
            return number.ToString();
        }
    }
}
