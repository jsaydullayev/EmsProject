using Ems.Data.Contexts;
using Ems.Data.Entities;
using Ems.Data.Repositories.Contracts;
using System.Runtime.InteropServices;

namespace Ems.Data.Repositories;
public class UnitOfWork(EMSContext context) : IUnitOfWork
{
    private readonly EMSContext _context = context;

    private IBaseRepository<Contract> _contractRepository;

    public IBaseRepository<Contract> ContractRepository() => _contractRepository ?? new BaseRepository<Contract>(_context);


    private IBaseRepository<Employee> _employeeRepository;
    public IBaseRepository<Employee> EmployeeRepository() => _employeeRepository ?? new BaseRepository<Employee>(_context);


    private IBaseRepository<Feedback> _feedbackRepository;
    public IBaseRepository<Feedback> FeedbackRepository() => _feedbackRepository ?? new BaseRepository<Feedback>(_context);


    private IBaseRepository<Gender> _genderRepository;
    public IBaseRepository<Gender> GenderRepository() => _genderRepository ?? new BaseRepository<Gender>(_context);


    private IBaseRepository<InfoCity> _infoCityRepository;
    public IBaseRepository<InfoCity> InfoCityRepository() => _infoCityRepository ?? new BaseRepository<InfoCity>(_context);


    private IBaseRepository<InfoContent> _infoContentRepository;
    public IBaseRepository<InfoContent> InfoContentRepository() => _infoContentRepository ?? new BaseRepository<InfoContent>(_context);


    private IBaseRepository<InfoContentType> _infoContentTypeRepository;
    public IBaseRepository<InfoContentType> InfoContentTypeRepository() => _infoContentTypeRepository ?? new BaseRepository<InfoContentType>(_context);


    private IBaseRepository<InfoCountry> _infoCountryRepository;
    public IBaseRepository<InfoCountry> InfoCountryRepository() => _infoCountryRepository ?? new BaseRepository<InfoCountry>(_context);


    private IBaseRepository<InfoDistrict> _infoDistrictRepository;
    public IBaseRepository<InfoDistrict> InfoDistrictRepository() => _infoDistrictRepository ?? new BaseRepository<InfoDistrict>(_context);


    private IBaseRepository<InfoFeedback> _infoFeedbackRepository;
    public IBaseRepository<InfoFeedback> InfoFeedbackRepository() => _infoFeedbackRepository ?? new BaseRepository<InfoFeedback>(_context);


    private IBaseRepository<InfoTaskResult> _infoTaskResultRepository;
    public IBaseRepository<InfoTaskResult> InfoTaskResultRepository() => _infoTaskResultRepository ?? new BaseRepository<InfoTaskResult>(_context);


    private IBaseRepository<InfoTaskResultType> _infoTaskResultTypeRepository;
    public IBaseRepository<InfoTaskResultType> InfoTaskResultTypeRepository() => _infoTaskResultTypeRepository ?? new BaseRepository<InfoTaskResultType>(_context);


    private IBaseRepository<InfoTaskStatus> _infoTaskStatusRepository;
    public IBaseRepository<InfoTaskStatus> InfoTaskStatusRepository() => _infoTaskStatusRepository ?? new BaseRepository<InfoTaskStatus>(_context);


    private IBaseRepository<JobLevel> _jobLevelRepository;
    public IBaseRepository<JobLevel> JobLevelRepository() => _jobLevelRepository ?? new BaseRepository<JobLevel>(_context);


    private IBaseRepository<JobType> _jobTypeRepository;
    public IBaseRepository<JobType> JobtypeRepository() => _jobTypeRepository ?? new BaseRepository<JobType>(_context);


    private IBaseRepository<Organization> _organizationRepository;
    public IBaseRepository<Organization> OrganizationRepository() => _organizationRepository ?? new BaseRepository<Organization>(_context);


    private IBaseRepository<Role> _roleRepository;
    public IBaseRepository<Role> RoleRepository() => _roleRepository ?? new BaseRepository<Role>(_context);


    private IBaseRepository<Salary> _salaryRepository;
    public IBaseRepository<Salary> SalaryRepository() => _salaryRepository ?? new BaseRepository<Salary>(_context);


    private IBaseRepository<State> _stateRepository;
    public IBaseRepository<State> StateRepository() => _stateRepository ?? new BaseRepository<State>(_context);


    private IBaseRepository<User> _userRepository;
    public IBaseRepository<User> UserRepository() => _userRepository ?? new BaseRepository<User>(_context);


    private IBaseRepository<VacationStatus> _vacationStatusRepository;
    public IBaseRepository<VacationStatus> VacationStatusRepository() => _vacationStatusRepository ?? new BaseRepository<VacationStatus>(_context);


    private IBaseRepository<VacationType> _vacationTypeRepository;
    public IBaseRepository<VacationType> VacationTypeRepository() => _vacationTypeRepository ?? new BaseRepository<VacationType>(_context);


    private IBaseRepository<WorkTime> _workTimeRepository;
    public IBaseRepository<WorkTime> WorkTimeRepository() => _workTimeRepository ?? new BaseRepository<WorkTime>(_context);
}
