using Clinique2000_DataAccess.Data;
using Clinique2000_Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clinique2000_Services.Services
{
    public class ServiceBaseAsync<T> : IServiceBaseAsync<T> where T : class
    {
        protected readonly CliniqueDbContext _dbContext;

        public ServiceBaseAsync(CliniqueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Ajoute une entité de type T de manière asynchrone dans la base de données.
        /// </summary>
        /// <param name="entity">Entité à ajouter</param>
        /// <returns>Entité ajoutée</returns>
        public async Task<T> CreerAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;

        }

        /// <summary>
        /// Modifie une entité de type T de manière asynchrone dans la base de données.
        /// </summary>
        /// <param name="entity">Entité à modifier</param>
        public async Task<T> EditerAsync(T entity)
        {

            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbContext.ChangeTracker.Clear();
                _dbContext.Update<T>(entity);
            }

            else
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }

            await _dbContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Obtient une entité de type T par son identifiant de manière asynchrone.
        /// </summary>
        /// <param name="id">Identifiant de l'entité</param>
        /// <returns>Entité correspondante ou null si non trouvée</returns>
        public async Task<T?> ObtenirParIdAsync(int? id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Obtient une entité de type T par son nom de manière asynchrone.
        /// </summary>
        /// <param name="nom">Nom de l'entité</param>
        /// <returns>Entité correspondante ou null si non trouvée</returns>
        public async Task<T?> ObtenirParNomAsync(string nom)
        {
            return await _dbContext.Set<T>().FindAsync(nom);
        }


        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }



        /// <summary>
        /// Obtient toutes les entités de type T de manière asynchrone.
        /// </summary>
        /// <returns>Liste des entités</returns>
        public async Task<List<T>> ObtenirToutAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Supprime une entité de type T par son identifiant de manière asynchrone.
        /// </summary>
        /// <param name="id">Identifiant de l'entité à supprimer</param>
        public virtual async Task SupprimerAsync(int id)
        {
            var entity = await this.ObtenirParIdAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }

        }
    }
}
