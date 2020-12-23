using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IChapter
    {
        List<ChapterDTOList> GetList(int SubjectId);
        ChapterDTOEdit GetById(int id);
        ChapterDTOEdit Add(ChapterDTOAdd chapterDTOAdd);
        ChapterDTOEdit Edit(ChapterDTOEdit chapterDTOEdit);
        DeleteResponse Delete(int id);
        
    }
}
