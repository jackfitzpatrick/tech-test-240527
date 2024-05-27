public class Checkout : ICheckout
{
  public int GetTotalPrice()
  {
    return TotalPrice;
  }

  public void Scan(Item item)
  {
    TotalPrice += item.UnitPrice;
  }

  private int TotalPrice;
}