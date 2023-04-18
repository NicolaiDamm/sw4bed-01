using Lists.Models;

namespace Lists.Services;

public class ListService<T> {

  public List<ListItem<T>> Items = new();

  public List<ListItem<T>> AddItemToList(ListItem<T> item) {
 
    Items.Add(item);

    return new List<ListItem<T>>(Items);
  }

  public List<ListItem<T>> GetItems() {
    // Implement
    return Items;
  }

  public ListItem<T>? GetItem(int index)
  {
      if (Items.ElementAtOrDefault(index) == null)
      {
          return null;
      }

      return Items[index];
  }

  public List<ListItem<T>> RemoveItem(int index) {
      Items.RemoveAt(index);
      return new List<ListItem<T>>(Items);
  }
}