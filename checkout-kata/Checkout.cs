public class Checkout(SupermarketItems supermarketItems) : ICheckout
{
  public int GetTotalPrice()
  {
    foreach (var item in Items)
    {
      Item matchingSupermarketItem = supermarketItems.Items[item.Key];
      TotalPrice += ProcessItems(matchingSupermarketItem, item.Value);
    }

    return TotalPrice;
  }

  public void Scan(string itemStockKeepingUnit)
  {
    if (supermarketItems.Items.ContainsKey(itemStockKeepingUnit))
    {
      if (Items.ContainsKey(itemStockKeepingUnit))
      {
        Items[itemStockKeepingUnit]++;
      }
      else
      {
        Items[itemStockKeepingUnit] = 1;
      }
    }
    else
    {
      // could also throw exception here/log error
      return;
    }
  }

  private int ProcessItems(Item item, int numberOfItems)
  {
    int price = 0;

    /*
      Special offer handling
      Note: currently this will only handle special offers that follow the buy x, pay y for those items type of offer.
      If another type of offer such as, buy x of y and get 50% off entire price, this would not work
    */
    if (item.SpecialOffer != null)
    {
      // Determine number of special offer pricing to be applied
      var numberOfItemSpecialPrices = (int)((double)numberOfItems / item.SpecialOffer.NumberOfUnits);
      // Calculate total special offer prices
      var itemSpecialPriceTotal = item.SpecialOffer.SpecialPrice * numberOfItemSpecialPrices;
      // Add them to the price
      price += itemSpecialPriceTotal;
      // Remove these items from those to be processed
      numberOfItems -= numberOfItemSpecialPrices * item.SpecialOffer.NumberOfUnits;
    }

    // Add the cost of any non special offer items to the price
    price = price += numberOfItems * item.UnitPrice;

    return price;
  }

  private readonly Dictionary<string, int> Items = [];
  private int TotalPrice;
  private readonly SupermarketItems supermarketItems = supermarketItems;
}
