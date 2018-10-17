--AUTHOR: JAMES DIX
--DATE: 20 SEPT 2018
--SUBJECT:aspnet.mvc-lab02-

namespace PartyInvites1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

@{
    Layout = null;
} <!DOCTYPE html>
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
    <link rel="stylesheet" href="/lib/bootstrap/dist/css/bootstrap.css" />
</head>
<body>
    <div class="text-center">
        <h3>We’re going to have an exciting party!</h3> 
        <h4>And you are invited</h4>
        <a class="btn btn-primary" asp-action="RsvpForm">RSVP Now</a>
    </div>
</body>

@model PartyInvites1.Models.GuestResponse
@{
    Layout = null;
}
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>RsvpForm</title>
    <link rel="stylesheet" href="/css/Styles.css" />
    <link rel="stylesheet" href="/lib/bootstrap/dist/css/bootstrap.css" /
</head>
<body>
    <form asp-action="RsvpForm" method="post">
        <div asp-validation-summary="All"></div>
        <p>
            <label asp-for="Name">Your name:</label>
            <input class="form-control" asp-for="Name" />
        </p>
        <p>
            <label asp-for="Email">Your email:</label>
            <input class="form-control" asp-for="Email" />
        </p>
        <p>
            <label asp-for="Phone">Your phone:</label>
            <input class="form-control" asp-for="Phone" />
            <!--<input type = "text" name="email" class="form-control" />-->
        </p>
        <p>
            <label>Will you attend?</label>
            <select class="form-control" asp-for="WillAttend">
                <option value="">Choose an option</option>
                <option value="true">Yes, I’ll be there</option>
                <option value="false">No, I can’t come</option>
            </select>
        </p>
        <p>
            <button type="submit">Submit RSVP</button>
    </form>
</body>
</html>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites1.Models
{
   

    public class GuestResponse
    {
    [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please specify whether you’ll attend")]
        public bool? WillAttend { get; set; }
    }
}

.field-validation-error {
    color: #f00;
}

.field-validation-valid {
    display: none;
}

.input-validation-error {
    border: 1px solid #f00;
    background-color: #fee;
}

.validation-summary-errors {
    font-weight: bold;
    color: #f00;
}

.validation-summary-valid {
    display: none;
}





