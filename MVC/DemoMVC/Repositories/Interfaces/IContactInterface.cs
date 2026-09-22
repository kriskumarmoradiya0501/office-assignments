using System.Collections.Generic;

namespace Repositories
{
    public interface IContactInterface
    {
        Task<List<t_Contact>> GetAll();

        Task<List<t_Contact>> GetAllByUser(int userid);

        Task<t_Contact> GetOne(int contactid);

        Task<int> Add(t_Contact contact);

        Task<int> Update(t_Contact contact);

        Task<int> Delete(int contactid);
    }
}