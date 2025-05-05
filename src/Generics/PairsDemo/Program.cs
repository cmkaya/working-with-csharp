var pairsOfInt = new Pair<int>(1, 2);
Console.WriteLine($"First: {pairsOfInt.First}, Second: {pairsOfInt.Second}");
pairsOfInt.ResetFirst(); // will set First to default (0)
Console.WriteLine($"First: {pairsOfInt.First}, Second: {pairsOfInt.Second}");

internal class Pair<T>
{
  public T? First { get; private set; }
  public T? Second { get; private set; }

  public Pair(T? first, T? second)
  {
    First = first;
    Second = second;
  }

  public void ResetFirst() => First = default;

  public void ResetSecond() => Second = default;
}