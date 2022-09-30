namespace BankWebAPI.DTOs
{
    public class AccountDTO
    {
        public string AccountNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public int AccountType { get; set; }
        public double Balance { get; set; }

        public int ClientId { get; set; }
    }
}
