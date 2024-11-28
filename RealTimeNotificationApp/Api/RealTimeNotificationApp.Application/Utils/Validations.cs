namespace RealTimeNotificationApp.Application.Utils
{
    public static class Validations
    {
        public static string GenerateOrderNumber(DateTime data, string telNumber)
        {
            string firstPart = telNumber.Substring(0, 2);
            string secondPart = data.ToString("yyyyMMddHHmmssffff");
            string thirdPart = telNumber.Substring(telNumber.Length - 4, 4);

            return String.Concat(firstPart, secondPart, thirdPart);
        }
    }
}
