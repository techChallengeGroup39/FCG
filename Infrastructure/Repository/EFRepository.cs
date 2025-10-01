using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EFRepository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Alterar(T entidade)
        {
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }

        public void Cadastrar(T entidade)
        {
            entidade.DataCriacao = DateTime.Now;
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public void Deletar(Guid guid)
        {
            _dbSet.Remove(ObterPorGuid(guid));
            _context.SaveChanges();
        }

        public T ObterPorGuid(Guid guid)
        {
            return _dbSet.FirstOrDefault(e => e.Guid == guid);
        }

        public IList<T> ObterTodos()
        {
            return _dbSet.ToList();
        }


    }
}