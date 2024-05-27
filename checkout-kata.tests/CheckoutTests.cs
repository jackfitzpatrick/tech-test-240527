namespace checkout_kata.tests;

public class CheckoutTests
{
  [Test]
  public void IsNotNull()
  {
    var actual = new Checkout();
    Assert.NotNull(actual);
  }

}