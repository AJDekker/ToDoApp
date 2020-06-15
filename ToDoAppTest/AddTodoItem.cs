using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TodoApp.ViewModels;
using ToDoApp.Models;
using ToDoApp.Repository;
using ToDoApp.Services;
using ToDoApp.ViewModels;


namespace ToDoAppTest
{
    [TestClass]
    public class AddTodoItem
    {
        MockDataStore _mockDataStore;
        TodoDetailViewModel _todoDetailViewModel;
        TodoListViewModel _todoListViewModel;
        TodoListSprintViewModel _todoListSprintViewModel;
        TodoViewModel _todoViewModel;

        [TestMethod]
        public async Task GetTodoItem()
        {
            // arrange
            _mockDataStore = new MockDataStore();
            Mock<ITodoRepository> todoRepositoryMock = new Mock<ITodoRepository>();
            var testresultaat = _mockDataStore.GetTodoAsync(new Guid("15f82b96-f997-4cd0-882e-b669faf81e98"));
            todoRepositoryMock.Setup(s => s.GetTodo(new Guid("15f82b96-f997-4cd0-882e-b669faf81e98"))).Returns(testresultaat);
  
            // act
            _todoDetailViewModel = new TodoDetailViewModel(await _mockDataStore.GetTodoAsync(new Guid("15f82b96-f997-4cd0-882e-b669faf81e98")));

            // assert
           Assert.AreEqual("First Todo", _todoDetailViewModel.Item.Name);
        }

        [TestMethod]
        public async Task GetAllSprintTodoItems()
        {
            // arrange
            _mockDataStore = new MockDataStore();
            Mock<ITodoRepository> todoRepositoryMock = new Mock<ITodoRepository>();
            var testMockResultaat = _mockDataStore.GetTodosAsync(); 
            todoRepositoryMock.Setup(s => s.GetAllTodo()).Returns(testMockResultaat);
            _todoListSprintViewModel = new TodoListSprintViewModel(todoRepositoryMock.Object);
            List<Todo> todoList = await todoRepositoryMock.Object.GetAllTodo(); 

            foreach (Todo todoItem in todoList)
            {
                _todoListSprintViewModel.Items.Add(todoItem);
            }

            // act
            Todo todo1 = _todoListSprintViewModel.Items[0];
            Todo todo2 = _todoListSprintViewModel.Items[1];
            Todo todo3 = _todoListSprintViewModel.Items[2];
            Todo todo4 = _todoListSprintViewModel.Items[3];
            Todo todo5 = _todoListSprintViewModel.Items[4];

            // assert
            Assert.AreEqual("First Todo", todo1.Name);
            Assert.AreEqual("Second Todo", todo2.Name);
            Assert.AreEqual("Third Todo", todo3.Name);
            Assert.AreEqual("Fourth Todo", todo4.Name);
            Assert.AreEqual("Fith Todo", todo5.Name);
        }

        [TestMethod]
        public async Task GetAllTodoItems()
        {


            // arrange
            _mockDataStore = new MockDataStore();
            Mock<ITodoRepository> todoRepositoryMock = new Mock<ITodoRepository>();
            var testMockResultaat = _mockDataStore.GetTodosAsync();
            todoRepositoryMock.Setup(s => s.GetAllTodo()).Returns(testMockResultaat);
            _todoListViewModel = new TodoListViewModel(todoRepositoryMock.Object);
            List<Todo> todoList = await todoRepositoryMock.Object.GetAllTodo();

            foreach (Todo todoItem in todoList)
            {
                _todoListViewModel.Items.Add(todoItem);
            }

            // act
            Todo todo1 = _todoListViewModel.Items[0];
            Todo todo2 = _todoListViewModel.Items[1];
            Todo todo3 = _todoListViewModel.Items[2];
            Todo todo4 = _todoListViewModel.Items[3];
            Todo todo5 = _todoListViewModel.Items[4];

            // assert
            Assert.AreEqual("First Todo", todo1.Name);
            Assert.AreEqual("Second Todo", todo2.Name);
            Assert.AreEqual("Third Todo", todo3.Name);
            Assert.AreEqual("Fourth Todo", todo4.Name);
            Assert.AreEqual("Fith Todo", todo5.Name);
        }

        [TestMethod]
        public async Task AddTodoItems()
        {
            // arrange
            _mockDataStore = new MockDataStore();
            Mock<ITodoRepository> todoRepositoryMock = new Mock<ITodoRepository>();
            var testresultaat = _mockDataStore.GetTodoAsync(new Guid("15f82b96-f997-4cd0-882e-b669faf81e98"));
            Todo todo = await _mockDataStore.GetTodoAsync(new Guid("15f82b96-f997-4cd0-882e-b669faf81e98"));
            todoRepositoryMock.Setup(s => s.AddTodo(todo.Id, todo.Name, todo.Description, todo.StoryPoints, todo.Due, todo.SprintId));
       
            // act
            _todoViewModel = new TodoViewModel(todoRepositoryMock.Object, Guid.NewGuid(), todo.Name, todo.Description, todo.StoryPoints, todo.Due, Guid.NewGuid());
             _todoViewModel.AddTodo();

            // assert
            Assert.AreEqual("First Todo", _todoViewModel.Name);


        }

        [TestMethod]
        public async Task UpdateTodoItems()
        {
            //arange
            _mockDataStore = new MockDataStore();
            Mock<ITodoRepository> todoRepositoryMock = new Mock<ITodoRepository>();
            Todo todo = await _mockDataStore.GetTodoAsync(new Guid("15f82b96-f997-4cd0-882e-b669faf81e98"));
            todoRepositoryMock.Setup(s => s.UpdateTodo(todo.Id, todo.Name, todo.Description, 12, todo.Due));

            //act
            _todoViewModel = new TodoViewModel(todoRepositoryMock.Object, Guid.NewGuid(), todo.Name, "ben", todo.StoryPoints, todo.Due, Guid.NewGuid());   
            _todoViewModel.UpdateTodo();

            //assert
            Assert.AreEqual("ben", _todoViewModel.Description);

        }

        [TestMethod]
        public async Task DeleteTodoItems()
        {
            //arrange
            _mockDataStore = new MockDataStore();
            Mock<ITodoRepository> todoRepositoryMock = new Mock<ITodoRepository>();
            Todo todo = await _mockDataStore.GetTodoAsync(new Guid("15f82b96-f997-4cd0-882e-b669faf81e98"));
            todoRepositoryMock.Setup(s => s.DeleteTodo(todo.Id));

            //act
            _todoViewModel = new TodoViewModel(todoRepositoryMock.Object);
            _todoViewModel.Delete();

            //assert
            Assert.IsNull(_todoViewModel.Name);

        }

    }
}
