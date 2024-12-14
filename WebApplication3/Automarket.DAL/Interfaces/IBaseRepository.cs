using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itmytask.DAL.Interfaces
{
    public interface IBaseRepository<T> //Общие методы для взаимодействия с бд <> - значит Generic
    {                                     //Generic -система понимает с каким объектом имеет дело при передаче
                                          //при наследовании интерфейса передаётся определённый объект
        Task<bool> Create(T entity);// bool Create(T entity);
        Task<T> GetAsync(int id);  //метод 2   T GetAsync(int id); 
        //IEnumerable<T> Select();
        Task<List<T>> Select(); //  получение коллекции элементов в тип Generic передаём селект без параметров //IEnumerable<T> Select();
        Task<List<T>> GetAsyncSelect();

        Task<bool> Delete(T entity); //4 метод удаления из таблицы bool Delete(T entity);
        Task<bool> UpdateAsync(T entity);

    }
}