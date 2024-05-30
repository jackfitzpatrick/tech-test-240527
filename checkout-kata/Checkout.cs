public class Checkout : ICheckout
{
  public int GetTotalPrice()
  {
    foreach (var uniqueItem in UniqueItems)
    {
      var allMatchingItems = Items.FindAll(x => x.StockKeepingUnit == uniqueItem.StockKeepingUnit);
      Items.RemoveAll(x => x.StockKeepingUnit == uniqueItem.StockKeepingUnit);
      TotalPrice += ProcessItems(allMatchingItems, uniqueItem.UnitPrice, uniqueItem.SpecialOffer);
    }

    return TotalPrice;
  }

  public void Scan(string itemStockKeepingUnit)
  {
    if (SupermarketItems.Items.ContainsKey(itemStockKeepingUnit))
    {
      Item? matchingSupermarketItem = SupermarketItems.Items[itemStockKeepingUnit];

      var newUniqueItems = UniqueItems.FindAll(x => x.StockKeepingUnit == itemStockKeepingUnit);
      if (newUniqueItems.Count == 0)
      {
        UniqueItems.Add(matchingSupermarketItem);
      }
      Items.Add(matchingSupermarketItem);
    }
    else
    {
      // could also throw exception here/log error
      return;
    }
  }

  private int ProcessItems(List<Item> items, int itemPrice, SpecialOffer? specialOffer)
  {
    int price = 0;
    var itemsToBeProcessed = items;

    /*
      Special offer handling
      Note: currently this will only handle special offers that follow the buy x, pay y for those items type of offer.
      If another type of offer such as, buy x of y and get 50% off entire price, this would not work
    */
    if (specialOffer != null)
    {
      // Determine number of special offer pricing to be applied
      var numberOfItemSpecialPrices = (int)((double)itemsToBeProcessed.Count / specialOffer.NumberOfUnits);
      // Calculate total special offer prices
      var itemSpecialPriceTotal = specialOffer.SpecialPrice * numberOfItemSpecialPrices;
      // Add them to the price
      price += itemSpecialPriceTotal;
      // Remove these items from those to be processed
      itemsToBeProcessed.RemoveRange(0, numberOfItemSpecialPrices * specialOffer.NumberOfUnits);
    }

    // Add the cost of any non special offer items to the price
    price = price += itemsToBeProcessed.Count * itemPrice;

    return price;
  }

  private readonly List<Item> Items;
  private readonly List<Item> UniqueItems;

  private int TotalPrice;

  public Checkout()
  {
    Items = [];
    UniqueItems = [];
  }
}