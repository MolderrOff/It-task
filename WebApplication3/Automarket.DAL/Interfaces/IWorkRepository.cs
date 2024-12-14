using Itmytask.Domain.Entity;
using System.Threading.Tasks;

namespace Itmytask.DAL.Interfaces
{
    public interface IWorkRepository : IBaseRepository<Work>  //передаём объект Car как тип дженерика <>
         //добавляем специфические методы
         {
        Task<Work> GetByNameAsync(string name);  //унаследовались от базового репозитория и внутри создали 
        //специфический метод Car GetByNameAsync(string name); 

    }
}