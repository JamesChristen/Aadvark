using Common.Extensions;
using Common.Logging;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Providers
{
	public abstract class DbInteractor<T> where T : class, new()
	{
		protected ILogger logger;
		protected Func<DbContext> dbContext;

		public DbInteractor(ILogger logger)
			: this(logger, () => new ProjectAadvarkEntities()) { }

		public DbInteractor(ILogger logger, Func<DbContext> dbContext)
		{
			this.logger = logger;
			this.dbContext = dbContext;
		}

		public IEnumerable<T> Load(Expression<Func<T, bool>> filter)
		{
			using (var db = this.dbContext.Invoke())
			{
				return db.Set<T>().Where(filter).ToList();
			}
		}

		public T LoadSingle(Expression<Func<T, bool>> filter) => this.Load(filter).SingleOrDefault();

		public void Insert(IEnumerable<T> entities)
		{
			using (var db = this.dbContext.Invoke())
			{
				db.Set<T>().AddRange(entities);
				db.SaveChanges();
			}
		}

		public void Insert(T entity) => this.Insert(entity.AsSingleEnumerable());

		public void Delete(Expression<Func<T, bool>> filter)
		{
			using (var db = this.dbContext.Invoke())
			{
				var toDelete = db.Set<T>().Where(filter);
				db.Set<T>().RemoveRange(toDelete);
				db.SaveChanges();
			}
		}

		public void Update(T entity, Expression<Func<T, bool>> filter, Action<T, T> replaceFunc, 
			bool insertOnNoMatch = true, bool updateMultiple = false)
		{
			using (var db = this.dbContext.Invoke())
			{
				var matching = db.Set<T>().Where(filter);
				if (matching.Count() == 0 && insertOnNoMatch)
				{
					db.Set<T>().Add(entity);
				}
				else if (matching.Count() == 1)
				{
					replaceFunc(matching.Single(), entity);
				}
				else
				{
					if (!updateMultiple)
					{
						throw new InvalidOperationException($"Matched more than entity - if intended set flag to true");
					}

					foreach (T match in matching)
					{
						replaceFunc(match, entity);
					}
				}
				db.SaveChanges();
			}
		}
	}
}
