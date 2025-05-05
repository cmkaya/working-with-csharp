// Using the generic list to store integers
var numbers = new ListOfGenericType<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(5);

numbers.RemoveAt(2);
numbers.GetAtIndex(2);

// Using the generic list to store strings
var words = new ListOfGenericType<string>();
words.Add("aaa");
words.Add("bbb");
words.Add("ccc");

// Using the generic list to store DateTime objects
var dates = new ListOfGenericType<DateTime>();
dates.Add(DateTime.Now);
dates.Add(DateTime.Now.AddDays(1));
dates.Add(DateTime.Now.AddDays(2));
dates.GetAtIndex(1);

Console.ReadKey();

// This is a basic implementation of a generic collection that can store any type.
internal class ListOfGenericType<T>
{
  private T?[] _items = new T?[4];
  private int _size = 0;

  public void Add(T? value)
  {
    if (value is null)
    {
      throw new ArgumentNullException(nameof(value),
      "Value cannot be null.");
    }

    // Check if we need to resize the array
    if (_size >= _items.Length)
    {
      Array.Resize(ref _items, _items.Length * 2); ;
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
    _items[_size - 1] = default;
    _size--;
  }

  public T? GetAtIndex(int index)
  {
    if (index < 0 || index >= _size)
    {
      throw new IndexOutOfRangeException(
        $"Index {index} is outside the bounds of the list.");
    }

    return _items[index];
  }
}