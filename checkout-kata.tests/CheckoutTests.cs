namespace checkout_kata.tests;
[TestFixture]
public class CheckoutTests
{

  private Dictionary<string, Item> supermarketItems;
  [SetUp]
  public void SetUp() {
    supermarketItems = new Dictionary<string, Item>() {
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
  };;
  }

  [Test]
  public void IsNotNull()
  {
    var actual = new Checkout(supermarketItems);
    Assert.NotNull(actual);
  }

  [Test]
  public void CanScanItem()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    var actual = checkout.GetTotalPrice();
    var totalPrice = supermarketItems["A"].UnitPrice;
    Assert.AreEqual(totalPrice, actual);
  }

  [Test]
  public void CanScanMultipleItems()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems["C"].StockKeepingUnit);
    checkout.Scan(supermarketItems["D"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    int totalPrice = supermarketItems["A"].UnitPrice + supermarketItems["B"].UnitPrice + supermarketItems["C"].UnitPrice + supermarketItems["D"].UnitPrice;
    Assert.AreEqual(totalPrice, actual);
  }

  [Test]
  public void CorrectlyAppliesItemASpecialPrice()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    var totalPrice = supermarketItems["A"].SpecialOffer?.SpecialPrice;
    Assert.AreEqual(totalPrice, actual);
  }

  [Test]
  public void HandlesItemARemainder()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    var totalPrice = supermarketItems["A"].SpecialOffer?.SpecialPrice + supermarketItems["A"].UnitPrice;
    Assert.AreEqual(totalPrice, actual);
  }

  [Test]
  public void HandlesMultipleItemASpecialPrices()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    var totalPrice = supermarketItems["A"].SpecialOffer?.SpecialPrice * 2;
    Assert.AreEqual(totalPrice, actual);
  }


  [Test]
  public void CorrectlyAppliesItemsBSpecialPrice()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    var totalPrice = supermarketItems["B"].SpecialOffer?.SpecialPrice;
    Assert.AreEqual(totalPrice, actual);
  }

  [Test]
  public void HandlesItemsBRemainder()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    var totalPrice = supermarketItems["B"].SpecialOffer?.SpecialPrice + supermarketItems["B"].UnitPrice;
    Assert.AreEqual(totalPrice, actual);
  }

  [Test]
  public void HandlesMultipleItemsBSpecialPrices()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    var totalPrice = supermarketItems["B"].SpecialOffer?.SpecialPrice * 2;

    Assert.AreEqual(totalPrice, actual);
  }

  [Test]
  public void HandlesMultipleItemSpecialPricesAndOtherItems()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems["C"].StockKeepingUnit);
    checkout.Scan(supermarketItems["D"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    var totalPrice = 
      supermarketItems["A"].SpecialOffer?.SpecialPrice +
      supermarketItems["A"].UnitPrice +
      supermarketItems["B"].SpecialOffer?.SpecialPrice +
      supermarketItems["B"].UnitPrice +
      supermarketItems["C"].UnitPrice +
      supermarketItems["D"].UnitPrice;

    Assert.AreEqual(totalPrice, actual);
  }

  [Test]
  public void HandlesItemsScannedInAnyOrder()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems["C"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["D"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems["B"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    var totalPrice = 
      supermarketItems["A"].SpecialOffer?.SpecialPrice +
      supermarketItems["A"].UnitPrice +
      supermarketItems["B"].SpecialOffer?.SpecialPrice +
      supermarketItems["B"].UnitPrice +
      supermarketItems["C"].UnitPrice +
      supermarketItems["D"].UnitPrice;

    Assert.AreEqual(totalPrice, actual);
  }

  [Test]
  public void ScanHandlesInvalidStockKeepingUnit()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan("InvalidStockKeepingUnit");

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(0, actual);
  }
}
