﻿using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(categoryDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) NotFound();

            var categoryDTO = await _categoryService.GetById(id);

            if (categoryDTO == null) NotFound();

            return View(categoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(categoryDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null) NotFound();

            var categoryDTO = await _categoryService.GetById(id);

            if (categoryDTO == null) NotFound();
            
            return View(categoryDTO);
        }

        [HttpPost, ActionName("Details")]
        public async Task<IActionResult> ShowDetails(int? id)
        {
            await _categoryService.GetById(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) NotFound();

            var categoryDTO = await _categoryService.GetById(id);

            if (categoryDTO == null) NotFound();

            return View(categoryDTO);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
