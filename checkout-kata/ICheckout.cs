interface ICheckout
{
  void Scan(string StockKeepingUnit);
  int GetTotalPrice();
}