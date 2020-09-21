using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DogGo.Models;
using DogGo.Models.ViewModels;
using DogGo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DogGo.Controllers
{
    public class WalkersController : Controller
    {

        private readonly IWalkerRepository _walkerRepo;
        private readonly IWalkRepository _walkRepo;
        private readonly IOwnerRepository _ownerRepo;

        // ASP.NET will give us an instance of our Walker Repository. This is called "Dependency Injection"
        public WalkersController(
            IWalkerRepository walkerRepository,
            IWalkRepository walkRepository,
            IOwnerRepository ownerRepository)

        {
            _walkerRepo = walkerRepository;
            _walkRepo = walkRepository;
            _ownerRepo = ownerRepository;
        }
        private int GetCurrentUserId()
        {
            
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId;
            try
            {
                userId = int.Parse(id);
            }
            catch (Exception ex)
            {
                userId = 0;
            }
            return userId;
        }
        // GET: Walkers
        public ActionResult Index()
        {
            
            int userId = GetCurrentUserId();
            List<Walker> walkers;
            if (userId == 0) walkers = _walkerRepo.GetAllWalkers();
            else
            {
            Owner owner = _ownerRepo.GetOwnerById(userId);
            walkers = _walkerRepo.GetWalkersInNeighborhood(owner.NeighborhoodId);
            }

            return View(walkers);
        }
        // GET: Walkers/Details/5
        public ActionResult Details(int id)
        {
            
            Walker walker = _walkerRepo.GetWalkerById(id);
            List <Walk> walks = _walkRepo.GetWalksByWalkerId(walker.Id);
            WalkerProfileViewModel vm = new WalkerProfileViewModel
            {
                Walker = walker,
                Walks = walks
                
            };

            if (vm.Walker == null)
            {
                return NotFound();
            }

            return View(vm);
        }
    }
}
