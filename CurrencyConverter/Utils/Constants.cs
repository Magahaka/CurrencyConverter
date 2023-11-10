namespace CurrencyConverter.Utils
{
    public static class Constants
    {
        public static string ExchangeCommandUsageResponse()
        {
            return
                "Exchange\n" +
                "Usage: Exchange <currency pair> <amount to exchange>";
        }

        public static string IncorrectExchangeCommandResponse(string reason = null)
        {
            var response = "Invalid command format. Usage: Exchange <currency pair> <amount to exchange>";

            if (!string.IsNullOrEmpty(reason))
            {
                response += $"\nReason: {reason}";
            }

            return response.ToString();
        }
    }
}
