using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Websbor.Data.Model;

namespace Websbor.Data.Repository
{
    public class CatalogRepository : ICatalogWebsborAsgsRepository
    {
        private readonly WebsborContext _context;
        public CatalogRepository(WebsborContext context)
        {
            _context = context;
        }

        #region удаление записей
        /// <summary>
        /// очистка каталога
        /// </summary>
        public async Task<int> DeleteAllCatalog() => await _context.Catalog.ExecuteDeleteAsync();

        /// <summary>
        /// удаление записи по id
        /// </summary>
        public async Task DeleteCatalogAsync(int id)
        {
            var deletedCatalog = await GetCatalogByIdAsync(id);
            if (deletedCatalog is not null)
                await DeleteCatalogAsync(deletedCatalog);
        }

        /// <summary>
        /// удаление записи
        /// </summary>
        public async Task DeleteCatalogAsync(CatalogWebsborAsgs catalog)
        {
            _context.Catalog.Remove(catalog);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region поиск записей
        /// <summary>
        /// получение записей с помощью делегата
        /// </summary>
        public async Task<List<CatalogWebsborAsgs>> GetCatalogByWhere(Expression<Func<CatalogWebsborAsgs, bool>> predicate)
        {
            return await _context.Catalog
                .Where(predicate)
                .ToListAsync();
        }

        /// <summary>
        /// получение записи по id
        /// </summary>
        public async Task<CatalogWebsborAsgs?> GetCatalogByIdAsync(int id)
        {
            return await _context.Catalog
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// получение записей по наименованию и ОКПО
        /// </summary>
        public async Task<List<CatalogWebsborAsgs>> GetCatalogByNameAndOkpoAsync(string name, string okpo)
        {
            return await _context.Catalog
                .Where(c => EF.Functions.Like(c.ShortName, $"%{name}%") && EF.Functions.Like(c.Okpo, $"%{okpo}%"))
                .ToListAsync();
        }

        /// <summary>
        /// получение записей по наименованию
        /// </summary>
        public async Task<List<CatalogWebsborAsgs>> GetCatalogByNameAsync(string name)
        {
            return await _context.Catalog
                 .Where(c => EF.Functions.Like(c.FullName, $"%{name}%"))
                 .ToListAsync();
        }

        /// <summary>
        /// получение записей по ОКПО
        /// </summary>
        public async Task<CatalogWebsborAsgs>? GetCatalogByOkpoAsync(string okpo)
        {
            return await _context.Catalog
                .Where(c => c.Okpo == okpo)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// получение записей по вхождению ОКПО 
        /// </summary>
        public async Task<List<CatalogWebsborAsgs>> GetCatalogByLikeOkpoAsync(string okpo)
        {
            return await _context.Catalog
               .Where(c => EF.Functions.Like(c.Okpo, $"%{okpo}%"))
               .ToListAsync();
        }

        /// <summary>
        /// получение id по ОКПО
        /// </summary>
        public async Task<int> GetIdByOkpoAsync(string okpo)
        {
            return await _context.Catalog
                .Where(c => c.Okpo.Equals(okpo))
                .Select(c => c.Id)
                .SingleOrDefaultAsync();
        }
        #endregion

        #region добавление записей
        /// <summary>
        /// добавление записи
        /// </summary>
        public async Task SaveCatalogAsync(CatalogWebsborAsgs catalog)
        {
            await _context.Catalog.AddAsync(catalog);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// добавление записей
        /// </summary>
        public async Task SaveCatalogAsync(List<CatalogWebsborAsgs> catalogs)
        {
            await _context.Catalog.AddRangeAsync(catalogs);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region обновление записей
        /// <summary>
        /// обновление записи
        /// </summary>
        public async Task UpdateCatalogAsync(CatalogWebsborAsgs catalog)
        {
            _context.Catalog.Update(catalog);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// массовое обновление записей
        /// </summary>
        public async Task<int> UpdateCatalogAsync(Expression<Func<SetPropertyCalls<CatalogWebsborAsgs>, SetPropertyCalls<CatalogWebsborAsgs>>> expression)
            => await _context.Catalog.ExecuteUpdateAsync(expression);
        #endregion

        /// <summary>
        /// получение всех записей
        /// </summary>
        public async Task<List<CatalogWebsborAsgs>> GetAllCatalogAsync() => await _context.Catalog.ToListAsync();

        /// <summary>
        /// получение количества записей 
        /// </summary>
        public async Task<int> GetCountCatalogAsync() => await _context.Catalog.CountAsync();

        /// <summary>
        /// получение записей с помощью параметризованного запроса
        /// </summary>
        public async Task<List<CatalogWebsborAsgs>> SelectFromCatalog(string sqlSelectQuery, SqlParameter sqlParameter)
        {
            return await _context.Catalog.FromSqlRaw(sqlSelectQuery, sqlParameter).ToListAsync();
        }       
    }
}
