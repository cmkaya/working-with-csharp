var numbers = new ListOfInts();
numbers.Add(11);
numbers.Add(22);
numbers.Add(33);
numbers.Add(44);
numbers.Add(55);

numbers.RemoveAt(2); // Remove the element at index 2 (33)
numbers.GetAtIndex(2); // Should return 44

/*
Leading compiler error which is "Cannot implicitly convert type 'int' to 'string'" is due to the fact that the ListOfInts class is designed"

var words = new ListOfInts();
words.Add("aaa");
words.Add("bb");
words.Add("ccc");
*/

Console.ReadKey();

internal class ListOfInts
{
  private int[] _items = new int[4];
  private int _size = 0;

  public void Add(int value)
  {
    // Check if we need to resize the array
    if (_size >= _items.Length)
    {
      Array.Resize(ref _items, _items.Length * 2);
    }

    _items[_size] = value;
    _size++;
  }

  public void RemoveAt(int index)
  {
    if (index < 0 || index >= _size)
    {
      throw new IndexOutOfRangeException(
        $"Index {index} is outside the bounds of the list.");
    }

    // Shift elements after the removed index one position to the left
    for (var i = index; i < _size - 1; i++)
    {
      _items[i] = _items[i + 1];
    }

    // Clear the last element (optional) and decrement size
    _items[_size - 1] = 0; // Clear the last element
    _size--;
  }

  public int GetAtIndex(int index)
  {
    if (index < 0 || index >= _size)
    {
      throw new IndexOutOfRangeException(
        $"Index {index} is outside the bounds of the list.");
    }

    return _items[index];
  }
}