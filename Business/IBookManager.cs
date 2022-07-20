using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BMS.Data.Business
{
    public interface IBookManager
    {
        Task<MBook> GetByIdAsync(Guid id);
        Task<List<MBook>> GetListAsync();

        Task UpdateAsync(MBook book);
        Task DeleteAsync(Guid id);
        Task<MBook> CreateAsync(MBook book);
    }





}
