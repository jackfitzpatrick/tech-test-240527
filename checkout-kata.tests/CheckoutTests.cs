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
    checkout.Scan("A");
    var actual = checkout.GetTotalPrice();
    Assert.AreEqual(50, actual);
  }

}