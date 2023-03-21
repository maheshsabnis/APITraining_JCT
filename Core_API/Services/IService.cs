using Core_API.Models;

namespace Core_API.Services
{
    /// <summary>
    /// TEntity: WIll be an ENtity class, this will always be a class using the 'where' constraints
    /// THe 'in' will always be an 'input' paramter to method
    /// The 'TPk' will be a primary key
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPk"></typeparam>
    public interface IService<TEntity, in TPk> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id,  TEntity entity);
        Task DeleteAsync(TPk id);
    }
}
