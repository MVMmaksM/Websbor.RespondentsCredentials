using Azure.Core;
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
    public class CredentialRepository : ICredentialsRepository
    {
        private readonly WebsborContext _context;
        public CredentialRepository(WebsborContext context)
        {
            _context = context;
        }
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

        public async Task<List<Credentials>> GetAllCredentialsAsync()
        {
            return await _context.Credentials.ToListAsync();
        }

        public async Task<int> GetCountCredentialsAsync()
        {
            return await _context.Credentials.CountAsync();
        }

        public async Task<Credentials?> GetCredentialByIdAsync(int id)
        {
            return await _context.Credentials.Where(c => c.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<Credentials>> GetCredentialByNameAndOkpoAsync(string name, string okpo)
        {
            return await _context.Credentials
                .Where(c => EF.Functions.Like(c.Name, $"%{name}%") && EF.Functions.Like(c.Okpo, $"%{okpo}%"))
                .ToListAsync();
        }

        public async Task<List<Credentials>> GetCredentialByNameAsync(string name)
        {
            return await _context.Credentials
                .Where(c => EF.Functions.Like(c.Name, $"%{name}%"))
                .ToListAsync();
        }

        public async Task<List<Credentials>> GetCredentialByOkpoAsync(string okpo)
        {
            return await _context.Credentials
                .Where(c => EF.Functions.Like(c.Okpo, $"%{okpo}%"))
                .ToListAsync();
        }

        public async Task<List<Credentials>> GetCredentiaslByWhere(Expression<Func<Credentials, bool>> predeicateWhere)
        {
            return await _context.Credentials
                .Where(predeicateWhere)
                .ToListAsync();
        }

        public Task<int> GetIdByOkpoAsync(string okpo)
        {
            throw new NotImplementedException();
        }

        public Task SaveCredentialAsync(Credentials credential)
        {
            throw new NotImplementedException();
        }

        public Task SaveCredentialAsync(List<Credentials> credentials)
        {
            throw new NotImplementedException();
        }

        public Task<List<Credentials>> SelectFromCredential(string sqlSelectQuery, SqlParameter sqlParameter)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCredentialAsync(Credentials credential)
        {
            throw new NotImplementedException();
        }
    }
}
