using Company_CRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Company_CRM.Controllers
{
    public class WorkController : Controller
    {
        private readonly SneakerFactoryContext _sneakerFactoryContext;

        public WorkController(SneakerFactoryContext sneakerFactoryContext)
        {
            _sneakerFactoryContext = sneakerFactoryContext;
        }

        [Authorize(Roles = Role.Employee)]
        public IActionResult EmployeeSpace()
        {
            var employee = _sneakerFactoryContext.Employees.First(e => e.Login == User.Identity.Name);
            List<Job> emplJobs;
            List<Employee> allEmployees;
            using (_sneakerFactoryContext)
            {
                emplJobs = _sneakerFactoryContext.Jobs.Where(j => j.ExecutorEmplId == employee.EmployeeId).Select(j => j).ToList();
                allEmployees = _sneakerFactoryContext.Employees.ToList();
            }
            return View(new EmployeesInfo() 
            { 
                EmployeeJobs = emplJobs, 
                Employees = allEmployees
            });
        }

        [Authorize(Roles = Role.Manager)]
        public IActionResult ManagerSpace()
        {
            List<PotentialClient> allPotentialClient;
            List<AvailableClient> allAvailableClient;
            List<Employee> allEmployees;
            List<Job> allJobs;
            List<Contract> allContracts;
            List<Sneaker> allSneakers;

            using (_sneakerFactoryContext)
            {
                allContracts = _sneakerFactoryContext.Contracts.ToList();
                allJobs = _sneakerFactoryContext.Jobs.ToList();
                allEmployees = _sneakerFactoryContext.Employees.ToList();
                allAvailableClient = _sneakerFactoryContext.AvailableClients.ToList();
                allPotentialClient = _sneakerFactoryContext.PotentialClients.ToList();
                allSneakers = _sneakerFactoryContext.Sneakers.ToList();
            }
            return View(new ManagersInfo()
            {
                AvailableClients = allAvailableClient,
                Employees = allEmployees,
                Jobs = allJobs,
                Contracts = allContracts,
                PotentialClients = allPotentialClient,
                Sneakers = allSneakers
            });
        }


        [HttpGet]
        public IActionResult ClientOrder()
        {
            ViewBag.Sneakers = _sneakerFactoryContext.Sneakers.ToArray();
            return View();
        }
        [HttpPost]
        public IActionResult ClientOrder(ClientOrderInfo info)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(ModelState.ErrorCount);
                ViewBag.Sneakers = _sneakerFactoryContext.Sneakers.ToArray();
                return View(info);
            }
            
            using (_sneakerFactoryContext)
            {
                var avClient = new AvailableClient()
                {
                    FirstName = info.FirstName,
                    SecondName = info.SecondName,
                    OrganisationName = info.OrganisationName,
                    Phone = info.Phone,
                    Email = info.Email,
                    Address = info.Address,
                };
                var pClient = new PotentialClient()
                {
                    FirstName = info.FirstName,
                    SecondName = info.SecondName,
                    OrganisationName = info.SecondName,
                    Phone = info.Phone,
                    Email = info.Email,
                    Address = info.Address,
                    Meeting = info.Meeting
                };

                if (_sneakerFactoryContext.AvailableClients.FirstOrDefault(ac => ac.OrganisationName == avClient.OrganisationName) == null)
                    _sneakerFactoryContext.AvailableClients.Add(avClient);
                if (_sneakerFactoryContext.PotentialClients.FirstOrDefault(pc => pc.OrganisationName == pClient.OrganisationName) == null)
                    _sneakerFactoryContext.PotentialClients.Add(pClient);
                _sneakerFactoryContext.SaveChanges();

                int idForContract = _sneakerFactoryContext.AvailableClients.FirstOrDefault(c => c.OrganisationName == info.OrganisationName).ClientId;
                List<Contract> contracts = new();
                int contractsId = _sneakerFactoryContext.Contracts.Count();
                foreach (var sneakerId in info.SneakerIdToValue.Keys)
                {
                    int amount = int.Parse(info.SneakerIdToValue[sneakerId]);
                    if(amount > 0)
                    {
                        for (int i = 0; i < amount; i++)
                        {
                            var contract = new Contract()
                            {
                                ClientId = idForContract,
                                SneakerId = _sneakerFactoryContext.Sneakers.First(s => s.SneakerId == int.Parse(sneakerId)).SneakerId,
                                SignDate = DateTime.Now,
                                Deadline = info.ContractInfo.Deadline
                            };
                            contracts.Add(contract);
                        }
                        
                    }
                }
                _sneakerFactoryContext.Contracts.AddRange(contracts);
                _sneakerFactoryContext.SaveChanges();
                return RedirectToAction("ClientOrderResult", "Work", _sneakerFactoryContext.AvailableClients.First(ac => ac.OrganisationName == info.OrganisationName) );
            }
            
        }
        
        public IActionResult ClientOrderResult(AvailableClient client)
        {
            using (_sneakerFactoryContext)
            {
                var contracts = _sneakerFactoryContext.Contracts.Where(c => c.ClientId == client.ClientId).Select(x => x).ToArray();
                var sneakers = _sneakerFactoryContext.Sneakers.ToArray();
                return View(new ClientContracts() { Contracts = contracts, Sneakers = sneakers });
            }
            
        }
    }
}
