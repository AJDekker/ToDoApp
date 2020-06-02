﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Repository
{
    public interface ILoginRepository
    {
        Task<List<Person>> GetAllUser();

        //Read 
        Task<Person> GetUser(string email);

        //Inser a user
        Task<bool> AddUser(string email, string password);

        //Update 
        Task<bool> UpdateUser(string email, string password);

        //Delete User
        Task<bool> DeleteUser(string email);

    }
}
