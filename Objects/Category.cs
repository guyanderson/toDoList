using System.Collections.Generic;
using ToDoList.Objects;

namespace ToDoList.Objects
{
  public class Category
  {
    private static List<Category> _instances = new List<Category> {};
    private string _name;
    private int _id;
    private List<Tasks> _tasks;

    public Category(string categoryName)
    {
      _name = categoryName;
      _instances.Add(this);
      _id = _instances.Count;
      _tasks = new List<Tasks>{};
    }

    public string GetName()
    {
      return _name;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Category> GetAll()
    {
      return _instances;
    }
      public List<Tasks> GetTasks()
    {
      return _tasks;
    }
    public void AddTasks(Tasks tasks)
    {
      _tasks.Add(tasks);
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
