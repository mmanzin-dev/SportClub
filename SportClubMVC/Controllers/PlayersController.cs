using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportClubMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace SportClubMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PlayersController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;

        public PlayersController(IPlayerService playerService, ITeamService teamService)
        {
            _playerService = playerService;
            _teamService = teamService;
        }

        [AllowAnonymous]
        // GET: Players
        public async Task<IActionResult> Index()
        {
            return View(await _playerService.GetAllPlayersAsync());
        }

        [AllowAnonymous]
        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _playerService.GetPlayerByIdAsync(id.Value);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: Players/Create
        public async Task<IActionResult> Create()
        {
            ViewData["TeamId"] = new SelectList(await _teamService.GetAllTeamsAsync(), "Id", "Name");
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,Email,PhoneNumber,JerseyNumber,Position,Active,TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                await _playerService.CreatePlayerAsync(player);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(await _teamService.GetAllTeamsAsync(), "Id", "Name", player.TeamId);
            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _playerService.GetPlayerByIdAsync(id.Value);
            if (player == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(await _teamService.GetAllTeamsAsync(), "Id", "Name", player.TeamId);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Email,PhoneNumber,JerseyNumber,Position,Active,TeamId")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _playerService.UpdatePlayerAsync(player);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await _playerService.GetPlayerByIdAsync(player.Id);
                    if (exists == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(await _teamService.GetAllTeamsAsync(), "Id", "Name", player.TeamId);
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _playerService.GetPlayerByIdAsync(id.Value);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _playerService.DeletePlayerAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        // ActivePlayers
        public async Task<IActionResult> ActivePlayers()
        {
            var players = await _playerService.GetActivePlayersAsync();
            return View(players);
        }

        [AllowAnonymous]
        // SearchByPosition
        public async Task<IActionResult> SearchByPosition(string position)
        {
            if (string.IsNullOrEmpty(position))
            {
                ViewBag.Position = "";
                return View(new List<Player>());
            }

            var players = await _playerService.SearchByPositionAsync(position);
            ViewBag.Position = position;
            return View(players);
        }
    }
}