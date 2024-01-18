using Entity.Dto.Blogs;
using Entity.Dto.Contacts;
using Entity.Dto.HomePages;

namespace WebUI.ViewModels
{
    public class HomeViewModel
    {
        public ContactViewDTO ContactViewDTO { get; set; }
        public HomePageViewDTO HomePageViewDTO { get; set; }
        public List<BlogDTO> Blogs { get; set; }
    }
}
