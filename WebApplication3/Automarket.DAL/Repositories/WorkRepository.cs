using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Itmytask.DAL.Interfaces;
using Itmytask.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Itmytask.DAL.Repositories
{
    public class WorkRepository : IWorkRepository

    {
        private readonly ApplicationDbContext _db;

        public WorkRepository(ApplicationDbContext db)  // инициализировали класс в конструкторе
        {
            _db = db;
        }

        public async Task<bool> Create(Work entity)  // при имплементации подставился Work - это благодаря дженерикам
                                        // связь с IBaswRepository и ICarRepository
        {
            await _db.Work.AddAsync(entity);
            
            await _db.SaveChangesAsync();//await _db.SaveChangesAsync();//dataManager.ServiceItems.SaveServiceItem(model);
            return true; 
        }

        public async Task<Work> GetAsync(int id)  // или public async Task<Work> GetAsync(int id)
        {
            return await _db.Work.FirstOrDefaultAsync(x => x.Id == id);
;        }

        public async Task<List<Work>> GetAsyncSelect()  // или public async Task<Work> GetAsync(int id)
        {
            string query = "SELECT 'Id', 'NameTask', 'TaskNumber', 'Description', 'Customer', 'AdressTask', 'Price', 'TypeWork'"; //SQL запрос в БД
            var works = await _db.Work.FromSqlRaw(query, "public.Work").ToListAsync(); 

            
            //var works = await _db.Work.FromSqlRaw("SELECT 'Work.Id', 'NameTask', 'TaskNumber', 'Description', 'Customer', 'AdressTask', 'Price', 'TypeWork' FROM public.\"Work\"").ToListAsync();
            
          
            //SELECT "Id", "NameTask", "TaskNumber", "Description", "Customer", "AdressTask", "Price",  "DateCreate", "TypeWork" FROM "Work"
            //было "SELECT Id, NameTask, TaskNumber, Description, Customer, AdressTask, Price,  DateCreate, TypeWork FROM Work"
            //"SELECT 'Id', 'NameTask', 'TaskNumber', 'Description', 'Customer', 'AdressTask', 'Price', 'TypeWork' FROM 'Work'


            return works; // _db.Work.FromSqlRaw("SELECT * FROM Companies").ToListAsync();
            
        }


        public async Task<List<Work>> Select()
        {

            List<Work> works = await _db.Work.ToListAsync(); 
            return works;  //удалил 140824 1-16сделали метод асинхронным, чтобы сайт не завис во время получения данных 
            //return await _db.Work.ToListAsync();
            //return _db.Work.ToListAsync() Делаем обращение к бд, и возвращаем из неё в метод select 
        }

        public async Task<bool> DeleteAsync(Work entity) // 140824 2-22 public bool Delete(Car entity)
        {
            _db.Work.Remove(entity);
            await _db.SaveChangesAsync(); 
            return true;//чтобы изменения в бд сохранились
        }

        public async Task<Work> GetByNameAsync(string name)  // public async Task<Work> GetByNameAsync(string name)
        {
            // return await _db.Work.FirstOrDefaultAsync(x => x.Name == name);
            return await _db.Work.FirstOrDefaultAsync(x => x.NameTask == name);
        }

        async Task<bool> IBaseRepository<Work>.Delete(Work entity)
        {
            _db.Work.Remove(entity);
            await _db.SaveChangesAsync(); // 140824 2-25
            return true;
            
        }

        public async Task<bool> UpdateAsync(Work entity)
        {
            _db.Work.Update(entity);
           
            await _db.SaveChangesAsync();//140824 2-25 await _db.SaveChangesAsync();//await _db.SaveChangesAsync();//dataManager.ServiceItems.SaveServiceItem(model);
            return true;
        }
    }
}
