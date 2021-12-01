using Microsoft.EntityFrameworkCore;
using Rally.Forum.Domain.Entity;
using Rally.Forum.Infra.Context;
using Rally.Forum.Infra.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally.Forum.Infra.Repository.Categories
{
    public class CategoriesRepository : IRepository<Category>
    {
        private readonly AppDbContext _Context;
        public CategoriesRepository(AppDbContext context)
        {
            _Context = context;
        }
        public async Task<bool> Delete(Category entity)
        {
            try
            {
                _Context.Categories.Remove(entity);
                var insertedLines = await _Context.SaveChangesAsync();
                return insertedLines > 0;
            }catch(Exception ex)
            {
                throw new Exception($"Ocorreu um problema. {ex.Message}");
            }
        }

        public async Task<Category> Get(string Id)
        {
            try
            {
                var entity = await _Context.Categories.FirstOrDefaultAsync(p => p.Id == Id);
                if (entity == null) throw new Exception("Categoria não existe");

                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception($"Ocorreu um erro. {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> GetTop10()
        {
            try
            {
                var entity = await _Context.Categories
                    .OrderByDescending(p => p.Created_At)
                    .Take(10)
                    .ToListAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception($"Ocorreu um erro {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> GetTop25()
        {
            try
            {
                var entity = await _Context.Categories
                    .OrderByDescending(p => p.Created_At)
                    .Take(25)
                    .ToListAsync();

                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception($"Ocorreu um erro {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> GetTop50()
        {
            try
            {
                var entity = await _Context.Categories
                    .OrderByDescending(p => p.Created_At)
                    .Take(50)
                    .ToListAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception($"Ocorreu um erro {ex.Message}");
            }
        }

        public async Task<bool> Insert(Category entity)
        {
            try
            {
                _Context.Categories.Add(entity);
                var lines = await _Context.SaveChangesAsync();
                return lines > 0;
            }
            catch(Exception ex)
            {
                throw new Exception($"Ocorreu um erro {ex.Message}");
            }
        }

        public async Task<bool> Update(Category entity)
        {
            try
            {
                _Context.Update(entity);
                var lines = await _Context.SaveChangesAsync();
                return lines > 0;
            }
            catch(Exception ex)
            {
                throw new Exception($"Ocorreu um erro {ex.Message}");
            }
        }
    }
}
