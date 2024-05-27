public class Checkout : ICheckout
{
  public int GetTotalPrice()
  {
    var itemAs = Items.FindAll(x => x.StockKeepingUnit == "A");
    Items.RemoveAll(x => x.StockKeepingUnit == "A");
    var numberOfSpecialPrices = (int)((double)itemAs.Count / 3);
    var specialPriceTotal = 130 * numberOfSpecialPrices;
    TotalPrice = TotalPrice += specialPriceTotal;
    itemAs.RemoveRange(0, numberOfSpecialPrices * 3);
    TotalPrice = TotalPrice += itemAs.Count * 50;

    foreach (var item in Items)
    {
      TotalPrice += item.UnitPrice;
    }

    return TotalPrice;
  }

  public void Scan(Item item)
  {
    Items.Add(item);
  }

  private List<Item> Items;

  private int TotalPrice;

  public Checkout()
  {
    Items = [];
  }
}