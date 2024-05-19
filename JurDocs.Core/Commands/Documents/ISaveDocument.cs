﻿using JurDocs.Core.Model;
using JurDocs.Core.Views;

namespace JurDocs.Core.Commands.Documents
{
    /// <summary>
    /// Сохранить документ текущего типа
    /// </summary>
    public interface ISaveDocument
    {
        Task ExecuteAsync(IMainView mainView, EditedDocData data);
    }


}