﻿using JurDocs.Core.Views;

namespace JurDocs.Core.Commands
{
    public interface ICreateProject
    {
        Task CreateNewProject(IMainView mainView);
    }
}