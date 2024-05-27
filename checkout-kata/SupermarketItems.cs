//Would most likely be in DB
public static class SupermarketItems
{
  public static Dictionary<string, Item> Items = new Dictionary<string, Item>() {
    {"A", new Item
      {
        StockKeepingUnit = "A",
        UnitPrice = 50,
        SpecialOffer = new SpecialOffer
        {
          NumberOfUnits = 3,
          SpecialPrice = 130,
        }
      }},
    {"B", new Item
      {
          StockKeepingUnit = "B",
          UnitPrice = 30,
          SpecialOffer = new SpecialOffer
          {
            NumberOfUnits = 2,
            SpecialPrice = 45,
          }
        }},
    {"C", new Item
      {
          StockKeepingUnit = "C",
          UnitPrice = 20,
        }},
    {"D", new Item
      {
          StockKeepingUnit = "D",
          UnitPrice = 15,
        }},
  };
}