using Core.Entity;

namespace Core.Repository
{
    public interface IRepository <T> where T : EntityBase
    {
        IList<T> ObterTodos();
        T ObterPorGuid(Guid guid);
        void Cadastrar(T entidade);
        void Alterar(T entidade);
        void Deletar(Guid guid);
    }
}
