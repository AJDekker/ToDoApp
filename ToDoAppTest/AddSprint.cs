using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Repository.Sprint;
using ToDoApp.Models;
using ToDoApp.Repository;
using ToDoApp.Services;
using ToDoApp.ViewModels;
using ToDoApp.ViewModels.Sprint;

namespace ToDoAppTest
{
    [TestClass]
    public class AddSprint
    {
        MockDataStore _mockDataStore;
        SprintDetailViewModel _sprintDetailViewModel; 
        SprintListViewModel _sprintListViewModel;
        SprintViewModel _sprintViewModel;

        [TestMethod]
        public async Task GetSprintItem()
        {
            // arrange
            _mockDataStore = new MockDataStore();
            Mock<ISprintRepository> sprintRepositoryMock = new Mock<ISprintRepository>();
            var testresultaat = _mockDataStore.GetSprintAsync(new Guid("3e65620a-2aa4-4f55-8557-8090da9606cd"));
            sprintRepositoryMock.Setup(s => s.GetSprint(new Guid("3e65620a-2aa4-4f55-8557-8090da9606cd"))).Returns(testresultaat);

            // act
            _sprintDetailViewModel = new SprintDetailViewModel(await _mockDataStore.GetSprintAsync(new Guid("3e65620a-2aa4-4f55-8557-8090da9606cd")));

            // assert
            Assert.AreEqual("First Sprint", _sprintDetailViewModel.Item.Name);
        }

        [TestMethod]
        public async Task GetAllListItems()
        {
            // arrange
            _mockDataStore = new MockDataStore();
            Mock<ISprintRepository> sprintRepositoryMock = new Mock<ISprintRepository>();
            var testMockResultaat = _mockDataStore.GetSprintsAsync();
            sprintRepositoryMock.Setup(s => s.GetAllSprint()).Returns(testMockResultaat);
            _sprintListViewModel = new SprintListViewModel();
            List<Sprint> sprintList = await sprintRepositoryMock.Object.GetAllSprint();

            foreach (Sprint sprintItem in sprintList)
            {
                _sprintListViewModel.Items.Add(sprintItem);
            }

            // act
            Sprint sprint1 = _sprintListViewModel.Items[0];
            Sprint sprint2 = _sprintListViewModel.Items[1];
            Sprint sprint3 = _sprintListViewModel.Items[2];
            Sprint sprint4 = _sprintListViewModel.Items[3];
            Sprint sprint5 = _sprintListViewModel.Items[4];

            // assert
            Assert.AreEqual("First Sprint", sprint1.Name);
            Assert.AreEqual("Second Sprint", sprint2.Name);
            Assert.AreEqual("Third Sprint", sprint3.Name);
            Assert.AreEqual("Fourth Sprint", sprint4.Name);
            Assert.AreEqual("Fifth Sprint", sprint5.Name);
        }

        [TestMethod]
        public async Task AddSprintItems()
        {
            // arrange
            _mockDataStore = new MockDataStore();
            Mock<ISprintRepository> sprintRepositoryMock = new Mock<ISprintRepository>();
            Sprint sprint = await _mockDataStore.GetSprintAsync(new Guid("3e65620a-2aa4-4f55-8557-8090da9606cd"));
            sprintRepositoryMock.Setup(s => s.AddSprint(sprint.Id, sprint.Name, sprint.StoryPoints));

            // act
            _sprintViewModel = new SprintViewModel(sprintRepositoryMock.Object, sprint.Name,  sprint.StoryPoints);
            _sprintViewModel.AddSprint();

            // assert
            Assert.AreEqual("First Todo", _sprintViewModel.Name);
        }

        [TestMethod]
        public async Task UpdateSprintItems()
        {
            //arange
            _mockDataStore = new MockDataStore();
            Mock<ISprintRepository> sprintRepositoryMock = new Mock<ISprintRepository>();
            Sprint sprint = await _mockDataStore.GetSprintAsync(new Guid("3e65620a-2aa4-4f55-8557-8090da9606cd"));
            sprintRepositoryMock.Setup(s => s.UpdateSprint(sprint.Id, sprint.Name, sprint.StoryPoints));

            //act
            _sprintViewModel = new SprintViewModel(sprintRepositoryMock.Object, "test", sprint.StoryPoints);
            _sprintViewModel.UpdateSprint();

            //assert
            Assert.AreEqual("test", _sprintViewModel.Name);

        }

        [TestMethod]
        public async Task DeleteSprintItems()
        {
            //arrange
            _mockDataStore = new MockDataStore();
            Mock<ISprintRepository> sprintRepositoryMock = new Mock<ISprintRepository>();
            Sprint sprint = await _mockDataStore.GetSprintAsync(new Guid("3e65620a-2aa4-4f55-8557-8090da9606cd"));
            sprintRepositoryMock.Setup(s => s.DeleteSprint(sprint.Id));

            //act
            _sprintViewModel = new SprintViewModel(sprintRepositoryMock.Object);
            _sprintViewModel.DeleteSprint();

            //assert
            Assert.IsNull(_sprintViewModel.Name);

        }
    }
}
