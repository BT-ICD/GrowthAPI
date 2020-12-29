using Growth.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Repository.Interfaces
{
    public interface IChapter
    {
        List<ChapterDTOList> GetList(int SubjectId);
        ChapterDTODetail GetById(int id);
        ChapterDTODetail Add(ChapterDTOAdd chapterDTOAdd);
        ChapterDTODetail Edit(ChapterDTOEdit chapterDTOEdit);
        DeleteResponse Delete(int id);
        
    }
}
