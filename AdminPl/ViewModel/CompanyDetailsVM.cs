using DAL;

namespace AdminPl.ViewModel
{
    public class CompanyDetailsVM

    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public ICollection<Travel> Travels { get; set; } = new List<Travel>();
    }
}
