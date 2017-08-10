﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBrowser.Model.Entities;

namespace MediaBrowser.Controller.Chapters
{
    /// <summary>
    /// Interface IChapterManager
    /// </summary>
    public interface IChapterManager
    {
        /// <summary>
        /// Gets the chapters.
        /// </summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns>List{ChapterInfo}.</returns>
        IEnumerable<ChapterInfo> GetChapters(string itemId);

        /// <summary>
        /// Saves the chapters.
        /// </summary>
        Task SaveChapters(string itemId, List<ChapterInfo> chapters);
    }
}
