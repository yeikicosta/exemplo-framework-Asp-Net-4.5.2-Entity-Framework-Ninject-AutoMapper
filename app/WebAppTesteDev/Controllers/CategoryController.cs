using AutoMapper;
using CommunicationAPI;
using DomainProduct;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebAppTesteDev.Models;
using WebAppTesteDev.Resources;

namespace WebAppTesteDev.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CommAPICategory CommAPICategory = new CommAPICategory();
        public async Task<ActionResult> List()
        {
            ViewBag.Title = ResourceGlobal.Title_List_Category;
            ViewBag.ButtonNew = ResourceGlobal.Button_New;
            ViewBag.ButtonEdit = ResourceGlobal.Button_Edit;
            ViewBag.ButtonRemove = ResourceGlobal.Button_Remove;
            ViewBag.ButtonDetails = ResourceGlobal.ButtonDetails;
            var Categories = await CommAPICategory.GetAllAsync();
            var categoryViewModel = Mapper.Map<List<Category>, List<ViewModelCategory>>(Categories);
            return View(categoryViewModel);
        }

        public async Task<ActionResult> DetailsAsync(int id)
        {
            ViewBag.ButtonCancel = ResourceGlobal.Button_Cancel;
            ViewBag.ButtonEdit = ResourceGlobal.Button_Edit;
            var category = await CommAPICategory.GetByIdAsync(id);
            ViewBag.Title = category.Name;
            var categoryViewModel = Mapper.Map<Category, ViewModelCategory>(category);
            return View(categoryViewModel);
        }

        public async Task<ActionResult> Add()
        {
            ViewBag.Title = ResourceGlobal.Title_Register_Product;
            ViewBag.ButtonCancel = ResourceGlobal.Button_Cancel;
            ViewBag.ButtonSave = ResourceGlobal.Button_Save;

            List<Category> categories = await CommAPICategory.GetAllAsync();
            var categoryViewModel = Mapper.Map<List<Category>, List<ViewModelCategory>>(categories);
            ViewBag.CategoriesSelect = categoryViewModel;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(ViewModelCategory viewModelCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = Mapper.Map<ViewModelCategory, Category>(viewModelCategory);
                    int IdProduct = await CommAPICategory.AddAsync(category);
                    return RedirectToAction("List");
                }
                else
                {
                    return await Add();
                }
            }
            catch (Exception ex)
            {
                return await Add();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Title = ResourceGlobal.Title_Register_Categories;
            ViewBag.ButtonCancel = ResourceGlobal.Button_Cancel;
            ViewBag.ButtonSave = ResourceGlobal.Button_Save;

            Category category = await CommAPICategory.GetByIdAsync(id);
            var viewModelCategory = Mapper.Map<Category, ViewModelCategory>(category);

            return View(viewModelCategory);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, ViewModelCategory viewModelCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = Mapper.Map<ViewModelCategory, Category>(viewModelCategory);
                    await CommAPICategory.UpdateAsync(category);
                    return RedirectToAction("List");
                }
                else
                {
                    return await Add();
                }
            }
            catch (Exception ex)
            {
                return await Add();
            }
        }

        public async Task<JsonResult> DeleteAsync(int id)
        {
            try
            {
                await CommAPICategory.DeleteAsync(id);
                return Json(new { Success = true, Message = "Exclusão realizada com sucesso !" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
