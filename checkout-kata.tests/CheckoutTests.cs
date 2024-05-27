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

    checkout.Scan(SupermarketItems.itemA);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(50, actual);
  }

  [Test]
  public void CanScanItemB()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.itemB);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(30, actual);
  }

  [Test]
  public void CanScanItemC()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.itemC);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(20, actual);
  }

  [Test]
  public void CanScanItemD()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.itemD);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(15, actual);
  }

  [Test]
  public void CanScanMultipleItems()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemB);
    checkout.Scan(SupermarketItems.itemC);
    checkout.Scan(SupermarketItems.itemD);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(115, actual);
  }

  [Test]
  public void CorrectlyAppliesItemASpecialPrice()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(130, actual);
  }

  [Test]
  public void HandlesItemARemainder()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(180, actual);
  }

  [Test]
  public void HandlesMultipleItemASpecialPrices()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(260, actual);
  }


  [Test]
  public void CorrectlyAppliesItemBSpecialPrice()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.itemB);
    checkout.Scan(SupermarketItems.itemB);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(45, actual);
  }

  [Test]
  public void HandlesItemBRemainder()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.itemB);
    checkout.Scan(SupermarketItems.itemB);
    checkout.Scan(SupermarketItems.itemB);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(75, actual);
  }

  [Test]
  public void HandlesMultipleItemBSpecialPrices()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.itemB);
    checkout.Scan(SupermarketItems.itemB);
    checkout.Scan(SupermarketItems.itemB);
    checkout.Scan(SupermarketItems.itemB);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(90, actual);
  }

  [Test]
  public void HandlesMultipleItemSpecialPricesAndOtherItems()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemB);
    checkout.Scan(SupermarketItems.itemB);
    checkout.Scan(SupermarketItems.itemB);
    checkout.Scan(SupermarketItems.itemC);
    checkout.Scan(SupermarketItems.itemD);


    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(290, actual);
  }

  [Test]
  public void HandlesItemsScannedInAnyOrder()
  {
    var checkout = new Checkout();

    checkout.Scan(SupermarketItems.itemC);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemD);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemB);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemB);
    checkout.Scan(SupermarketItems.itemA);
    checkout.Scan(SupermarketItems.itemB);

    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(290, actual);
  }
}
