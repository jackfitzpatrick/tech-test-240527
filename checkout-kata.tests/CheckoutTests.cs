namespace checkout_kata.tests;
[TestFixture]
public class CheckoutTests
{

  private SupermarketItems supermarketItems;
  [SetUp]
  public void SetUp() {
    supermarketItems = new SupermarketItems();
  }

  [Test]
  public void IsNotNull()
  {
    var actual = new Checkout(supermarketItems);
    Assert.NotNull(actual);
  }

  [Test]
  public void CanScanItemA()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(50, actual);
  }

  [Test]
  public void CanScanItemsB()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(30, actual);
  }

  [Test]
  public void CanScanItemC()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["C"].StockKeepingUnit);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(20, actual);
  }

  [Test]
  public void CanScanItemD()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["D"].StockKeepingUnit);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(15, actual);
  }

  [Test]
  public void CanScanMultipleItems()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["C"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["D"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(115, actual);
  }

  [Test]
  public void CorrectlyAppliesItemASpecialPrice()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(130, actual);
  }

  [Test]
  public void HandlesItemARemainder()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(180, actual);
  }

  [Test]
  public void HandlesMultipleItemASpecialPrices()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(260, actual);
  }


  [Test]
  public void CorrectlyAppliesItemsBSpecialPrice()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(45, actual);
  }

  [Test]
  public void HandlesItemsBRemainder()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(75, actual);
  }

  [Test]
  public void HandlesMultipleItemsBSpecialPrices()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(90, actual);
  }

  [Test]
  public void HandlesMultipleItemSpecialPricesAndOtherItems()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["C"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["D"].StockKeepingUnit);


    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(290, actual);
  }

  [Test]
  public void HandlesItemsScannedInAnyOrder()
  {
    var checkout = new Checkout(supermarketItems);

    checkout.Scan(supermarketItems.Items["C"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["D"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(supermarketItems.Items["B"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(290, actual);
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
