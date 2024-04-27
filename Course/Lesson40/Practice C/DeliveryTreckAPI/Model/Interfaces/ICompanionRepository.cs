namespace SQLLiteREpository
{
    public interface ICompanionRepository
    {
        List<Companion> GetAllCompanions();
        void AddCompanions(Companion companion);
    Companion GetCompanionByName(string name)
        void DeleteCompanion(string name);
        
    }
}
