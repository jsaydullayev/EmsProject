using Ems.Data.Entities;

namespace Ems.Data.Repositories.Contracts;
public interface IUnitOfWork
{
    IBaseRepository<Contract> ContractRepository();
    IBaseRepository<Employee> EmployeeRepository();
    IBaseRepository<Feedback> FeedbackRepository();
    IBaseRepository<Gender> GenderRepository();
    IBaseRepository<InfoCity> InfoCityRepository();
    IBaseRepository<InfoContent> InfoContentRepository();
    IBaseRepository<InfoContentType> InfoContentTypeRepository();
    IBaseRepository<InfoCountry> InfoCountryRepository();
    IBaseRepository<InfoDistrict> InfoDistrictRepository();
    IBaseRepository<InfoFeedback> InfoFeedbackRepository();
    IBaseRepository<InfoTaskResult> InfoTaskResultRepository();
    IBaseRepository<InfoTaskResultType> InfoTaskResultTypeRepository();
    IBaseRepository<InfoTaskStatus> InfoTaskStatusRepository();
    IBaseRepository<JobLevel> JobLevelRepository();
    IBaseRepository<JobType> JobtypeRepository();
    IBaseRepository<Organization> OrganizationRepository();
    IBaseRepository<Role> RoleRepository();
    IBaseRepository<Salary> SalaryRepository();
    IBaseRepository<State> StateRepository();
    IBaseRepository<User> UserRepository();
    IBaseRepository<VacationStatus> VacationStatusRepository();
    IBaseRepository<VacationType> VacationTypeRepository();
    IBaseRepository<WorkTime> WorkTimeRepository();
}
