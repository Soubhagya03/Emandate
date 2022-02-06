using Razorpay.Api;
using System;
using System.Collections.Generic;

namespace RazorpaySampleApp
{
    public partial class Payment : System.Web.UI.Page
    {
        public string orderId;
        public string custId;

        protected void Page_Load(object sender, EventArgs e)
        {

            string key = "rzp_test_2pjQoIV7c1RY6C";
            string secret = "nWwe91xQO3NIDzJUp1mUmr9O";

            RazorpayClient client = new RazorpayClient(key, secret);

           
            Dictionary<string, object> customers = new Dictionary<string, object>();
            customers.Add("name", "Test");
            customers.Add("email", "admin@aenterprises.com");
            customers.Add("contact", "9828818465");
            customers.Add("fail_existing", "0");

            Razorpay.Api.Customer customer = client.Customer.Create(customers);

            custId = customer["id"].ToString();

            Dictionary<string, object> orders = new Dictionary<string, object>();
            orders.Add("amount", 0); // this amount should be same as transaction amount
            orders.Add("currency", "INR");
            orders.Add("receipt", "12121");
            orders.Add("payment_capture", 1);
            orders.Add("method", "emandate");
            orders.Add("customer_id", customer["id"].ToString());

            Dictionary<string, object> token = new Dictionary<string, object>();
            token.Add("auth_type", "netbanking");
            token.Add("expire_at", 4102444799);
            token.Add("max_amount", 50000);
            

            Dictionary<string, object> bank_account = new Dictionary<string, object>();
            bank_account.Add("beneficiary_name", "Gaurav Kumar");
            bank_account.Add("account_number", "11214311215411");
            bank_account.Add("account_type", "savings");
            bank_account.Add("ifsc_code", "HDFC0001233");

            token.Add("bank_account", bank_account);
            orders.Add("token", token);

            Razorpay.Api.Order order = client.Order.Create(orders);
            orderId = order["id"].ToString();


        }
    }
}