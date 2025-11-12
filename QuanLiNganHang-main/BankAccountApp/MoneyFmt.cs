namespace BankAccountApp
{
    public static class MoneyFmt
    {
        public static string Format(double amount)
        {
            return amount.ToString("#,0.##")+" VND";
        }
    }
}
