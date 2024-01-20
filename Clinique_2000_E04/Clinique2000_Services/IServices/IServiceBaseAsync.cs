using System.Linq.Expressions;

namespace Clinique2000_Services.IServices
{
    public interface IServiceBaseAsync<T> where T : class
    {
        Task<T> CreerAsync(T entity);
        Task SupprimerAsync(int id);
        Task<List<T>> ObtenirToutAsync();
        Task<T?> ObtenirParIdAsync(int? id);
        Task<T?> ObtenirParNomAsync(string nom);
        Task<T?> EditerAsync(T entity);
    }
}
