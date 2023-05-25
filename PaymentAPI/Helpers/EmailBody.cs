namespace PaymentAPI.Helpers
{
    public static class EmailBody
    {
        public static string EmailStringBody()
        {
            return $@"<html>
    <head>
    </head>
<body style=""margin:0;padding:0;font-family: Arial, Helvetica, sans-serif;"">
<div style="" height: auto;background: linear-gradient(to,top,#c9c9ff 50%,#6e6ef6 90%) no-repeat; width:400px;padding:30px"">
<div>
<div>
<h1>Customer Triggered Money Transfer</h1>
<hr>
<p>You're receiving this e-mail because you have privilage to approve the transfer. </p>
<p> Please login to below application and approve</p>
<a href=""http://localhost:4200/login""target=""_blank"" style="" background:#0d6efd;padding:10px;border:none;color:white;border-radius:4px;display:block;margin0 auto;width:50%;text-align:center;text-decoration:none"">Login</a><br>
<p>Thanks & Regards,<br><br>Pears Paul</p>
</div>
</div>
</div>
</body>
</html>";
        }
    }
}
