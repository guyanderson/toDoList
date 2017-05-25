using System.Collections.Generic;

namespace ToDoList.Objects
{
  public class Tasks
  {
    private string _description;
    private int _id;
    private static List<Tasks> _instances = new List<Tasks> {};

    public Tasks (string description)
    {
      _description = description;
      _instances.Add(this);
      _id = _instances.Count;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Tasks> GetAll()
    {
      return _instances;
    }
    // public void Save()
    // {
    //   _instances.Add(_description);
    // }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Tasks Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
