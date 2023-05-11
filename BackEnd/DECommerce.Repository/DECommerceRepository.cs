using DECommerce.Models;
using IDECommerce.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DECommerce.Repository
{
    public class DECommerceRepository : IDECommerceReposiory
    {
        private IConfiguration _configuration;
        private DECommerceDb _model;

        public DECommerceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _model = new DECommerceDb(_configuration.GetSection("ConnectionStrings:DynamicECommerce").Value);
        }


        //users---------------------------------------------------------------------------------------------------------
        List<Users> IDECommerceReposiory.GetUsers()
        {
            List<Users> users = new List<Users>();

            users = _model.Users.ToList();
            return users;
        }

        bool IDECommerceReposiory.CreateUsers(Users users)
        {
            bool results = false;

            _model.Users.Add(users);
            results = _model.SaveChanges() > 0;
            return results;
        }

        //get by UserID
        Users IDECommerceReposiory.GetUserById(int UserID)
        {
            Users user = _model.Users.FirstOrDefault(x => x.UserID == UserID);
            return user;
        }

        //delete user
        bool IDECommerceReposiory.DeleteUsers(int UserID)
        {
            bool result = false;
            Users user = _model.Users.FirstOrDefault(x => x.UserID == UserID);
            _model.Remove(user);
            result = _model.SaveChanges() > 0;
            return result;
        }


        //IMPLEMENTAZIONE METODO LOGIN
        public Users GetUserByUsername(string username)
        {
            Users user = _model.Users.FirstOrDefault(u => u.Username == username);
            return user;
        }
        public UserRole GetUserRoleByUserId(int userId)
        {
            UserRole userRole = _model.UserRole.FirstOrDefault(x => x.UserID == userId);
            return userRole;

        }

        //UsersRole---------------------------------------------------------------------------------------------------------
        //Get UserRole
        List<UserRole> IDECommerceReposiory.GetUserRole()
        {
            List<UserRole> userRole = new List<UserRole>();

            userRole = _model.UserRole.ToList();
            return userRole;
        }

        bool IDECommerceReposiory.AddUserRole(UserRole userRole)
        {
            bool result = false;

            _model.UserRole.Add(userRole);
            result = _model.SaveChanges() > 0;
            return result;
        }

        //Role---------------------------------------------------------------------------------------------------------
        List<Roles> IDECommerceReposiory.GetRoles()
        {
            List<Roles> roles = new List<Roles>();

            roles = _model.Roles.ToList();
            return roles;
        }

        public Roles GetRoleById(int roleId)
        {
            Roles role = _model.Roles.FirstOrDefault(u => u.RoleID == roleId);
            return role;
        }

        //Orders---------------------------------------------------------------------------------------------------------
        List<Orders> IDECommerceReposiory.GetOrders()
        {
            List<Orders> orders = new List<Orders>();

            orders = _model.Orders.ToList();
            return orders;
        }

        //get by Userid
        List<Orders> IDECommerceReposiory.GetOrdersByUserID(int userID)
        {
            List<Orders> orders = new List<Orders>();

            orders = _model.Orders.Where(x => x.UserID == userID).ToList();


            return orders;
        }

        //get order by OrderID
        Orders IDECommerceReposiory.GetOrderById(int orderID)
        {
            Orders order = _model.Orders.FirstOrDefault(x => x.OrderID == orderID);
            return order;
        }

        //create order 
        // è tipo int perche deve ritornare l'orderID nella response dopo la post
        int IDECommerceReposiory.CreateOrder(Orders order)
        {
            bool results = false;

            _model.Orders.Add(order);
            results = _model.SaveChanges() > 0;
            return order.OrderID;
        }

        //delete Order
        bool IDECommerceReposiory.DeleteOrder(int orderID)
        {
            bool result = false;
            Orders order = _model.Orders.FirstOrDefault(x => x.OrderID == orderID);
            _model.Remove(order);
            result = _model.SaveChanges() > 0;
            return result;
        }

        //Order Details---------------------------------------------------------------------------------------------------------
        List<OrderDetails> IDECommerceReposiory.GetOrderDetails()
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();

            orderDetails = _model.OrderDetails.ToList();
            return orderDetails;
        }

        //get by Userid
        List<OrderDetails> IDECommerceReposiory.GetOrderDetailsByOrderID(int orderID)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();

            orderDetails = _model.OrderDetails.Where(x => x.OrderID == orderID).ToList();


            return orderDetails;
        }

        //delete Order Details
        bool IDECommerceReposiory.DeleteOrderDetail(int orderDetailID)
        {
            bool result = false;
            OrderDetails orderDetail = _model.OrderDetails.FirstOrDefault(x => x.OrderDetailsID == orderDetailID);
            _model.Remove(orderDetail);
            result = _model.SaveChanges() > 0;
            return result;
        }


        //create Order Detatil 
        bool IDECommerceReposiory.CreateOrderDetail(OrderDetails orderDetail)
        {
            bool results = false;

            _model.OrderDetails.Add(orderDetail);
            results = _model.SaveChanges() > 0;
            return results;
        }


        //Products---------------------------------------------------------------------------------------------------------
        List<Products> IDECommerceReposiory.GetProducts()
        {
            List<Products> products = new List<Products>();

            products = _model.Products.ToList();
            return products;
        }

        //get products by ProductID
        Products IDECommerceReposiory.GetProductByID(int productID)
        {
            Products product = _model.Products.FirstOrDefault(x => x.ProductID == productID);
            return product;
        }

        //get by ProductCategoriesID
        List<Products> IDECommerceReposiory.GetProductsByProductCategoriesID(int productCategoriesID)
        {
            List<Products> products = new List<Products>();

            products = _model.Products.Where(x => x.ProductCategoriesID == productCategoriesID).ToList();


            return products;
        }

        //create product 
        bool IDECommerceReposiory.CreateProduct(Products product)
        {
            bool results = false;

            // Aggiungi il prodotto al contesto del database
            _model.Products.Add(product);
            results = _model.SaveChanges() > 0;
            return results;
        }

        //delete Order Product
        bool IDECommerceReposiory.DeleteProduct(int productID)
        {
            bool result = false;
            Products products = _model.Products.FirstOrDefault(x => x.ProductID == productID);
            _model.Remove(products);
            result = _model.SaveChanges() > 0;
            return result;
        }

        //Product Category---------------------------------------------------------------------------------------------------------
        List<ProductCategories> IDECommerceReposiory.GetProductCategories()
        {
            List<ProductCategories> productCategory = new List<ProductCategories>();

            productCategory = _model.ProductCategories.ToList();
            return productCategory;
        }

        //create product category 
        bool IDECommerceReposiory.CreateProductCategory(ProductCategories productCategories)
        {
            bool results = false;

            _model.ProductCategories.Add(productCategories);
            results = _model.SaveChanges() > 0;
            return results;
        }

        //delete Order Product
        bool IDECommerceReposiory.DeleteProductCategory(int ProductCategoriesID)
        {
            bool result = false;
            ProductCategories productCategories = _model.ProductCategories.FirstOrDefault(x => x.ProductCategoriesID == ProductCategoriesID);
            _model.Remove(productCategories);
            result = _model.SaveChanges() > 0;
            return result;
        }

        //get product category by id

        public ProductCategories GetProductCategoriesById(int productCategoriesID)
        {
            ProductCategories productCategories = _model.ProductCategories.FirstOrDefault(x => x.ProductCategoriesID == productCategoriesID);
            return productCategories;
        }

        //Configuration---------------------------------------------------------------------------------------------------------
        //get Configuration

        Configurations IDECommerceReposiory.GetConfigurations()
        { 
            Configurations configurations = _model.Configurations.FirstOrDefault();
            return configurations;
        } 

    }
}
