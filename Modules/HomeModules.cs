using Nancy;
using System.Collections.Generic;
using Todo.Objects;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
          return View["index.cshtml"];
      };
      Get["/categories"] = _ => {

        List<Category> allCategories = Category.GetAll();
        return View["categories.cshtml", allCategories];
      };
      Get["/categories/new"] = _ => {
        return View["category_form.cshtml"];
      };
      Post["/categories"] = _ => {
       Category newCategory = new Category(Request.Form["category-name"]);
        List<Category> allCategories = Category.GetAll();
        return View["categories.cshtml", allCategories];
      };
      Get["/categories/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(parameters.id);
        List<Tasks> categoryTasks = selectedCategory.GetTasks();
        model.Add("category", selectedCategory);
        model.Add("tasks", categoryTasks);
        return View["category.cshtml", model];
      };
      Get["/categories/{id}/tasks/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(parameters.id);
        List<Task> allTasks = selectedCategory.GetTasks();
        model.Add("category", selectedCategory);
        model.Add("tasks", allTasks);
        return View["category_tasks_form.cshtml", model];
      };
      Post["/tasks"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Category selectedCategory = Category.Find(Request.Form["category-id"]);
        List<Task> categoryTasks = selectedCategory.GetTasks();
        string taskDescription = Request.Form["task-description"];
        Task newTask = new Task(taskDescription);
        categoryTasks.Add(newTask);
        model.Add("tasks", categoryTasks);
        model.Add("category", selectedCategory);
        return View["category.cshtml", model];
      };
    }
  }
}


//
// using Nancy;
// using ToDoList.Objects;
// using System.Collections.Generic;
//
// namespace ToDoList
// {
//   public class HomeModule : NancyModule
//   {
//     public HomeModule()
//     {
//       Get["/"] = _ => {
//         return View["index.cshtml"];
//       };
//       Get["/tasks/new"] = _ => {
//         return View["task_form.cshtml"];
//       };
//       Post["/tasks"] = _ => {
//         Task newTask = new Task(Request.Form["new-task"]);
//         List<Task> allTasks = Task.GetAll();
//         return View["tasks.cshtml", allTasks];
//       };
//       Get["/tasks"] = _ => {
//         List<Task> allTasks = Task.GetAll();
//         return View["tasks.cshtml", allTasks];
//       };
//       Get["/tasks/{id}"] = parameters => {
//         Task task = Task.Find(parameters.id);
//         return View["/task.cshtml", task];
//       };
      // Post["/task_added"] = _ => {
      //   Task newTask = new Task (Request.Form["new-task"]);
      //   newTask.Save();
      //   return View["task_added.cshtml", newTask];
      // };
      // Get["/view_all_tasks"] = _ => {
      //   List<string> allTasks = Task.GetAll();
      //   return View["view_all_tasks.cshtml", allTasks];
      // };
      // Post["/tasks_cleared"] = _ => {
      //   Task.ClearAll();
      //   return View["tasks_cleared.cshtml"];
      // };
    }
  }
}
