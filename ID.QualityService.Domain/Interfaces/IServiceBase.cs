using System.Collections.Generic;

namespace ID.QualityService.Domain.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
