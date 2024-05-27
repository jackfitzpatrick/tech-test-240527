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
}