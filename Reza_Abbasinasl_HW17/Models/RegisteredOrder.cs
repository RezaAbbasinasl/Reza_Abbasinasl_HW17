namespace Reza_Abbasinasl_HW17.Models
{
    public class RegisteredOrder
    {
        public int Order_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Order_Date { get; set; }
        public string Required_Date { get; set; }
        public string Shipped_Date { get; set; }
        public string FullNameStaff { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Quantity { get; set; }
        public decimal List_Price { get; set; }
        public decimal Discount { get; set; }
    }
}
