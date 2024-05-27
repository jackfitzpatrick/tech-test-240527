interface ICheckout
{
  void Scan(Item item);
  int GetTotalPrice();
}