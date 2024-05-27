namespace checkout_kata.tests;

public class CheckoutTests
{
  [Test]
  public void IsNotNull()
  {
    var actual = new Checkout();
    Assert.NotNull(actual);
  }

  [Test]
  public void CanScanItem()
  {
    var checkout = new Checkout();
    var item = new Item
    {
      StockKeepingUnit = "A",
      UnitPrice = 50,
    };

    checkout.Scan(item);
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(50, actual);
  }
}