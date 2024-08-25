using Reza_Abbasinasl_HW17.Models;
using System.Data;
using System.Data.SqlClient;

namespace Reza_Abbasinasl_HW17.DAL
{
    public class OrderDAL
    {
        private readonly string _connectionStr = "Data Source=.\\SQL2022;Initial Catalog=BikeStore;Integrated Security=True;Encrypt=False";
        public List<RegisteredOrder> RegisteredOrders(int orderId)
        {
            List<RegisteredOrder> orderList = new List<RegisteredOrder>();
            using (SqlConnection con = new SqlConnection(_connectionStr))
            {
                string quaryStr = $"SELECT so.order_id, sc.first_name, sc.last_name, sc.[state] + ' ' + sc.city +' '+ sc.street AS [Address], sc.phone, so.order_date, so.required_date, so.shipped_date,tblss.first_name+' '+tblss.last_name AS FullNameStaff, soi.product_id, pp.product_name, soi.quantity, soi.list_price, soi.discount\r\nFROM sales.orders so JOIN sales.customers sc\r\nON so.customer_id = sc.customer_id \r\nLEFT JOIN sales.staffs tblss ON so.staff_id = tblss.staff_id\r\nLEFT JOIN sales.order_items soi ON so.order_id = soi.order_id\r\nLEFT JOIN production.products pp ON soi.product_id = pp.product_id\r\nWHERE so.order_id = {orderId}";
                SqlCommand command = new SqlCommand(quaryStr, con);
                command.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RegisteredOrder order = new RegisteredOrder();

                    order.Order_Id = (Int32)reader["Order_Id"];
                    order.First_Name = reader["First_Name"].ToString() ?? string.Empty;
                    order.Last_Name = reader["Last_Name"].ToString() ?? string.Empty;
                    order.Address = reader["Address"].ToString() ?? string.Empty;
                    order.Phone = reader["Phone"].ToString() ?? string.Empty;
                    order.Order_Date = reader["Order_Date"].ToString() ?? string.Empty;
                    order.Shipped_Date = reader["Shipped_Date"].ToString() ?? string.Empty;
                    order.FullNameStaff = reader["FullNameStaff"].ToString() ?? string.Empty;
                    order.Product_Id = (Int32)reader["Product_Id"];
                    order.Product_Name = reader["Product_Name"].ToString() ?? string.Empty;
                    order.Quantity = (Int32)reader["Quantity"];
                    order.List_Price = (decimal)reader["List_Price"];
                    order.Discount = (decimal)reader["Discount"];
                    orderList.Add(order);
                }
            };
            return orderList;
        }
    }
}