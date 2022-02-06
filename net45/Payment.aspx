<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="RazorpaySampleApp.Payment" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

<button id = "rzp-button1"> Pay </button>
<body>
    <form action="Charge.aspx" method="post">

  <script src = "https://checkout.razorpay.com/v1/checkout.js"> </script>
  <script>
    var options = {
      "key": "rzp_test_2pjQoIV7c1RY6C",
      "order_id": "<%=orderId%>",
      "customer_id": "<%=custId%>",
      "recurring": "1",
      "handler": function (response) {
        alert(response.razorpay_payment_id);
        alert(response.razorpay_order_id);
        alert(response.razorpay_signature);
      },
      "notes": {
        "note_key 1": "Beam me up Scotty",
        "note_key 2": "Tea. Earl Gray. Hot."
      },
      "theme": {
        "color": "#F37254"
      }
    };
    var rzp1 = new Razorpay(options);
    document.getElementById('rzp-button1').onclick = function (e) {
      rzp1.open();
      e.preventDefault();
    }
  </script>
</body>

    </html>
