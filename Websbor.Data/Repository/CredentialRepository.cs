using Azure.Core;
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
    public class CredentialRepository : ICredentialsRepository
    {
        private readonly WebsborContext _context;
        public CredentialRepository(WebsborContext context)
        {
            _context = context;
        }

        #region обновление записей
        /// <summary>
        /// обновление записи
        /// </summary>
        public async Task UpdateCredentialAsync(Credentials credential)
        {
            _context.Update(credential);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// массовое обновление записей
        /// </summary>
        public async Task<int> UpdateCredentialAsync(Expression<Func<SetPropertyCalls<Credentials>, SetPropertyCalls<Credentials>>> expression)
            => await _context.Credentials.ExecuteUpdateAsync(expression);
        #endregion

        #region удаление записей  

        /// <summary>
        /// удаление всх записей
        /// </summary>
        public async Task<int> DeleteAllCredential() => await _context.Credentials.ExecuteDeleteAsync();
        public async Task DeleteCredentialAsync(int id)
        {
            var deletedCredential = await GetCredentialByIdAsync(id);
            if (deletedCredential is not null)
                await DeleteCredentialAsync(deletedCredential);
        }

        public async Task DeleteCredentialAsync(Credentials credential)
        {
            _context.Credentials.Remove(credential);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region поиск записей
        public async Task<List<Credentials>> GetCredentialByNameAndOkpoAsync(string name, string okpo)
        {
            return await _context.Credentials
                .Where(c => EF.Functions.Like(c.Name, $"%{name}%") && EF.Functions.Like(c.Okpo, $"%{okpo}%"))
                .Include(c => c.CatalogWebsborAsgs)
                .ToListAsync();
        }

        public async Task<List<Credentials>> GetCredentialByNameAsync(string name)
        {
            return await _context.Credentials
                .Where(c => EF.Functions.Like(c.Name, $"%{name}%"))
                .Include(c => c.CatalogWebsborAsgs)
                .ToListAsync();
        }

        public async Task<List<Credentials>> GetCredentialByOkpoAsync(string okpo)
        {
            return await _context.Credentials
                .Where(c => EF.Functions.Like(c.Okpo, $"%{okpo}%"))
                .Include(c => c.CatalogWebsborAsgs)
                .ToListAsync();
        }
        public async Task<Credentials?> GetCredentialByIdAsync(int id)
        {
            return await _context.Credentials
                .Where(c => c.Id.Equals(id))
                .Include(c => c.CatalogWebsborAsgs)
                .FirstOrDefaultAsync();
        }
        #endregion

        #region добавление записей
        public async Task SaveCredentialAsync(Credentials credential)
        {
            await _context.Credentials.AddAsync(credential);
            await _context.SaveChangesAsync();
        }

        public async Task SaveCredentialAsync(List<Credentials> credentials)
        {
            await _context.AddRangeAsync(credentials);
            await _context.SaveChangesAsync();
        }
        #endregion

        /// <summary>
        /// получение всех записей
        /// </summary>
        public async Task<List<Credentials>> GetAllCredentialsAsync() => await _context.Credentials.ToListAsync();

        /// <summary>
        /// получение количества записей в таблице
        /// </summary>
        public async Task<int> GetCountCredentialsAsync() => await _context.Credentials.CountAsync();

        /// <summary>
        /// получение записей с условиям делегата
        /// </summary>
        public async Task<List<Credentials>> GetCredentiaslByWhere(Expression<Func<Credentials, bool>> predicateWhere)
        {
            return await _context.Credentials
                .Where(predicateWhere)
                .ToListAsync();
        }

        /// <summary>
        /// получение id по ОКПО
        /// </summary>
        public async Task<int> GetIdByOkpoAsync(string okpo)
        {
            return await _context.Credentials
                .Where(c => c.Okpo == okpo)
                .Select(c => c.Id)
                .SingleOrDefaultAsync();
        }

        /// <summary>
        /// получение записей с помощью параметризованного запроса
        /// </summary>
        public Task<List<Credentials>> SelectFromCredential(string sqlSelectQuery, SqlParameter sqlParameter)
        {
            return _context.Credentials
                .FromSqlRaw(sqlSelectQuery, sqlParameter)
                .ToListAsync();
        }       
    }
}
