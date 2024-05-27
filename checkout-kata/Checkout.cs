public class Checkout : ICheckout
{
  public int GetTotalPrice()
  {
    //todo: make filtering easier?
    var itemAs = Items.FindAll(x => x.StockKeepingUnit == SupermarketItems.itemA.StockKeepingUnit);
    Items.RemoveAll(x => x.StockKeepingUnit == SupermarketItems.itemA.StockKeepingUnit);
    TotalPrice += ProcessItems(itemAs, SupermarketItems.itemA);

    var itemBs = Items.FindAll(x => x.StockKeepingUnit == SupermarketItems.itemB.StockKeepingUnit);
    Items.RemoveAll(x => x.StockKeepingUnit == SupermarketItems.itemB.StockKeepingUnit);
    TotalPrice += ProcessItems(itemBs, SupermarketItems.itemB);

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