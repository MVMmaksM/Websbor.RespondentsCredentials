using Microsoft.EntityFrameworkCore;
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
        public async Task DeleteCatalogAsync(int id)
        {
            var deletedCatalog = await GetCatalogByIdAsync(id);
            if (deletedCatalog is not null)
                await DeleteCatalogAsync(deletedCatalog);
        }

        public async Task DeleteCatalogAsync(CatalogWebsborAsgs catalog)
        {
            _context.Catalog.Remove(catalog);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CatalogWebsborAsgs>> GetAllCatalogAsync()
        {
            return await _context.Catalog.ToListAsync();
        }

        public async Task<CatalogWebsborAsgs?> GetCatalogByIdAsync(int id)
        {
            return await _context.Catalog.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<CatalogWebsborAsgs>> GetCatalogByNameAndOkpoAsync(string name, string okpo)
        {
            return await _context.Catalog
                .Where(c => EF.Functions.Like(c.ShortName, $"%{name}%") && EF.Functions.Like(c.Okpo, $"%{okpo}%"))
                .ToListAsync();
        }

        public async Task<List<CatalogWebsborAsgs>> GetCatalogByNameAsync(string name)
        {
            return await _context.Catalog
                 .Where(c => EF.Functions.Like(c.FullName, $"%{name}%"))
                 .ToListAsync();
        }

        public async Task<List<CatalogWebsborAsgs>> GetCatalogByOkpoAsync(string okpo)
        {
            return await _context.Catalog
                .Where(c => EF.Functions.Like(c.Okpo, $"%{okpo}%"))
                .ToListAsync();
        }

        public async Task<List<CatalogWebsborAsgs>> GetCatalogByWhere(Expression<Func<CatalogWebsborAsgs, bool>> predicate)
        {
            return await _context.Catalog
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<int> GetCountCatalogAsync()
        {
            return await _context.Catalog.CountAsync();
        }

        public async Task<int> GetIdByOkpoAsync(string okpo)
        {
            return await _context.Catalog
                .Where(c => c.Okpo.Equals(okpo))
                .Select(c => c.Id)
                .SingleOrDefaultAsync();
        }

        public async Task SaveCatalogAsync(CatalogWebsborAsgs catalog)
        {
            await _context.Catalog.AddAsync(catalog);
            await _context.SaveChangesAsync();
        }

        public async Task SaveCatalogAsync(List<CatalogWebsborAsgs> catalogs)
        {
            await _context.Catalog.AddRangeAsync(catalogs);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CatalogWebsborAsgs>> SelectFromCatalog(string sqlSelectQuery, SqlParameter sqlParameter)
        {
            return await _context.Catalog.FromSqlRaw(sqlSelectQuery, sqlParameter).ToListAsync();
        }

        public async Task UpdateCatalogAsync(CatalogWebsborAsgs catalog)
        {
            _context.Catalog.Update(catalog);
            await _context.SaveChangesAsync();
        }
    }
}
