using StartClassTest.ViewModel;

namespace StartClassTest.IServices
{
    public interface IContactUsService
    {
        Task<bool> CreateContactus(ContactUsViewModel model);
    }
}
