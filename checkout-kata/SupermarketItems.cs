//Would most likely be in DB
public static class SupermarketItems
{
  public static Item itemA = new Item
  {
    StockKeepingUnit = "A",
    UnitPrice = 50,
    SpecialOffer = new SpecialOffer
    {
      NumberOfUnits = 3,
      SpecialPrice = 130,
    }
  };
  public static Item itemB = new Item
  {
    StockKeepingUnit = "B",
    UnitPrice = 30,
    SpecialOffer = new SpecialOffer
    {
      NumberOfUnits = 2,
      SpecialPrice = 45,
    }
  };
  public static Item itemC = new Item
  {
    StockKeepingUnit = "C",
    UnitPrice = 20,
  };
  public static Item itemD = new Item
  {
    StockKeepingUnit = "D",
    UnitPrice = 15,
  };
}