using DECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDECommerce.Interface
{
    public interface IDECommerceReposiory
    {
        //Users--------------------------------------------------------------------
        List<Users> GetUsers();
        bool CreateUsers(Users users);
        Users GetUserById(int userID);
        bool DeleteUsers(int userID);

        //login
        Users GetUserByUsername(string username);
        UserRole GetUserRoleByUserId(int userID);


        //User Role--------------------------------------------------------------------
        List<UserRole> GetUserRole();
        bool AddUserRole(UserRole userRole);//ci serve per completare lo user role per assegnare il ruolo allo user

        //Roles--------------------------------------------------------------------
        List<Roles> GetRoles();
        Roles GetRoleById(int roleId);//ci serve per completare la tabella di mezzo user role per assegnare il ruolo allo user

        //Orders--------------------------------------------------------------------
        List<Orders> GetOrders();
        List<Orders> GetOrdersByUserID(int userID);
        Orders GetOrderById(int orderID);
        int CreateOrder(Orders order);
        bool DeleteOrder(int ordeID);

        //Order Details--------------------------------------------------------------------
        List<OrderDetails> GetOrderDetails();
        List<OrderDetails> GetOrderDetailsByOrderID(int orderID);
        bool DeleteOrderDetail(int orderDetailID);
        bool CreateOrderDetail(OrderDetails orderDetail);


        //Products--------------------------------------------------------------------
        List<Products> GetProducts();
        Products GetProductByID(int productID);
        List<Products> GetProductsByProductCategoriesID(int productCategoriesID);
        bool DeleteProduct(int productID);
        bool CreateProduct(Products product);

        //Product Category--------------------------------------------------------------------
        List<ProductCategories> GetProductCategories();
        ProductCategories GetProductCategoriesById(int productCategoriesID);
        bool CreateProductCategory(ProductCategories productCategory);
        bool DeleteProductCategory(int productCategoriesID);

        //Configurations--------------------------------------------------------------------

        Configurations GetConfigurations();
    }
}
