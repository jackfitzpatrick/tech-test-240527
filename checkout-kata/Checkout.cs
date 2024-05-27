public class Checkout : ICheckout
{
  public int GetTotalPrice()
  {
    var itemAs = Items.FindAll(x => x.StockKeepingUnit == "A");
    Items.RemoveAll(x => x.StockKeepingUnit == "A");
    var numberOfItemASpecialPrices = (int)((double)itemAs.Count / 3);
    var itemASpecialPriceTotal = 130 * numberOfItemASpecialPrices;
    TotalPrice = TotalPrice += itemASpecialPriceTotal;
    itemAs.RemoveRange(0, numberOfItemASpecialPrices * 3);
    TotalPrice = TotalPrice += itemAs.Count * 50;

    var itemBs = Items.FindAll(x => x.StockKeepingUnit == "B");
    Items.RemoveAll(x => x.StockKeepingUnit == "B");
    var numberOfItemBSpecialPrices = (int)((double)itemBs.Count / 2);
    var itemBSpecialPriceTotal = 45 * numberOfItemBSpecialPrices;
    TotalPrice = TotalPrice += itemBSpecialPriceTotal;
    itemBs.RemoveRange(0, numberOfItemBSpecialPrices * 2);
    TotalPrice = TotalPrice += itemBs.Count * 30;

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