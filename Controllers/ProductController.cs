using Microsoft.AspNetCore.Mvc;
using ADOProductCURD2.Models;
using ADOProductCURD2.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.CodeAnalysis;

namespace ADOProductCURD.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product p)
        {
           ProductRepo prodRepo = new ProductRepo();
            try
            {
                prodRepo.AddProduct(p);
                return Content("Product is added to databse!");
            }
            catch (SqlException ex)
            {
                return Content("OOPPS!!" + ex.Message);
            }
        }
        public IActionResult AllProducts()
        {
            ProductRepo prodRepo = new ProductRepo();
            try
            {
                IEnumerable<Product> listOfProducts = prodRepo.GetAllProduct();
                return View(listOfProducts);
            }
            catch (SqlException ex)
            {
                return Content("OOPPS!!" + ex.Message);
            }
        }
        public IActionResult ProductDetail(int id)
        {
            ProductRepo prodRepo = new ProductRepo();
            try
            {
                Product p = prodRepo.GetSingleProduct(id);
                return View(p);
            }
            catch (SqlException ex)
            {
                return Content("OOPPS!!" + ex.Message);
            }
        }
        public IActionResult EditProduct(int id)
        {
            ProductRepo prodRepo = new ProductRepo();
            try
            {
                Product p = prodRepo.GetSingleProduct(id);
                return View(p);
            }
            catch (SqlException ex)
            {
                return Content("OOPPS!!" + ex.Message);
            }
      
        }

        [HttpPost]
        public IActionResult EditProduct(Product p)
        {
            ProductRepo prodRepo = new ProductRepo();
            try
            {
                prodRepo.UpdateProduct(p);
            }
            catch (SqlException ex)
            {
                return Content("OOPPS!!" + ex.Message);
            }
            return Content("The record has been updated");
        }

        //delete..
        public IActionResult DeleteProduct(int id)
        {
            ProductRepo prodRepo = new ProductRepo();
            try
            {
                Product p = prodRepo.GetSingleProduct(id);
                prodRepo.DeleteProduct(p);
                return Content("The record has been deleted");

            }
            catch (SqlException ex)
            {
                return Content("OOPPS!!" + ex.Message);
            }
        }
    }
}