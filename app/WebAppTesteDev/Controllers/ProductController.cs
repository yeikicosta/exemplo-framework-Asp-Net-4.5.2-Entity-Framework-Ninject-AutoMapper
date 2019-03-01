using AutoMapper;
using CommunicationAPI;
using DomainProduct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppTesteDev.Models;
using WebAppTesteDev.Resources;

namespace WebAppTesteDev.Controllers
{
    public class ProductController : Controller
    {
        private readonly CommAPIProduct CommAPIProduct = new CommAPIProduct();
        private readonly CommAPICategory CommAPICategory = new CommAPICategory();
        public ActionResult List()
        {
            ViewBag.Title = ResourceGlobal.Title_List_Product;
            ViewBag.ButtonNew = ResourceGlobal.Button_New;
            ViewBag.ButtonEdit = ResourceGlobal.Button_Edit;
            ViewBag.ButtonRemove = ResourceGlobal.Button_Remove;
            ViewBag.ButtonDetails = ResourceGlobal.ButtonDetails;

            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> ListAjax(string name)
        {
            ViewBag.Title = ResourceGlobal.Title_List_Product;
            ViewBag.ButtonNew = ResourceGlobal.Button_New;
            ViewBag.ButtonEdit = ResourceGlobal.Button_Edit;
            ViewBag.ButtonRemove = ResourceGlobal.Button_Remove;
            ViewBag.ButtonDetails = ResourceGlobal.ButtonDetails;

            List<Product> Products = await CommAPIProduct.FindByNameAsync(name);
            var productsViewModel = Mapper.Map<List<Product>, List<ViewModelProduct>>(Products);
            return PartialView(productsViewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            ViewBag.ButtonCancel = ResourceGlobal.Button_Cancel;
            ViewBag.ButtonEdit = ResourceGlobal.Button_Edit;
            var product = await CommAPIProduct.GetByIdAsync(id);
            ViewBag.Title = product.Name;
            var productViewModel = Mapper.Map<Product, ViewModelProduct>(product);
            return View(productViewModel);
        }

        public async Task<ActionResult> Add()
        {
            ViewBag.Title = ResourceGlobal.Title_Register_Product;
            ViewBag.ButtonCancel = ResourceGlobal.Button_Cancel;
            ViewBag.ButtonSave = ResourceGlobal.Button_Save;

            List<Category> categories = await CommAPICategory.GetAllAsync();
            var viewModelProduct = new ViewModelProduct();
            var categoryViewModel = Mapper.Map<List<Category>, List<ViewModelCategory>>(categories);
            viewModelProduct.CategoriesSelect = categoryViewModel;
            return View(viewModelProduct);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ViewModelProduct productViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string nameFile = "default.jpg";
                    if (productViewModel.UploadedFile != null)
                    {
                        nameFile = $"{new Random().Next(100, 999)}_{Regex.Replace(productViewModel.Name.Trim(), @"\s", "")}.{Path.GetExtension(productViewModel.UploadedFile.FileName)}";
                        string path = Path.Combine(Server.MapPath("~/Content/images/products"), nameFile);
                        productViewModel.UploadedFile.SaveAs(path);
                    }
                    productViewModel.Image = nameFile;
                    var product = Mapper.Map<ViewModelProduct, Product>(productViewModel);
                    int IdProduct = await CommAPIProduct.AddAsync(product);
                    return RedirectToAction("List");
                }
                else
                {
                    return await Add();
                }
            }
            catch(Exception ex)
            {
                return await Add();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.Title = ResourceGlobal.Title_Register_Product;
            ViewBag.ButtonCancel = ResourceGlobal.Button_Cancel;
            ViewBag.ButtonSave = ResourceGlobal.Button_Save;

            List<Category> categories = await CommAPICategory.GetAllAsync();
            var viewModelCategory = Mapper.Map<List<Category>, List<ViewModelCategory>>(categories);

            var product = await CommAPIProduct.GetByIdAsync(id);
            var viewModelProduct = Mapper.Map<Product, ViewModelProduct>(product);

            viewModelProduct.CategoriesSelect = viewModelCategory;

            foreach(var v in viewModelProduct.CategoriesSelect)
                if(product.IdCategory == v.Id)
                    v.Selected = true;

            return View(viewModelProduct);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, ViewModelProduct productViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string nameFile = "default.jpg";
                    if (productViewModel.UploadedFile != null)
                    {
                        nameFile = $"{new Random().Next(100, 999)}_{Regex.Replace(productViewModel.Name.Trim(), @"\s", "")}.{Path.GetExtension(productViewModel.UploadedFile.FileName)}";
                        string path = Path.Combine(Server.MapPath("~/Content/images/products"), nameFile);
                        productViewModel.UploadedFile.SaveAs(path);
                    }
                    productViewModel.Image = nameFile;
                    var product = Mapper.Map<ViewModelProduct, Product>(productViewModel);
                    await CommAPIProduct.UpdateAsync(product);
                    return RedirectToAction("List");
                }
                else
                {
                    return await Edit(id);
                }
            }
            catch (Exception ex)
            {
                return await Edit(id);
            }

            
        }

        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                await CommAPIProduct.DeleteAsync(id);
                return Json(new { Success = true, Message = "Exclusão realizada com sucesso !" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
