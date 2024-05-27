public class Checkout : ICheckout
{
  public int GetTotalPrice()
  {
    //todo: refactor to remove hard coded special pricing rules and filters
    var itemAs = Items.FindAll(x => x.StockKeepingUnit == SupermarketItems.itemA.StockKeepingUnit);
    Items.RemoveAll(x => x.StockKeepingUnit == SupermarketItems.itemA.StockKeepingUnit);
    TotalPrice += ProcessItems(itemAs, 3, 130, 50);

    var itemBs = Items.FindAll(x => x.StockKeepingUnit == SupermarketItems.itemB.StockKeepingUnit);
    Items.RemoveAll(x => x.StockKeepingUnit == SupermarketItems.itemB.StockKeepingUnit);
    TotalPrice += ProcessItems(itemBs, 2, 45, 30);

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

  private int ProcessItems(List<Item> items, int numberOfItems, int specialPrice, int basePrice)
  {
    int price = 0;
    var numberOfItemASpecialPrices = (int)((double)items.Count / numberOfItems);
    var itemASpecialPriceTotal = specialPrice * numberOfItemASpecialPrices;
    price = price += itemASpecialPriceTotal;
    items.RemoveRange(0, numberOfItemASpecialPrices * numberOfItems);
    price = price += items.Count * basePrice;

    return price;
  }

  private List<Item> Items;

  private int TotalPrice;

  public Checkout()
  {
    Items = [];
  }
}