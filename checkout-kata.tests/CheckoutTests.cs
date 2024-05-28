namespace checkout_kata.tests;
[TestFixture]
public class CheckoutTests
{

  [Test]
  public void IsNotNull()
  {
    var actual = new Checkout();
    Assert.NotNull(actual);
  }

  [Test]
  public void CanScanItemA()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(50, actual);
  }

  [Test]
  public void CanScanItemsB()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(30, actual);
  }

  [Test]
  public void CanScanItemC()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["C"].StockKeepingUnit);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(20, actual);
  }

  [Test]
  public void CanScanItemD()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["D"].StockKeepingUnit);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(15, actual);
  }

  [Test]
  public void CanScanMultipleItems()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["C"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["D"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(115, actual);
  }

  [Test]
  public void CorrectlyAppliesItemASpecialPrice()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(130, actual);
  }

  [Test]
  public void HandlesItemARemainder()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(180, actual);
  }

  [Test]
  public void HandlesMultipleItemASpecialPrices()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(260, actual);
  }


  [Test]
  public void CorrectlyAppliesItemsBSpecialPrice()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(45, actual);
  }

  [Test]
  public void HandlesItemsBRemainder()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(75, actual);
  }

  [Test]
  public void HandlesMultipleItemsBSpecialPrices()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(90, actual);
  }

  [Test]
  public void HandlesMultipleItemSpecialPricesAndOtherItems()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["C"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["D"].StockKeepingUnit);


    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(290, actual);
  }

  [Test]
  public void HandlesItemsScannedInAnyOrder()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.Items["C"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["D"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["A"].StockKeepingUnit);
    checkout.Scan(SupermarketItems.Items["B"].StockKeepingUnit);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(290, actual);
  }

  [Test]
  public void ScanHandlesInvalidStockKeepingUnit()
  {
    var checkout = new Checkout();

    checkout.Scan("InvalidStockKeepingUnit");

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(0, actual);
  }
}
