//using MyNotes.Core.Configuration;
//using MyNotes.Core.IRepositories;
//using MyNotes.Core.Repositories;

//namespace MyNotes.Data
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        private readonly ApplicationDbContext context;

//        public INoteRepository Note { get; private set; }
//        public UnitOfWork(ApplicationDbContext context)
//        {
//            this.context = context;
//            Note = new NoteRepository(context);
//        }

//        public void Save()
//        {
//            context.SaveChanges();
//        }
//    }
//}
