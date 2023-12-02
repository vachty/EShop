using Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Base
{
	/// <summary>
	/// The Base Repository
	/// </summary>
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
		where TEntity : class, IBaseEntity
	{
		/// <summary>
		/// Creates the repository instance
		/// </summary>
		/// <param name="dbContext"></param>
		public BaseRepository(DbContext dbContext)
		{
			Context = dbContext;
			Entities = Context.Set<TEntity>();
		}

		/// <summary>
		/// The database context
		/// </summary>
		protected DbContext Context { get; set; }

		/// <summary>
		/// The Entities db set
		/// </summary>
		protected DbSet<TEntity> Entities { get; set; }

		/// <inheritdoc/>
		public void Delete(TEntity entity)
		{
			if (entity == null)
			{
				throw new NullReferenceException(nameof(entity));
			}

			Entities.Remove(entity);
		}

		/// <inheritdoc/>
		public virtual async Task<IList<TEntity>> GetAllAsync()
		{
			return await GetAllInternal().ToListAsync();
		}

		/// <inheritdoc/>
		public virtual async Task<TEntity> GetAsync(Guid id)
		{
			return await GetAllInternal().FirstOrDefaultAsync(x => x.Id.Equals(id));
		}

		/// <inheritdoc/>
		public virtual void Insert(TEntity entity)
		{
			if (entity == null)
			{
				throw new NullReferenceException(nameof(entity));
			}

			entity.Id = Guid.NewGuid();
			entity.CreatedBy = Constants.Constants.System;
			entity.CreatedOn = DateTime.Now;
			entity.UpdatedBy = Constants.Constants.System;
			entity.UpdatedOn = DateTime.Now;

			Entities.Add(entity);
		}

		/// <inheritdoc/>
		public virtual async Task<int> SaveAsync()
		{
			return await Context.SaveChangesAsync();
		}

		/// <inheritdoc/>
		public virtual void Update(TEntity entity)
		{
			if (entity == null)
			{
				throw new NullReferenceException(nameof(entity));
			}

			entity.UpdatedBy = Constants.Constants.System;
			entity.UpdatedOn = DateTime.Now;

			Entities.Update(entity);
		}

		private IQueryable<TEntity> GetAllInternal()
		{
			return Entities;
		}
	}
}
