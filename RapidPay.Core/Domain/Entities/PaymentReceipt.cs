namespace RapidPay.Core.Domain.Entities
{
    public record PaymentReceipt(string CardNumber, decimal Amount, decimal Fees, decimal BalanceBefore, decimal BalanceAfter);
}
