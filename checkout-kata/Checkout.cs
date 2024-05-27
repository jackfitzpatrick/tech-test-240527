public class Checkout : ICheckout
{
  public int GetTotalPrice()
  {
    return TotalPrice;
  }

  public void Scan(string item)
  {
    TotalPrice = 50;
  }

  private int TotalPrice;
}