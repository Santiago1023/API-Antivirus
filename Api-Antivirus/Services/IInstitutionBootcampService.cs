using System.Collections.Generic;
using System.Threading.Tasks;
using Api_Antivirus.Models;

namespace Api_Antivirus.Services
{
    public interface IInstitutionBootcampService
    {
        Task<IEnumerable<InstitutionBootcamp>> GetAllInstitutionBootcampsAsync();
        Task<InstitutionBootcamp> GetInstitutionBootcampByIdAsync(int id);
        Task<InstitutionBootcamp> CreateInstitutionBootcampAsync(InstitutionBootcamp institutionBootcamp);
        Task<InstitutionBootcamp> UpdateInstitutionBootcampAsync(int id, InstitutionBootcamp institutionBootcamp);
        Task<bool> DeleteInstitutionBootcampAsync(int id);
    }
}
