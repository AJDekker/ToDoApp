using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class MockDataStore : IDataStore<Todo>
    {
        readonly List<Todo> todos;
        readonly List<Sprint> sprints;

        public MockDataStore()
        {
            sprints = new List<Sprint>()
            {
                new Sprint { Id = new Guid("3e65620a-2aa4-4f55-8557-8090da9606cd"), PersonId = Guid.NewGuid(), Name = "First Todo", StoryPoints = 1},
                new Sprint { Id = new Guid("01f52ad4-75f0-4f01-80de-e602c93dabe5"), PersonId = Guid.NewGuid(), Name = "Second Todo", StoryPoints = 1},
                new Sprint { Id = new Guid("d36f27f0-959a-466f-84c0-3ce8921a5e5a"), PersonId = Guid.NewGuid(), Name = "Third Todo", StoryPoints = 1},
                new Sprint { Id = new Guid("d74c0b9c-89cf-4f7b-844b-4e8d9700bc11"), PersonId = Guid.NewGuid(), Name = "Fourth Todo", StoryPoints = 1},
                new Sprint { Id = new Guid("e3d90f75-ac01-456f-93b4-096bff98f63f"), PersonId = Guid.NewGuid(), Name = "Fifth Todo", StoryPoints = 1},
                new Sprint { Id = new Guid("58b06d67-2cc9-4d4e-9a46-5156728b5ac7"), PersonId = Guid.NewGuid(), Name = "Sixth Todo", StoryPoints = 1}
            };

            todos = new List<Todo>()
            {
                new Todo { Id = new Guid("15f82b96-f997-4cd0-882e-b669faf81e98"), PersonId = Guid.NewGuid(), Name = "First Todo", Description = "arjan", StoryPoints = 122, Due = new DateTime(), SprintId = sprints[0].Id, Sprint = sprints[0]},
                new Todo { Id = new Guid("12e577bd-9e8b-48cd-8542-37902f443f80"), PersonId = Guid.NewGuid(), Name = "Second Todo", Description = "arjan", StoryPoints = 112, Due = new DateTime(), SprintId = sprints[0].Id, Sprint = sprints[1]},
                new Todo { Id = new Guid("9c235079-6bc5-4dfe-834d-38892849a09d"), PersonId = Guid.NewGuid(), Name = "Third Todo", Description = "arjan", StoryPoints = 114, Due = new DateTime(), SprintId = sprints[0].Id, Sprint = sprints[2]},
                new Todo { Id = new Guid("3bc34477-006a-48cb-ad4a-37f353b34790"), PersonId = Guid.NewGuid(), Name = "Fourth Todo",  Description = "arjan",StoryPoints = 11, Due = new DateTime(), SprintId = sprints[0].Id, Sprint = sprints[3]},
                new Todo { Id = new Guid("0177700e-42ee-4fde-b016-c1e61b82e8bd"), PersonId = Guid.NewGuid(), Name = "Fith Todo",  Description = "arjan",StoryPoints = 12, Due = new DateTime(), SprintId = sprints[0].Id, Sprint = sprints[4]},
                new Todo { Id = new Guid("4f61a595-992d-4fae-b332-d78c51744ac0"), PersonId = Guid.NewGuid(), Name = "Sixth Todo", Description = "arjan", StoryPoints = 12, Due = new DateTime(), SprintId = sprints[0].Id, Sprint = sprints[5]},
            };
        }

        public async Task<bool> AddTodoAsync(Todo todo)
        {
            todos.Add(todo);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateTodoAsync(Todo todo)
        {
            var oldTodo = todos.Where((Todo arg) => arg.Id == todo.Id).FirstOrDefault();
            todos.Remove(oldTodo);
            todos.Add(todo);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteTodoAsync(Guid id)
        {
            var oldTodo = todos.Where((Todo arg) => arg.Id == id).FirstOrDefault();
            todos.Remove(oldTodo);

            return await Task.FromResult(true);
        }

        public async Task<Todo> GetTodoAsync(Guid id)
        {
            return await Task.FromResult(todos.FirstOrDefault(s => s.Id == id));
        }

        public async Task<List<Todo>> GetTodosAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(todos);
        }

        public async Task<Sprint> GetSprintAsync(Guid id)
        {
            return await Task.FromResult(sprints.FirstOrDefault(s => s.Id == id));
        }

        public async Task<List<Sprint>> GetSprintsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(sprints);
        }
    }
}