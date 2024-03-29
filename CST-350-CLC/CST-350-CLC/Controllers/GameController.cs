﻿using CST_350_CLC.Models;
using CST_350_CLC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CST_350_CLC.Controllers {
    public class GameController : Controller {
        GameDAO gameDAO = new GameDAO();

        public IActionResult Index() {
            return View(gameDAO.startup());
        }

        public IActionResult CellClick(int id) {
            Console.WriteLine("Id passed to update board function is: " + id);
            return View("Index", gameDAO.updateBoard(id));
        }
    }
}
