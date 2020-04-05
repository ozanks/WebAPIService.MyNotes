using MyNotes.Core.EntityFramework;
using MyNotes.DataAccess.Abstract;
using MyNotes.Entities;

namespace MyNotes.DataAccess.EntityFramework
{
    public class NoteDal : RepositoryBase<Note, MyNotesDbContext>, INoteRepository
    {
        public NoteDal(MyNotesDbContext context) : base(context)
        {
        }
    }
}
