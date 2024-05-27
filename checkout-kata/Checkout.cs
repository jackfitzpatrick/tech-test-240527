public class Checkout : ICheckout
{
  public int GetTotalPrice()
  {
    //todo: make filtering easier?
    var itemAs = Items.FindAll(x => x.StockKeepingUnit == SupermarketItems.Items["A"].StockKeepingUnit);
    Items.RemoveAll(x => x.StockKeepingUnit == SupermarketItems.Items["A"].StockKeepingUnit);
    TotalPrice += ProcessItems(itemAs, SupermarketItems.Items["A"]);

    var itemBs = Items.FindAll(x => x.StockKeepingUnit == SupermarketItems.Items["B"].StockKeepingUnit);
    Items.RemoveAll(x => x.StockKeepingUnit == SupermarketItems.Items["B"].StockKeepingUnit);
    TotalPrice += ProcessItems(itemBs, SupermarketItems.Items["B"]);

    // todo: potentially inefficient if many items
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

  // todo: second param name could be better
  private int ProcessItems(List<Item> items, Item item)
  {
    int price = 0;
    var itemsToBeProcessed = items;
    var specialOffer = item.SpecialOffer;

    if (specialOffer != null)
    {
      var numberOfItemASpecialPrices = (int)((double)itemsToBeProcessed.Count / specialOffer.NumberOfUnits);
      var itemASpecialPriceTotal = specialOffer.SpecialPrice * numberOfItemASpecialPrices;
      price = price += itemASpecialPriceTotal;
      itemsToBeProcessed.RemoveRange(0, numberOfItemASpecialPrices * specialOffer.NumberOfUnits);
    }

    price = price += itemsToBeProcessed.Count * item.UnitPrice;

    return price;
  }

  private List<Item> Items;

  private int TotalPrice;

  public Checkout()
  {
    Items = [];
  }
}